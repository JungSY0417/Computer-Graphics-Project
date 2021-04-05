using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall4 : MonoBehaviour
{
    public GameObject evenServe1P;
    public GameObject oddServe1P;
    public GameObject evenServe2P;
    public GameObject oddServe2P;

    GameObject tennisBall;

    GameObject player1;
    GameObject player2;

    GameObject playerEquipPoint1;
    GameObject playerEquipPoint2;

    GameObject gameScore1P;
    GameObject gameScore2P;
    GameObject score1P;
    GameObject score2P;

    GameObject evenCourt1P;
    GameObject oddCourt1P;
    GameObject evenCourt2P;
    GameObject oddCourt2P;

    // Start is called before the first frame update
    void Awake()
    {
        tennisBall = GameObject.FindGameObjectWithTag("tennisBall");

        player1 = GameObject.FindGameObjectWithTag("player1");
        player2 = GameObject.FindGameObjectWithTag("player2");

        playerEquipPoint1 = GameObject.FindGameObjectWithTag("leftHand1");
        playerEquipPoint2 = GameObject.FindGameObjectWithTag("leftHand2");

        gameScore1P = GameObject.FindGameObjectWithTag("gameScore1P");
        gameScore2P = GameObject.FindGameObjectWithTag("gameScore2P");

        score1P = GameObject.FindGameObjectWithTag("score1P");
        score2P = GameObject.FindGameObjectWithTag("score2P");
        
        evenCourt1P = GameObject.FindGameObjectWithTag("evenCourt1P");
        oddCourt1P = GameObject.FindGameObjectWithTag("oddCourt1P");
        evenCourt2P = GameObject.FindGameObjectWithTag("evenCourt2P");
        oddCourt2P = GameObject.FindGameObjectWithTag("oddCourt2P");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "tennisBall"
                && tennisBall.GetComponent<TennisBall>().bounce2 == 1
                && tennisBall.GetComponent<TennisBall>().serveBounce2 == 0
                && (evenCourt2P.GetComponent<EvenCourt2P>().evenServe
                || oddCourt2P.GetComponent<OddCourt2P>().oddServe)) {
            tennisBall.GetComponent<TennisBall>().bounce1 = 0;
            tennisBall.GetComponent<TennisBall>().bounce2 = 0;
            evenCourt2P.GetComponent<EvenCourt2P>().evenServe = false;
            oddCourt2P.GetComponent<OddCourt2P>().oddServe = false;
            score2P.GetComponent<Score2P>().score += 1;
            score2P.GetComponent<Score2P>().naming();

            SetEquip();
        }
        else if(other.transform.tag == "tennisBall"
                && tennisBall.GetComponent<TennisBall>().bounce2 == 1
                && tennisBall.GetComponent<TennisBall>().serveBounce2 == 1
                && (evenCourt2P.GetComponent<EvenCourt2P>().evenServe
                || oddCourt2P.GetComponent<OddCourt2P>().oddServe)){
            tennisBall.GetComponent<TennisBall>().serveBounce1 = 0;
            tennisBall.GetComponent<TennisBall>().serveBounce2 = 0;
            evenCourt2P.GetComponent<EvenCourt2P>().evenServe = false;
            oddCourt2P.GetComponent<OddCourt2P>().oddServe = false;
        }

        if(other.transform.tag == "tennisBall"
                && tennisBall.GetComponent<TennisBall>().bounce1 == 1
                && tennisBall.GetComponent<TennisBall>().serveBounce1 == 0
                && (evenCourt1P.GetComponent<EvenCourt1P>().evenServe
                || oddCourt1P.GetComponent<OddCourt1P>().oddServe)) {
            tennisBall.GetComponent<TennisBall>().bounce1 = 0;
            tennisBall.GetComponent<TennisBall>().bounce2 = 0;
            evenCourt1P.GetComponent<EvenCourt1P>().evenServe = false;
            oddCourt1P.GetComponent<OddCourt1P>().oddServe = false;
            score1P.GetComponent<Score1P>().score += 1;
            score1P.GetComponent<Score1P>().naming();

            SetEquip();
        }
        else if(other.transform.tag == "tennisBall"
                && tennisBall.GetComponent<TennisBall>().bounce1 == 1
                && tennisBall.GetComponent<TennisBall>().serveBounce1 == 1
                && (evenCourt1P.GetComponent<EvenCourt1P>().evenServe
                || oddCourt1P.GetComponent<OddCourt1P>().oddServe)){
            tennisBall.GetComponent<TennisBall>().serveBounce1 = 0;
            tennisBall.GetComponent<TennisBall>().serveBounce2 = 0;
            evenCourt1P.GetComponent<EvenCourt1P>().evenServe = false;
            oddCourt1P.GetComponent<OddCourt1P>().oddServe = false;
        }

        if(other.transform.tag == "tennisBall"
                && tennisBall.GetComponent<TennisBall>().bounce2 >= 1) {
            score1P.GetComponent<Score1P>().score += 1;
            score1P.GetComponent<Score1P>().naming();
            tennisBall.GetComponent<TennisBall>().bounce1 = 0;
            tennisBall.GetComponent<TennisBall>().bounce2 = 0;

            SetEquip();
        } 
        else if(other.transform.tag == "tennisBall"
                && tennisBall.GetComponent<TennisBall>().bounce2 < 1) {
            score2P.GetComponent<Score2P>().score += 1;
            score2P.GetComponent<Score2P>().naming();
            tennisBall.GetComponent<TennisBall>().bounce1 = 0;
            tennisBall.GetComponent<TennisBall>().bounce2 = 0;

            SetEquip();
        }
    }

    void SetEquip() {
        if((gameScore1P.GetComponent<GameScore1P>().gameScore
                    + gameScore2P.GetComponent<GameScore2P>().gameScore) % 2 == 0) {
            player1.GetComponent<Player1>().canServe = true;
            if(score1P.GetComponent<Score1P>().score % 2 == 0) {
                evenCourt2P.GetComponent<EvenCourt2P>().evenServe = true;
                player1.transform.position = new Vector3(-2.3f, 0.25f, 9.4f);
                evenServe1P.SetActive(true);
            }
            else if(score1P.GetComponent<Score1P>().score % 2 == 1) {
                oddCourt2P.GetComponent<OddCourt2P>().oddServe = true;
                player1.transform.position = new Vector3(2.3f, 0.25f, 9.4f);
                oddServe1P.SetActive(true);
            }
            player1.GetComponent<Player1>().PickUp(playerEquipPoint1, tennisBall);
        }
        else if((gameScore1P.GetComponent<GameScore1P>().gameScore
                    + gameScore2P.GetComponent<GameScore2P>().gameScore) % 2 == 1) {
            player2.GetComponent<Player2>().canServe = true;
            if(score2P.GetComponent<Score2P>().score % 2 == 0) {
                evenCourt1P.GetComponent<EvenCourt1P>().evenServe = true;
                player2.transform.position = new Vector3(2.3f, 0.25f, -9.4f);
                evenServe2P.SetActive(true);
            }
            else if(score2P.GetComponent<Score2P>().score % 2 == 1) {
                oddCourt1P.GetComponent<OddCourt1P>().oddServe = true;
                player2.transform.position = new Vector3(-2.3f, 0.25f, -9.4f);
                oddServe2P.SetActive(true);
            }
            player2.GetComponent<Player2>().PickUp(playerEquipPoint2, tennisBall);
        }
    }
}
