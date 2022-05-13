using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapNeedle : MonoBehaviour
{
    //針のトラップ
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!gameObject.GetComponent<TrapG>().TrapOn&&
            gameObject.GetComponent<TrapG>().Count == 0)
        {

        }
        else if (gameObject.GetComponent<TrapG>().TrapOn)
        {
            //針が飛び出す
            gameObject.GetComponent<TrapG>().TrapOn = false;
        }
        else
        {
            //何もしない
        }
    }
}
