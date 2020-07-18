using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expire : MonoBehaviour
{

    public float aliveTime = 4f;

    
    // Update is called once per frame
    void Update()
    {
        aliveTime -= Time.deltaTime;
        if(aliveTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
