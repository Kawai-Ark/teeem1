using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapG : MonoBehaviour
{
    public int Count = 4;
    public int over_time = 4;
    public bool pre_active = false;
    public bool ActiveTrap = false;
    public bool Player_Hit_Destroy = false;
    public bool Hit = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("GameKeeper").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (Player_Hit_Destroy && Hit)
        {
            Destroy(gameObject);
        }
    }

    public void TrapMoves()
    {
        //ƒeƒ“ƒ|Œo‰ßŽž‚É‚Ì‚ÝŽÀŒø
        if (Count > 0) Count -= 1;
        else if (Count <= 0)
        {
            if (over_time > 0) over_time -= 1;
            else if (over_time == 0) Destroy(gameObject);
        }
        ActiveTrap = Count > 0 ? pre_active : !pre_active;
    }
}
