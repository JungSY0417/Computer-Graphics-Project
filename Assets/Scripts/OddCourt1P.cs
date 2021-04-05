using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OddCourt1P : MonoBehaviour
{
    public bool oddServe;

    GameObject tennisBall;

    // Start is called before the first frame update
    void Awake()
    {
        tennisBall = GameObject.FindGameObjectWithTag("tennisBall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "tennisBall" && oddServe) {
            tennisBall.GetComponent<TennisBall>().serveBounce1 += 1;
        }
    }
}
