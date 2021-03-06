using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float Speed = 5;
    public float JumpSpeed = 5;
    public LayerMask LayerMask;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) handleJump();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * moveX * Speed);
        
    }

    private void handleJump()
    {
        if (Physics2D.OverlapCircle((Vector2)transform.position - 0.2f * Vector2.up, 0.45f,LayerMask))
        {
            rb.AddForce(Vector2.up * JumpSpeed);
        }
    }
}
