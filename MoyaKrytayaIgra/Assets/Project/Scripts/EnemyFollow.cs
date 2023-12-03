using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform player;
    private float moveInput;
    private float horizontalInput;
    private float verticalInput;
    public float followDistance = 10f;

    private Rigidbody2D rb;

    private bool facingRight = true;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < followDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;

            if (facingRight && direction.x < 0)
            {
                Flip();
            }
            else if (!facingRight && direction.x > 0)
            {
                Flip();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

