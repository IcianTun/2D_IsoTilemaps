using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class testTouchScript : MonoBehaviour
{
    public GameObject particle;

    public TMP_Text displayText;
    Touch theTouch;
    private float timeTouchEnded;
    private float displayTime = 1.0f;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            displayText.text = theTouch.phase.ToString();

            if (theTouch.phase == TouchPhase.Ended)
            {
                timeTouchEnded = Time.time;
            }

           


        }
        else if (Time.time - timeTouchEnded > displayTime)
        {
            displayText.text = "";
        }
        
    }
}
