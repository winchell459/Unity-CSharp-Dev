using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Initialize(Transform target, float speed)
    {
        Vector2 direction = (target.position - transform.position).normalized;
        transform.up = direction;
        GetComponent<Rigidbody2D>().velocity = direction * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Base>())
        {
            //sprint("Target Distance: " + Vector2.Distance(collision.transform.position, transform.position));
            collision.transform.GetComponent<Base>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
