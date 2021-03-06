using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAtkController : MonoBehaviour
{
    public PlayerControls playerControls;
    public PlayerStats player;
    private InputAction attack;
    Vector2 atkDirection = Vector2.zero;
    private float nextAttack;
    public WeaponInventory weaponInv;
    public WeaponObjects defaultWeap;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        weaponInv.SetToZero();
        weaponInv.AddDefaultWeapon(defaultWeap);
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
                SoundManager sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
                sm.PlaySound("shoot");
                GameObject firedProjectile = Instantiate(currentWeapon.weapons.projectile.projectilePrefab, transform.position, Quaternion.identity);
                Projectile projectile = firedProjectile.GetComponent<Projectile>();
                projectile.projectile = currentWeapon.weapons.projectile;
                projectile.damage = currentWeapon.weapons.projectile.damage + player.dmgMod;
                firedProjectile.GetComponent<Rigidbody2D>().velocity = atkDirection.normalized * currentWeapon.weapons.projectile.projectileSpeed;
                for (int i = 2; i <= currentWeapon.weapons.numOfShots; i++)
                {
                    AddSpread(currentWeapon);
                    GameObject extraProjectile = Instantiate(currentWeapon.weapons.projectile.projectilePrefab, transform.position, Quaternion.identity);
                    extraProjectile.GetComponent<Projectile>().projectile = currentWeapon.weapons.projectile;
                    extraProjectile.GetComponent<Projectile>().damage = currentWeapon.weapons.projectile.damage + player.dmgMod;
                    extraProjectile.GetComponent<Rigidbody2D>().velocity = atkDirection.normalized * currentWeapon.weapons.projectile.projectileSpeed;
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
