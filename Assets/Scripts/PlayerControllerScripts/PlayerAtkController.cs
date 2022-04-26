using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAtkController : MonoBehaviour
{
    public PlayerControls playerControls;
    private InputAction attack;
    Vector2 atkDirection = Vector2.zero;
    private float nextAttack;
    public WeaponInventory weaponInv;
    public WeaponObjects defaultWeap;

    private void Awake()
    {
        playerControls = new PlayerControls();
        weaponInv.SetToZero(); 
        weaponInv.AddDefaultWeapon(defaultWeap);
    }

    private void OnEnable()
    {
        attack = playerControls.Player.Shoot;
        attack.Enable();
    }

    private void OnDisable()
    {
        attack.Disable();
    }

    void Update()
    {
        atkDirection = attack.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        var currentWeapon = weaponInv.containers[weaponInv.GetCurrentSlot()];
        if (nextAttack > 0)
            nextAttack -= Time.deltaTime;
        if (atkDirection != Vector2.zero && atkDirection.sqrMagnitude >= 0.7)
        {
            if (nextAttack <= 0)
            {
                GameObject firedProjectile = Instantiate(currentWeapon.weapons.projectile.projectilePrefab, transform.position, Quaternion.identity);
                firedProjectile.GetComponent<Projectile>().projectile = currentWeapon.weapons.projectile;
                firedProjectile.GetComponent<Projectile>().damage = currentWeapon.weapons.projectile.damage;
                firedProjectile.GetComponent<Rigidbody2D>().velocity = atkDirection.normalized * currentWeapon.weapons.projectile.projectileSpeed;
                for (int i = 2; i <= currentWeapon.weapons.numOfShots; i++)
                {
                    AddSpread(currentWeapon);
                    firedProjectile = Instantiate(currentWeapon.weapons.projectile.projectilePrefab, transform.position, Quaternion.identity);
                    firedProjectile.GetComponent<Projectile>().projectile = currentWeapon.weapons.projectile;
                    firedProjectile.GetComponent<Projectile>().damage = currentWeapon.weapons.projectile.damage;
                    firedProjectile.GetComponent<Rigidbody2D>().velocity = atkDirection.normalized * currentWeapon.weapons.projectile.projectileSpeed;
                }
                nextAttack = currentWeapon.weapons.fireRate;
            }
        }
    }

    public void SwitchWeapon()
    {
        weaponInv.SwapCurrentSlot();
    }

    private void AddSpread(WeaponInventory.WeaponInventorySlots weapon)
    {
        float spread = Random.Range(0, weapon.weapons.spread);
        int dir = Random.Range(0, 1);
        int prevDir = dir;
        if (dir == 0 && prevDir != 0)
            atkDirection.x += spread;
        else
            atkDirection.x -= spread;
        
        spread = Random.Range(0, weapon.weapons.spread);
        dir = Random.Range(0, 1);
        prevDir = dir;
        if (dir == 0 && prevDir != 0)
            atkDirection.y += spread;
        else
            atkDirection.y -= spread;

    }

    private void OnApplicationQuit()
    {
        weaponInv.Clear();
    }

}
