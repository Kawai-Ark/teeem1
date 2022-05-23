using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Game()
    {
        //トラップの設置
        GameObject[] Characters = GameObject.FindGameObjectsWithTag("Player");
        if (Characters[0].GetComponent<Player_R>().m_Life <= 0)
            Characters[0].GetComponent<Player_R>().Keep_Life = false;
        Characters[0].GetComponent<Player_R>().Sousa();
        if (!Characters[0].GetComponent<Player_R>().Keep_Life)
            GameKeeper.GameEnd = true;
    }
}
