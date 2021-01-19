using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _playerSpeed = 5.0f;
    private float _gravity = 1.0f;
    private float _jumpHeight = 25.0f;
    private float _doubleJumpHeight = 40.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool grounded = _controller.isGrounded;
        float horizontalInput = Input.GetAxis("Horizontal");

        // Player's direction and velocity.
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _playerSpeed;

        // checks if the player is grounded.
        if (grounded == true) {
            // if space key hit, jump.
            if (Input.GetKeyDown(KeyCode.Space)) {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        } else {
            // check for double jump
            if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump == true) {
                _yVelocity += _doubleJumpHeight;
                _canDoubleJump = false;
            }

            // applies gravity if the player is not grounded.
            _yVelocity -= _gravity;
        }

        // setting current velocity on y axis to our cached velocity in _yVelocity.
        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
