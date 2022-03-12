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
    public WeaponObjects currentWeapon;

    private void Awake()
    {
        playerControls = new PlayerControls();
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
        if (nextAttack > 0)
            nextAttack -= Time.deltaTime;
        if (atkDirection != Vector2.zero && atkDirection.sqrMagnitude >= 0.7)
        {
            if (nextAttack <= 0)
            {
                GameObject firedProjectile = Instantiate(currentWeapon.projectile.projectilePrefab, transform.position, Quaternion.identity);
                firedProjectile.GetComponent<Rigidbody2D>().velocity = atkDirection.normalized * currentWeapon.projectile.projectileSpeed;
                nextAttack = currentWeapon.fireRate;
            }
        }
    }
}
