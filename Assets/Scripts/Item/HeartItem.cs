using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : ItemBase
{
    public float playerFutureHP = 0;
    public override void GiveEffect()
    {
        
        playerFutureHP = playerHP.playerCurrentHP += 50;
        if (playerFutureHP > 100)
        {
            playerHP.playerCurrentHP = 100;
        }
        else
        {
            playerHP.playerCurrentHP += 50;
        }
        
    }
}
