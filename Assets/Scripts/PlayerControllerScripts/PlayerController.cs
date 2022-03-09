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

    // Update is called once per frame
    void Update()
    {
        movDirection = move.ReadValue<Vector2>();
        atkDirection = attack.ReadValue<Vector2>();
        if (atkDirection != Vector2.zero)
        {
            GameObject DefaultProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            DefaultProjectile.GetComponent<Rigidbody2D>().velocity = atkDirection * defaultProjectile.speed;
        }
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(movDirection.x * playerSpeed * 100, movDirection.y * playerSpeed * 100);
    }
}
