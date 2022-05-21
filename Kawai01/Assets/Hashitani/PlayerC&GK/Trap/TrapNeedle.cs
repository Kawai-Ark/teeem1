using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapNeedle : MonoBehaviour
{
    public BoxCollider2D BC2;
    //j‚Ìƒgƒ‰ƒbƒv
    void Start()
    {
        GameKeeper.TrapPopCost += 2;
        gameObject.GetComponent<TrapG>().Count = 6;
        gameObject.GetComponent<TrapG>().over_time = 4;
        gameObject.GetComponent<TrapG>().pre_active = false;
        gameObject.GetComponent<TrapG>().Player_Hit_Destroy = false;
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1) * 0.95f;
    }
    public void OnDestroy()
    {
        GameKeeper.TrapPopCost -= 2;
    }
    //“–‚½‚è”»’è‚Í‚±‚±
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (gameObject.GetComponent<TrapG>().ActiveTrap &&
            collider.gameObject.GetComponent<Player_R>().muteki_tempo == 0)
            {
                //ŠÔ‚É‚È‚é‚Æj‚ª”ò‚Ño‚·
                collider.gameObject.GetComponent<Player_R>().m_Life -= 2;
                collider.gameObject.GetComponent<Player_R>().muteki_tempo = 3;
                gameObject.GetComponent<TrapG>().Hit = true;
                //‚±‚±‚ç‚ÅUI‚É‰e‹¿‚ğ—^‚¦‚é
            }
        }
    }
    // Update is called once per frame
}
