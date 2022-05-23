using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPitFall : MonoBehaviour
{
    public BoxCollider2D BC2;
    void Start()
    {
        GameKeeper.TrapPopCost += 3;
        gameObject.GetComponent<TrapG>().Count = 16;
        gameObject.GetComponent<TrapG>().over_time = 0;
        gameObject.GetComponent<TrapG>().pre_active = false;
        gameObject.GetComponent<TrapG>().Player_Hit_Destroy = false;
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1) * 0.95f;
    }
    public void OnDestroy()
    {
        GameKeeper.TrapPopCost -= 3;
    }

    //“–‚½‚è”»’è‚Í‚±‚±
    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")&&
            !gameObject.GetComponent<TrapG>().Hit)
        {
            if (gameObject.GetComponent<TrapG>().Count > 8)
                gameObject.GetComponent<TrapG>().Count = 8;
            collider.gameObject.GetComponent<Player_R>().StopCount = 2;
            collider.gameObject.GetComponent<Player_R>().Combo = 0;
            gameObject.GetComponent<TrapG>().Hit = true;
            //‚±‚±‚ç‚ÅUI‚É‰e‹¿‚ð—^‚¦‚é
        }
        if (collider.gameObject.CompareTag("Player"))
        {
            if (collider.gameObject.GetComponent<Player_R>().StopCount == 0)
                gameObject.GetComponent<TrapG>().Count = 0;
        }
    }
}
