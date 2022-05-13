using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapG : MonoBehaviour
{
    public int Count = 0;
    public bool activeTrap = false;
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
        
    }

    public void TrapMoves()
    {
        if (Count > 0) Count -= 1;
        else if (Count == 0)
        {
            if (!TrapOn&&!activeTrap)
            {
                TrapOn = true;
                activeTrap = true;
            }
            if (action_time >= 1.0f) action_time -= 1.0f;
            else if (action_time <= 0.0f) Destroy(gameObject);
        }

    }
}
