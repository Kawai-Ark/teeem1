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
        gameObject.transform.position = SetGimmick();
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
    static public Vector2 SetGimmick()
    {
        Vector2 SetPos;
        List<Vector2> DummyPos = new List<Vector2>();
        for (int x = -4; x <= 4; x++)
        {
            for (int y = -4; y <= 4; y++)
            {
                DummyPos.Add(new Vector2(x, y));
            }
        }
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject tPlayer in Players)
        {
            Vector2 PrePos = tPlayer.transform.position;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    DummyPos.Remove(new Vector2(PrePos.x + x, PrePos.y + y));
                }
            }
        }
        GameObject[] Traps = GameObject.FindGameObjectsWithTag("Trap");
        foreach (GameObject Trap in Traps)
        {
            DummyPos.Remove(Trap.transform.position);
        }
        SetPos = DummyPos[Random.Range(0, DummyPos.Count)];
        return SetPos;
    }
}
