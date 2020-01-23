using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coin", menuName = "Create Item/Coin")]
public class Coin : ItemTs
{
    public override void UseItem()
    {
        //base.UseItem();
        Debug.Log("Swinging Sword!");
    }

    public override void PickUp()
    {
        base.PickUp();
    }
}