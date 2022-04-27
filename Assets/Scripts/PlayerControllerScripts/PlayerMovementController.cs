using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float playerSpeed = 300f;
    public PlayerControls playerControls;
    Vector2 movDirection = Vector2.zero;
    private InputAction move;


    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        movDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(movDirection.x * playerSpeed, movDirection.y * playerSpeed);
    }

    public Vector2 GetPosition()
    {
        return GetComponent<Transform>().position; 
    }
}
