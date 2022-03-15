using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipScript : MonoBehaviour
{
    private int direction = 1;
    private Transform t;
    private float timer;
    private int seconds;
    private bool canAdvance;

    public GameObject purple;
    public GameObject red;
    public GameObject blue;
    public GameObject green;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        timer = 0f;
        seconds = 0;
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = (48 - t.childCount) / 24; //between 1 and 2 depending on number of remaining enemies
        timer += Time.deltaTime * speed;
        if (timer > seconds)
        {
            seconds++;
            if (seconds % 3 == 0 && t.childCount > 0)
            {
                int randomChildIdx = Random.Range(0, t.childCount);
                Transform randomChild = t.GetChild(randomChildIdx);
                randomChild.GetComponent<Enemy>().fire();
            }
            t.SetPositionAndRotation(new Vector2(t.position.x + direction, t.position.y), t.rotation);
            canAdvance = true;
        }

        if (t.childCount == 0)
        {
            GameObject.Find("GameManager").GetComponent<ManagerScript>().loadScene("Credits");
        }
    }

    public void advance()
    {
        if (!canAdvance) return;
        canAdvance = false;
        direction = -direction;
        t.SetPositionAndRotation(new Vector2(t.position.x + direction,t.position.y - 1),t.rotation);
    }

    private void spawn()
    {
        for (int i=0; i < 8; i+= 2)
        {
            for (int j=0; j<12; j+= 2)
            {
                GameObject ToSpawn;

                switch (i)
                {
                    case 0:
                        ToSpawn = green;
                        break;
                    case 2:
                        ToSpawn = blue;
                        break;
                    case 4:
                        ToSpawn = red;
                        break;
                    case 6:
                        ToSpawn = purple;
                        break;
                    default: ToSpawn = red; break;
                }

                ToSpawn = GameObject.Instantiate(ToSpawn, GetComponent<Transform>());
                ToSpawn.transform.localPosition = new Vector2(j, i);
            }
        }
    }
}
