using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bikkuri : MonoBehaviour
{
    public GameObject BikkuriObject;
    void Start()
    {
        BikkuriObject.SetActive(false);
        StartCoroutine("BikkuriAppear");
    }
    IEnumerator BikkuriAppear()
    {
        yield return new WaitForSeconds(0.8f);
        BikkuriObject.SetActive(true);
    }

    void Update()
    {
        
    }
}
