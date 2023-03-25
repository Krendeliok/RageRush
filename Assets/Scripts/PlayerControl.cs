using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    private Joystick _joystick;

    [SerializeField]
    private float speed = 0.1f;

    void Start()
    {
        _joystick.OnMove += Move;
    }

    private void Move(Vector2 obj)
    {
        transform.position += new Vector3(obj.x, 0, obj.y) * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
