using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject projetile;
    public Rigidbody2D playerRb;
    public float playerSpeed = 5f;
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

    void Update()
    {
        movDirection = move.ReadValue<Vector2>();
        atkDirection = attack.ReadValue<Vector2>();
        if (atkDirection != Vector2.zero)
        {
            GameObject DefaultProjectile = Instantiate(projetile, transform.position, Quaternion.identity);
            DefaultProjectile.GetComponent<Rigidbody2D>().velocity = atkDirection * defaultProjectile.speed;
        }
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(movDirection.x * playerSpeed, movDirection.y * playerSpeed);
    }
}
