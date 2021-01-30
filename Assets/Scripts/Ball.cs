using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 ScreenSize;
    float ballSize;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 100));
        float height = Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;
        print(width + " x " + height);

        ScreenSize = new Vector2(width, height);
        ballSize = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > ScreenSize.x) transform.position = new Vector2(-ScreenSize.x, transform.position.y);
        else if(transform.position.x < -ScreenSize.x) transform.position = new Vector2(ScreenSize.x, transform.position.y);

        if (transform.position.y > ScreenSize.y) transform.position = new Vector2(transform.position.x, -ScreenSize.y);
        else if (transform.position.y < -ScreenSize.y) transform.position = new Vector2( transform.position.x, ScreenSize.y);
    }
}
