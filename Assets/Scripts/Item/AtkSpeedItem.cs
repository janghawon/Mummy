using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSpeedItem : ItemBase
{
    public override void GiveEffect()
    {
        ItemSystem itemSystem = FindObjectOfType<ItemSystem>();
        itemSystem.AtkSpeedBuff();
    }
}
