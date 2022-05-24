using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{
    void Start()
    {
        this.transform.DOMove(new Vector2(3f, 1f), 0.5f);
    }

    void Update()
    {
        
    }
}
