using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapG : MonoBehaviour
{
    public bool ZeroCountBreak = false;
    public int Count = 0;
    public bool TrapOn = true;
    public float action_time = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("GameKeeper").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Count == 0) TrapMoves();
    }

    //㩍쓮
    public void TrapMoves()
    {

    }
}
