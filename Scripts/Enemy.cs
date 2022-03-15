using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public GameObject score;
    public GameObject motherShip;
    public int points;
    public GameObject bullet;
    private GameObject muzzle;

    public AudioClip pew;
    public AudioClip boom;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score");
        motherShip = GameObject.Find("MotherShip");
        muzzle = GetComponent<Transform>().GetChild(0).gameObject;
    }

    void Update()
    {
        if (GetComponent<Transform>().position.x > 20 || GetComponent<Transform>().position.x < -20)
        {
            motherShip.GetComponent<MothershipScript>().advance();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EnemyBullet(Clone)") return;
        Destroy(collision.gameObject);
        Destroy(gameObject, 0.75f);
        GetComponent<Animator>().SetTrigger("death");
        GameObject.Find("Audio Source").GetComponent<Audio>().playClip(boom);
        score.GetComponent<ScoreScript>().addScore(points);
        
    }

    public void fire()
    {
        GameObject shot = Instantiate(bullet, GetComponent<Transform>().position, Quaternion.identity);
        Destroy(shot, 5f);

        GameObject.Find("Audio Source").GetComponent<Audio>().playClip(pew);

        muzzle.GetComponent<Animator>().SetTrigger("shoot");
    }
}
