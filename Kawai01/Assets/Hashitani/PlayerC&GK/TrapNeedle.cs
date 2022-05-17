using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapNeedle : MonoBehaviour
{
    public BoxCollider2D BC2;
    //j‚Ìƒgƒ‰ƒbƒv
    void Start()
    {
        gameObject.GetComponent<TrapG>().Count = 4;
        gameObject.GetComponent<TrapG>().over_time = 2;
        gameObject.GetComponent<TrapG>().pre_active = false;
        gameObject.GetComponent<TrapG>().Player_Hit_Destroy = false;
    }

    void ActiveTrap()
    {

    }
    //“–‚½‚è”»’è‚Í‚±‚±
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.GetComponent<TrapG>().ActiveTrap &&
            collision.gameObject.GetComponent<Player_R>().muteki_tempo == 0)
            {
                //ŠÔ‚É‚È‚é‚Æj‚ª”ò‚Ño‚·
                collision.gameObject.GetComponent<Player_R>().m_Life -= 2;
                collision.gameObject.GetComponent<Player_R>().muteki_tempo = 3;
                gameObject.GetComponent<TrapG>().Hit = true;
                //‚±‚±‚ç‚ÅUI‚É‰e‹¿‚ğ—^‚¦‚é
            }
        }
    }
    // Update is called once per frame
}
