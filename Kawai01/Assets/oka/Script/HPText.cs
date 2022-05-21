using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    int hp = 100;

    int cocnt = 0;

    int dacnt = 0;

    public Text hptext;

    Image coution;
    Image danger;
    Image death;

    void Start()
    {

        hptext.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        coution = GameObject.Find("COUTION").GetComponent<Image>();
        coution.enabled = false;

        danger = GameObject.Find("DANGER").GetComponent<Image>();
        danger.enabled = false;

        death = GameObject.Find("DEATH").GetComponent<Image>();
        death.enabled = false;
    }

    public void TakeHP(int h)
    {
        if (hp > 0)
        {
            hp -= h;
        }
        
        if (hp <= 0) 
        {
            hp = 0;
        }

        if (hp > 50)
        {
            coution.enabled = false;
            danger.enabled = false;
            death.enabled = false;
        }

        if (hp <= 50 && hp > 20)
        {
            hptext.color = new Color(1.0f, 0.92f, 0.016f, 1.0f);

            coution.enabled = true;
            danger.enabled = false;
        }
        else if (hp <= 20 && hp > 0) 
        {
            hptext.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            coution.enabled = false;
            danger.enabled = true;
            
        }else if (hp <= 0)
        {
            hptext.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            coution.enabled = false;
            danger.enabled = false;
            death.enabled = true;
        }
    }

    void Update()
    {
        if(hp <= 50 && hp > 20)
        {
            cocnt++;

            if (cocnt <= 60 * 10)
            {
                coution.enabled = true;
            }
            else
            {
                coution.enabled = false;
                if (cocnt >= 60 * 24)
                {
                    cocnt = 0;
                }
            }
        }

        if (hp <= 20 && hp > 0)
        {
            cocnt = 0;
            dacnt++;

            if (dacnt <= 60 * 2)
            {
                danger.enabled = true;
            }
            else
            {
                danger.enabled = false;
                if (dacnt >= 60 * 4)
                {
                    dacnt = 0;
                }
            }
        }

        Debug.Log(cocnt);
        hptext.text = hp.ToString();
    }
}
