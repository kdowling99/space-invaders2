using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        fire();
    }

    private void fire()
    {
        rb.velocity = Vector2.down * speed;
    }


    private void Update()
    {
        if (GetComponent<Transform>().position.y < -9)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Player>().explode();
        }
    }
}
