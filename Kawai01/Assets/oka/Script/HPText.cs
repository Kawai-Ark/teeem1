using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    int hp = 100;

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
        hptext.text = hp.ToString();
    }
}
