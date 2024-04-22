using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardBackward : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 10f;
    private Vector2 initialPosition;
    public Vector2 direction = Vector2.right;
    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float pingPongValue = Mathf.PingPong(Time.time * speed / distance, 1f);
        transform.position = initialPosition + direction * distance * pingPongValue;
    }
}
