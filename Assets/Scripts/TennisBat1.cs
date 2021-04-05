using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBat1 : MonoBehaviour
{
    public GameObject evenServe1P;
    public GameObject oddServe1P;

    GameObject tennisBall;
    GameObject score1P;

    Player1 player1Class;
    GameObject player1;

    GameObject oddCourt2P;

    // Start is called before the first frame update
    void Awake()
    {
        tennisBall = GameObject.FindGameObjectWithTag("tennisBall");
        score1P = GameObject.FindGameObjectWithTag("score1P");

        player1 = GameObject.FindGameObjectWithTag("player1");
        player1Class = player1.GetComponent<Player1>();

        oddCourt2P = GameObject.FindGameObjectWithTag("oddCourt2P");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "tennisBall" && oddCourt2P.GetComponent<OddCourt2P>().oddServe) {
            Rigidbody rigidbody = tennisBall.GetComponent<Rigidbody> ();
            Vector3 direction = transform.position - other.gameObject.transform.position;
            Vector3 throwAngle = Vector3.up * 3.5f + 
                                Vector3.back * player1Class.force * 0.8f - 
                                direction.normalized * 2.5f;

            tennisBall.GetComponent<Rigidbody>().velocity = throwAngle;
            tennisBall.GetComponent<TennisBall>().bounce1 = 0;
            tennisBall.GetComponent<TennisBall>().bounce2 = 0;
            evenServe1P.SetActive(false);
            oddServe1P.SetActive(false);
            player1Class.canServe = false;
        }
        else if(other.transform.tag == "tennisBall") {
            Rigidbody rigidbody = tennisBall.GetComponent<Rigidbody> ();
            Vector3 direction = transform.position - other.gameObject.transform.position;
            Vector3 throwAngle = Vector3.up * 5.5f + 
                                Vector3.back * player1Class.force + 
                                direction.normalized * 4f;

            tennisBall.GetComponent<Rigidbody>().velocity = throwAngle;
            tennisBall.GetComponent<TennisBall>().bounce1 = 0;
            tennisBall.GetComponent<TennisBall>().bounce2 = 0;
            evenServe1P.SetActive(false);
            oddServe1P.SetActive(false);
            player1Class.canServe = false;
        }
    }
}
