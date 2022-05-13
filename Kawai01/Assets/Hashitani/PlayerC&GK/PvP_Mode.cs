using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvP_Mode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public static void Game()
    {
        //どちらが勝ったか
        GameObject[] Characters = GameObject.FindGameObjectsWithTag("Player");
        if (Characters[0].GetComponent<Player>().m_Life <= 0)
            Characters[0].GetComponent<Player>().Keep_Life = false;
        if (Characters[1].GetComponent<Player>().m_Life <= 0)
            Characters[1].GetComponent<Player>().Keep_Life = false;
        Characters[0].GetComponent<Player>().Sousa();
        Characters[1].GetComponent<Player>().Sousa();

        if (!Characters[0].GetComponent<Player>().Keep_Life&&
            !Characters[1].GetComponent<Player>().Keep_Life)
        {
            //両方が同時に倒れた場合
        }
        else if (!Characters[0].GetComponent<Player>().Keep_Life)
        {
            //プレイヤー1が倒れた場合
        }
        else if (!Characters[1].GetComponent<Player>().Keep_Life)
        {
            //プレイヤー2が倒れた場合
        }
    }
}
