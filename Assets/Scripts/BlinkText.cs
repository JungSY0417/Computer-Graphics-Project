using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlinkText : MonoBehaviour
{
    // Blink from https://sosohanbox.tistory.com/159
    void Start()
    {
        StartCoroutine(Blink());
    }

    public IEnumerator Blink() {
        while(true) {
            GetComponent<Text>().text = "";
            yield return new WaitForSeconds(.7f);
            GetComponent<Text>().text = "Press Any Key To Start";
            yield return new WaitForSeconds(.7f);
        }
    }
}
