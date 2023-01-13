using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDamItem : ItemBase
{
    
    public override void GiveEffect()
    {
        ItemSystem item = FindObjectOfType<ItemSystem>();
        item.DotDamBuff();
    }
    
}
