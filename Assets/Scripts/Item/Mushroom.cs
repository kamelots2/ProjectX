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

    public override Sprite Image {
        get => base.Image;
        set => base.Image = value;
    }

    public override void UseItem()
    {
        base.UseItem();

        PlayerDataManager.Instance.SetHP(10);
    }
}
