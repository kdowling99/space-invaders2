using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HiScoreScript : MonoBehaviour
{
    public int hiScore;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        hiScore = PlayerPrefs.GetInt("hiScore", 0);
        text.SetText("SCORE\n{00000}", hiScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkScore(int x)
    {
        if (x > hiScore)
        {
            hiScore = x;
            text.SetText("SCORE\n{00000}", hiScore);
            PlayerPrefs.SetInt("hiScore", hiScore);
        }
    }
}

