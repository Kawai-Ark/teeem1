using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;

    private string playerTag = "Player";

    GameObject scoreob;

    void Start()
    {
        scoreob = GameObject.Find("ScoreText");
    }

    void Update()
    {
        Vector2 pos = transform.position;

        pos.x += 1;

        transform.position = pos;

    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == playerTag)
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "ScreenŠO")
        {
            scoreob.GetComponent<ScoreText>().AddScore();
            Destroy(this.gameObject);
        }
    }
}
