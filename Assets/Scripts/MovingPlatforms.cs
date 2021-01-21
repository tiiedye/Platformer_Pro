using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA, _pointB;
    private float _speed = 3.0f;
    private bool _switch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_switch == false) {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, Time.deltaTime * _speed);
        } else if (_switch == true) {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, Time.deltaTime * _speed);
        }

        if (transform.position == _pointA.position) {
            _switch = false;
        } else if (transform.position == _pointB.position) {
            _switch = true;
        }

    }

    // collision detection w/ player
    // if collide w/ player
    // make the player parent = this game object
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            other.transform.parent = this.transform;
        }
    }

    // exit collision
    // check if player exited
    // make the player parent = null
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player") {
            other.transform.parent = null;
        }
    }
}
