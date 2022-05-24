using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpUpScore : MonoBehaviour
{
    public BoxCollider2D BC2;
    public int bos = 64;
    public int PlusScore = 200;
    static public bool CheckOnMap = false;
    void Start()
    {
        CheckOnMap = true;
        gameObject.GetComponent<TrapG>().Count = 64;
        gameObject.GetComponent<TrapG>().over_time = 0;
        gameObject.GetComponent<TrapG>().pre_active = false;
        gameObject.GetComponent<TrapG>().Player_Hit_Destroy = false;
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1) * 0.95f;
    }
    public void ScoreUp()
    {
        gameObject.GetComponent<BoxCollider2D>().transform.position = TrapG.SetGimmick();
        if (bos > 8) bos -= 8;
        if (PlusScore < 6400) PlusScore *= 2;
        gameObject.GetComponent<TrapG>().Count = bos;
    }
    public void OnDestroy()
    {
        CheckOnMap = false;
    }
    //“–‚½‚è”»’è‚Í‚±‚±
    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            ScoreUp();
            //‚±‚±‚ç‚ÅUI‚É‰e‹¿‚ð—^‚¦‚é
        }
    }
}
