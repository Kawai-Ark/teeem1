using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Sprite gameover;
    public Image image;

    GameObject playerobj;

    void Start()
    {
        image = GameObject.Find("Image").GetComponent<Image>();
        image.enabled = false;

        playerobj = GameObject.Find("player");
    }

    void Update()
    {
        if (playerobj == null)
        {
            image.enabled = true;
            image.sprite = gameover;
        }
    }
}
