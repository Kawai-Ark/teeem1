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
        //�ǂ��炪��������
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
            //�����������ɓ|�ꂽ�ꍇ
        }
        else if (!Characters[0].GetComponent<Player>().Keep_Life)
        {
            //�v���C���[1���|�ꂽ�ꍇ
        }
        else if (!Characters[1].GetComponent<Player>().Keep_Life)
        {
            //�v���C���[2���|�ꂽ�ꍇ
        }
    }
}
