using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    int hp = 100;

    public Text hptext;



    void Start()
    {
        hptext.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    }

    public void TakeHP(int h)
    {
        if (hp > 0)
        {
            hp -= h;
        }

        if (hp <= 50 && hp > 20)  
        {
            hptext.color = new Color(1.0f, 0.92f, 0.016f, 1.0f);
        }
        else if (hp <= 20 && hp > 0)
        {
            hptext.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    void Update()
    {
        hptext.text = hp.ToString();
    }
}
