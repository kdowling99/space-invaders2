using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{

    public TextMeshProUGUI text;
    public GameObject hiScore;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text.SetText("SCORE\n{00000}", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int x) {
        score += x;
        text.SetText("SCORE\n{00000}", score);

        hiScore.GetComponent<HiScoreScript>().checkScore(score);
    }
}
