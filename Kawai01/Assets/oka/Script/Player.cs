using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private string enemyTag = "Enemy";

    int speed = 97;

    float a = 0;

    public float playerHP;
    public float playermaxHP;

    protected HP hpgauge;

    Image bone;

    Image player_angel;

    GameObject scoreobj;

    GameObject hpobj;

    public Animator anim;

    void Start()
    {
        hpgauge = GameObject.FindObjectOfType<HP>();

        hpgauge.SetPlayer(this);

        scoreobj = GameObject.Find("ScoreText");

        hpobj = GameObject.Find("HPtext");

        bone = GameObject.Find("Bone").GetComponent<Image>();

        player_angel = GameObject.Find("player angel").GetComponent<Image>();

        player_angel.enabled = false;

        bone.enabled = false;
    }

    void Update()
    {
        Vector2 pos = transform.position;
        
        a++;
        if (a == 1)
        {
            anim.SetBool("Down", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("Down", false);
            anim.SetBool("Left", true);
            anim.SetBool("Right", false);
            anim.SetBool("Up", false);
            //this.transform.Translate(-97, 0, 0);
             pos.x -= speed;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("Down", false);
            anim.SetBool("Right", true);
            anim.SetBool("Left", false);
            anim.SetBool("Up", false);
           // this.transform.Translate(97, 0, 0);
            pos.x += speed;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("Down", false);
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
            anim.SetBool("Up", true);
           // this.transform.Translate(0, 97, 0);
            pos.y += speed;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
            anim.SetBool("Down", true);
            anim.SetBool("Up", false);
            //this.transform.Translate(0, -97, 0);
             pos.y -= speed;
        }

        bone.transform.position = pos;

        player_angel.transform.position = pos;
   
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            Damage(100);

            scoreobj.GetComponent<ScoreText>().TakeScore();

            hpobj.GetComponent<HPText>().TakeHP(100);

            if (playerHP <= 0)
            {
                bone.enabled = true;
                player_angel.enabled = true;
                playerHP = 0;
                Destroy(this.gameObject);
            }
            //Debug.Log(playerHP);
        }
    }

    public void Damage(float power)
    {
        hpgauge.GaugeReduction(power);
        playerHP -= power;
    }
}
