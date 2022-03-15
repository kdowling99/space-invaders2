using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Transform t;
    public int counter = 3;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (counter == 0)
        {
            Destroy(gameObject);
        } else
        {
            counter--;
            t.localScale = new Vector3(4 / (3 - counter), 1);
        }
    }
}
