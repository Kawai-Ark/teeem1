using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShot : MonoBehaviour
{
    public BoxCollider2D BC2;
    //針のトラップ
    void Start()
    {
        GameKeeper.TrapPopCost += 5;
        switch (Random.Range(0, 3))
        {
            case 0:
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 14);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 27) * 0.95f;
                break;
            case 1:
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, -14);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 27) * 0.95f;
                break;
            case 2:
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(14, 0);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(27, 1) * 0.95f;
                break;
            case 3:
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-14, 0);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(27, 1) * 0.95f;
                break;
        }
        //向きを指定
        //そこから攻撃判定のあるものを出し
        gameObject.GetComponent<TrapG>().Count = 4;
        gameObject.GetComponent<TrapG>().over_time = 1;
        gameObject.GetComponent<TrapG>().pre_active = false;
        gameObject.GetComponent<TrapG>().Player_Hit_Destroy = false;
    }
    public void OnDestroy()
    {
        GameKeeper.TrapPopCost -= 5;
    }
    public void Update()
    {
        if (GameKeeper.fastTime &&
            gameObject.GetComponent<TrapG>().Count == 1)
        {
            //光る
        }
    }
    //当たり判定はここ
    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (gameObject.GetComponent<TrapG>().ActiveTrap &&
            collider.gameObject.GetComponent<Player_R>().muteki_tempo == 0)
            {
                collider.gameObject.GetComponent<Player_R>().m_Life -= 2;
                collider.gameObject.GetComponent<Player_R>().muteki_tempo = 3;
                gameObject.GetComponent<TrapG>().Hit = true;
                //ここらでUIに影響を与える
            }
        }
    }
    // Update is called once per frame
}
