using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score2P : MonoBehaviour
{
    public int score;
    int afterScore;

    GameObject score1P;
    GameObject gameScore2P;

    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        score1P = GameObject.FindGameObjectWithTag("score1P");
        gameScore2P = GameObject.FindGameObjectWithTag("gameScore2P");
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
            gameScore2P.GetComponent<GameScore2P>().gameScore += 1;
            score1P.GetComponent<Score1P>().score = 0;
            score = 0;
            afterScore = 0;
        }
    }
}
