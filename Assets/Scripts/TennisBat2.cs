using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBat2 : MonoBehaviour
{
    public GameObject evenServe2P;
    public GameObject oddServe2P;
    
    GameObject tennisBall;
    GameObject score2P;

    Player2 player2Class;
    GameObject player2;

    GameObject oddCourt1P;

    // Start is called before the first frame update
    void Awake()
    {
        tennisBall = GameObject.FindGameObjectWithTag("tennisBall");
        score2P = GameObject.FindGameObjectWithTag("score2P");

        player2 = GameObject.FindGameObjectWithTag("player2");
        player2Class = player2.GetComponent<Player2>();

        oddCourt1P = GameObject.FindGameObjectWithTag("oddCourt1P");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "tennisBall" && oddCourt1P.GetComponent<OddCourt1P>().oddServe) {
            Rigidbody rigidbody = tennisBall.GetComponent<Rigidbody> ();
            Vector3 direction = transform.position - other.gameObject.transform.position;
            Vector3 throwAngle = Vector3.up * 2.5f + 
                                Vector3.forward * player2Class.force * 0.7f - 
                                direction.normalized * 2.5f;

            tennisBall.GetComponent<Rigidbody>().velocity = throwAngle;
            tennisBall.GetComponent<TennisBall>().bounce1 = 0;
            tennisBall.GetComponent<TennisBall>().bounce2 = 0;
            evenServe2P.SetActive(false);
            oddServe2P.SetActive(false);
            player2Class.canServe = false;
        }
        else if(other.transform.tag == "tennisBall") {
            Rigidbody rigidbody = tennisBall.GetComponent<Rigidbody> ();
            Vector3 direction = transform.position - other.gameObject.transform.position;
            Vector3 throwAngle = Vector3.up * 5.5f + 
                                Vector3.forward * player2Class.force + 
                                direction.normalized * 4.5f;

            tennisBall.GetComponent<Rigidbody>().velocity = throwAngle;
            tennisBall.GetComponent<TennisBall>().bounce1 = 0;
            tennisBall.GetComponent<TennisBall>().bounce2 = 0;
            evenServe2P.SetActive(false);
            oddServe2P.SetActive(false);
            player2Class.canServe = false;
        }
    }
}
