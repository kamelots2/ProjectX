using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Transform itemBG = transform.Find("IItemBG").Find("ItemGroup");
        foreach(Transform slot in itemBG)
        {
            Image img = slot.GetChild(0).GetComponent<Image>();
            if(!img.sprite)
            {
                img.enabled = true;
                img.sprite = e.item.Image;

                break;
            }
        }
    }
}
