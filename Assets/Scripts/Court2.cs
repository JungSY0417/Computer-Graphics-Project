using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Court2 : MonoBehaviour
{
    GameObject tennisBall;

    // Start is called before the first frame update
    void Start()
    {
        tennisBall = GameObject.FindGameObjectWithTag("tennisBall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "tennisBall") {
            tennisBall.GetComponent<TennisBall>().bounce2 += 1;
        }
    }
}
