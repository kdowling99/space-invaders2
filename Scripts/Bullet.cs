using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
  public GameObject player;
  private Rigidbody2D myRigidbody2D;

  public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
      myRigidbody2D = GetComponent<Rigidbody2D>();
      player = GameObject.Find("Player");
      
      Fire();
    }

    private void Fire()
    {
      myRigidbody2D.velocity = Vector2.up * speed;
    }


    private void Update()
    {
        if (GetComponent<Transform>().position.y > 5.25)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2d(Collision2D collision)
    {
      if (player) player.GetComponent<Player>().setShoot(true);
      Destroy(gameObject);
      if(collision.gameObject.name == "EnemyBullet(Clone)")
        Destroy(collision.gameObject);
    }
    private void OnDisable()
    {
        if (player) player.GetComponent<Player>().setShoot(true);
    }
}
