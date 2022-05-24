using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    int Pos = 1;
    public int nummenu;
    public float linewidth;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Pos != nummenu)
        {
            Vector2 tmp = this.transform.position;
            this.transform.position = new Vector2(tmp.x - linewidth, tmp.y);
            Pos += 1;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Pos != 1)
        {
            Vector2 tmp = this.transform.position;
            this.transform.position = new Vector2(tmp.x + linewidth, tmp.y);
            Pos -= 1;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            function();
        }
    }
    void function()
    {
        if (Pos == 2)
        {
            //ゲームのリトライ
            SceneManager.LoadScene("Clear");
        }
        else if (Pos == 1)
        {
            //タイトルへ
            SceneManager.LoadScene("Title");
        }

    }
}
