using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _playerSpeed = 5.0f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Getting Horizontal Input.
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        // Setting Player's Velocity.
        Vector3 velocity = direction * _playerSpeed;

        _controller.Move(velocity * Time.deltaTime);
    }
}
