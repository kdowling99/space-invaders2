using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public float speed;

  private Transform t;
  private bool canShoot = true;
    public Transform shootingOffset;
    public GameObject shootingAnimator;

    public AudioClip pew;
    public AudioClip boom;

    void Start()
    {
        t = GetComponent<Transform>();
    }

    void Update()
    {
      //if (Input.GetKeyDown(KeyCode.Space)) Debug.Log("Can shoot: " + canShoot);
      if (Input.GetKeyDown(KeyCode.Space) && canShoot)
      {
        GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
        canShoot = false;

            shootingAnimator.GetComponent<Animator>().SetTrigger("shoot");
            GameObject.Find("Audio Source").GetComponent<Audio>().playClip(pew);

            Destroy(shot, 5f);
      }

        t.SetPositionAndRotation(new Vector2(t.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed,t.position.y), t.rotation);
    }

    public void setShoot(bool b)
    {
      canShoot = b;
    }

    public void explode()
    {
        GetComponent<Animator>().SetTrigger("death");
        GameObject.Find("Audio Source").GetComponent<Audio>().playClip(boom);
        Destroy(this.gameObject, 0.9f);
    }

    public void OnDestroy()
    {
        GameObject.Find("GameManager").GetComponent<ManagerScript>().loadScene("Credits");
    }
}
