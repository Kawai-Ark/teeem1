using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RogoMove : MonoBehaviour
{
    void Start()
    {
        this.transform.DOMove(new Vector2(-3.78f, 2.33f), 4f).SetDelay(1.5f);
    }
}
