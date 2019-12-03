using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    private const int SLOTS = 24;
    private List<IItem> lItems = new List<IItem>();
    public event EventHandler<InventoryEventArgs> addItem;

    public void AddItem(IItem item)
    {
        if(lItems.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            item.OnPickup();

            lItems.Add(item);
            if (addItem != null)
                addItem(this, new InventoryEventArgs(item));
        }
    }
}
