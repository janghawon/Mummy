using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageItem : ItemBase
{
    ItemSystem itemSystem;

    public override void GiveEffect()
    {
        itemSystem = FindObjectOfType<ItemSystem>();
        itemSystem.DamageBuff();
    }
}
