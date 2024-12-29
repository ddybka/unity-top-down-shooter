using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;

    private float moveSpeed = 7f;
    private float addSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(h, v, 0) * (moveSpeed + addSpeed);

        Vector3 worldVelocity = transform.TransformVector(velocity);
        rb.velocity = worldVelocity;
    }

    private void Update()
    {
        addSpeed = Input.GetKey(KeyCode.LeftShift) ? 3f : 0f;
    }
}
