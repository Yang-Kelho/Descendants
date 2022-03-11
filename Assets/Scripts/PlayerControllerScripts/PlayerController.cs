using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public Rigidbody2D playerRb;
    public float playerSpeed = 3f;
    public PlayerControls playerControls;
    Vector2 movDirection = Vector2.zero;
    Vector2 atkDirection = Vector2.zero;
    private InputAction move;
    private InputAction attack;
    public DefaultPlayerProjectileScriptableObject defaultProjectile;

    public float defaultCooldown = 0.5f;
    public float nextAttack;


    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
        attack = playerControls.Player.Shoot;
        attack.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        attack.Disable();
    }

    void Update()
    {
        movDirection = move.ReadValue<Vector2>();
        atkDirection = attack.ReadValue<Vector2>();
        
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(movDirection.x * playerSpeed * 100, movDirection.y * playerSpeed * 100);
        if (nextAttack > 0)
            nextAttack -= Time.deltaTime;
        if (atkDirection != Vector2.zero && atkDirection.sqrMagnitude >= 0.7)
        {
            if (nextAttack <= 0)
            {
                GameObject DefaultProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                DefaultProjectile.GetComponent<Rigidbody2D>().velocity = atkDirection.normalized * defaultProjectile.speed;
                nextAttack = defaultCooldown;
            }
        }
    }
}
