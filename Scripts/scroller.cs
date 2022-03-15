using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour
{
    public float scrollSpeed;
    private Transform t;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        GameObject.Find("Audio Source").GetComponent<Audio>().playClip(clip);
        
    }

    // Update is called once per frame
    void Update()
    {
        t.position = new Vector2(t.position.x, t.position.y + scrollSpeed * Time.deltaTime);
        if (t.position.y > 20)
        {
            GameObject.Find("GameManager").GetComponent<ManagerScript>().loadScene("Main Menu");
        }
    }
}
