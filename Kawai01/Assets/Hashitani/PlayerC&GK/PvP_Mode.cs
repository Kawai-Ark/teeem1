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
        //Ç«ÇøÇÁÇ™èüÇ¡ÇΩÇ©
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject tPlayer in Players)
        {
            if (tPlayer.GetComponent<Player_R>().m_Life <= 0)
            {
                tPlayer.GetComponent<Player_R>().Keep_Life = false;
                GameKeeper.GameEnd = true;
            }
            else tPlayer.GetComponent<Player_R>().Sousa();
        }
    }
}
