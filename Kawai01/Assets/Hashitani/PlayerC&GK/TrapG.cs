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
        //�v���C���[�̂��Ȃ����W�ɏo��
        gameObject.GetComponent<BoxCollider2D>().transform.position =
            SetGimmick();
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
        //�e���|�o�ߎ��ɂ̂ݎ���
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
        List<Vector2> PopPointDummy = new List<Vector2>();
        for (int x = -4; x < 5; x++)
        {
            for (int y = -4; y < 5; y++)
            {
                PopPointDummy.Add(new Vector2(x, y));
            }
        }
        //�v���C���[�̂���}�X�Ɨאڂ���}�X���܂߂��͈͂�����
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject tPlayer in Players)
        {
            Vector2 PlayerPos = tPlayer.transform.position;
            for (int x = -1; x <= 1; x++)
            {//�אڂ���}�X���܂߂��͈͂ɏo�����Ȃ�
                for (int y = -1; y <= 1; y++)
                {
                    PopPointDummy.Remove(new Vector2(PlayerPos.x + x, PlayerPos.y + y));
                }
            }
        }
        //�M�~�b�N���c���Ă���}�X������
        GameObject[] Traps = GameObject.FindGameObjectsWithTag("Trap");
        foreach (GameObject Trap in Traps)
        {
            PopPointDummy.Remove(Trap.transform.position);
        }
        SetPos = PopPointDummy[Random.Range(0, PopPointDummy.Count)];
        return SetPos;
    }
}
