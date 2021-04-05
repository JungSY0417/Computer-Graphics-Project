using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score1P : MonoBehaviour
{
    public int score;
    int afterScore;

    GameObject score2P;
    GameObject gameScore1P;

    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        score2P = GameObject.FindGameObjectWithTag("score2P");
        gameScore1P = GameObject.FindGameObjectWithTag("gameScore1P");
    }

    // Update is called once per frame
    void Update()
    {
        naming();
        GetComponent<Text>().text = "Score: " + afterScore;
    }

    public void naming() {
        if(score == 0) afterScore = 0;
        else if(score == 1) afterScore = 15;
        else if(score == 2) afterScore = 30;
        else if(score == 3) afterScore = 40;
        if(score == 4) {
            gameScore1P.GetComponent<GameScore1P>().gameScore += 1;
            score2P.GetComponent<Score2P>().score = 0;
            score = 0;
            afterScore = 0;
        }
    }
}
