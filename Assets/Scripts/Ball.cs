using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 ScreenSize;
    float radius;

    public bool Bouncing;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(100, 100));
        float height = Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;
        print(width + " x " + height);

        ScreenSize = new Vector2(width, height);
        radius = transform.localScale.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Bouncing)
        {
            if (transform.position.x > ScreenSize.x) transform.position = new Vector2(-ScreenSize.x, transform.position.y);
            else if (transform.position.x < -ScreenSize.x) transform.position = new Vector2(ScreenSize.x, transform.position.y);

            if (transform.position.y > ScreenSize.y) transform.position = new Vector2(transform.position.x, -ScreenSize.y);
            else if (transform.position.y < -ScreenSize.y) transform.position = new Vector2(transform.position.x, ScreenSize.y);
        }
        else
        {
            if(rb.velocity.x > 0 && transform.position.x + radius > ScreenSize.x)
            {
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            }else if(rb.velocity.x < 0 && transform.position.x - radius < -ScreenSize.x)
            {
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            }

            if (rb.velocity.y > 0 && transform.position.y + radius > ScreenSize.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            }
            else if (rb.velocity.y < 0 && transform.position.y - radius < -ScreenSize.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            }
        }
        
    }
}
