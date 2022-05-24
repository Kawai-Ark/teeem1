using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class kaiten : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOLocalRotate(new Vector2(0,360f), 2f, RotateMode.FastBeyond360)
    .SetEase(Ease.Linear)
    .SetLoops(-1, LoopType.Restart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
