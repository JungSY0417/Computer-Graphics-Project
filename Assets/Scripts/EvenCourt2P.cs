using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvenCourt2P : MonoBehaviour
{
    public bool evenServe;

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
        if(other.transform.tag == "tennisBall" && evenServe) {
            tennisBall.GetComponent<TennisBall>().serveBounce2 += 1;
        }
    }
}
