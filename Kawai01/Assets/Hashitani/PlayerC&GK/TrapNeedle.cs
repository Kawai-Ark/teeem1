using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapNeedle : MonoBehaviour
{
    //�j�̃g���b�v
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
            //�j����яo��
            gameObject.GetComponent<TrapG>().TrapOn = false;
        }
        else
        {
            //�������Ȃ�
        }
    }
}
