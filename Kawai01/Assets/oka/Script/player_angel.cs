using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_angel : MonoBehaviour
{
    GameObject player;

    //float posY = 0.0f;

    Image bone;

    float speed = 0.2f;

    void Start()
    {
        player = GameObject.Find("player");

        bone = GameObject.Find("Bone").GetComponent<Image>();
    }

    void Update()
    {

        Vector2 pos = transform.position;

        pos.y += speed;

        transform.position = pos;

        
    }
}
