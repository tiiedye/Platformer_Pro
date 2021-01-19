using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _playerSpeed = 5.0f;
    private float _gravity = 1.0f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool grounded = _controller.isGrounded;
        // Getting Horizontal Input.
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        // Setting Player's Velocity.
        Vector3 velocity = direction * _playerSpeed;

        // checks if the player is grounded.
        if (grounded == true) {
            // do nothing, maybe jump later
            return;
        } else {
            // applies gravity if the player is not grounded.
            velocity.y -= _gravity;
        }

        _controller.Move(velocity * Time.deltaTime);
    }
}
