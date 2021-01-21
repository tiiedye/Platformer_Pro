using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA, _pointB;
    private float _speed = 1.0f;
    private bool _switch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
