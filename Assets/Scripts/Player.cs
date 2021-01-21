using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5.0f;
    private float _gravity = 1.0f;
    private float _jumpHeight = 30.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    private int _playerCoins;

    private CharacterController _controller;
    private UIManager _uiManager;

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null) {
            Debug.LogError("UI Manager is null");
        }
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
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
            }

            // applies gravity if the player is not grounded.
            _yVelocity -= _gravity;
        }

        // setting current velocity on y axis to our cached velocity in _yVelocity.
        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void addCoins()
    {
        _playerCoins++;
        _uiManager.updateCoins(_playerCoins);
    }
}
