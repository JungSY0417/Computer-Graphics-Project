using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScore2P : MonoBehaviour
{
    public int gameScore;

    // Start is called before the first frame update
    void Awake()
    {
        gameScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "GameScore: " + gameScore;
        if(gameScore == 2) {
            SceneManager.LoadScene("Player2Win");
        }
    }
}
