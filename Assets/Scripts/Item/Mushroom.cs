using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : ItemBase
{
    public override string Name
    {
        get
        {
            return "mushroom";
        }
    }

    public override void UseItem()
    {
        base.UseItem();

        PlayerDataManager.Instance.SetHP(10);
    }
}
