using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Image image;

    private Player player;
    
     

    void Start()
    {
        
    }

    public void GaugeReduction(float reducationValue)
    {
        var valueTo = (player.playerHP - reducationValue) / player.playermaxHP;

        image.fillAmount = valueTo;
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}
