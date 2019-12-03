using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWindow : BaseWindow
{
    public ItemInventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory.addItem += ItemAdded;
    }

    public override void ShowWindow()
    {
        base.ShowWindow();
    }


    public override void HideWindow()
    {
        base.HideWindow();
    }

    private void ItemAdded(object sender, InventoryEventArgs e)
    {
        
    }
}
