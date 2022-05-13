using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReplay : MonoBehaviour
{
    GameObject enemy;

    void Start()
    {
        enemy = GameObject.Find("Enemy");
    }

    void Update()
    {
        if (enemy.gameObject == null)
        {
           // Instantiate(enemy.gameObject);
        }
    }
}
