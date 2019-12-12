using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IItem
{
    int Id { get; }

    string Name { get; }

    Sprite Image { get; }

    void OnPickup();

    void UseItem();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IItem item)
    {
        this.item = item;
    }

    public IItem item;
}

public class ItemBase : MonoBehaviour, IItem
{
    public virtual string Name
    {
        get
        {
            return "base_item";
        }
    }

    int id = 0;
    public virtual int Id
    {
        get
        {
            return id;
        }
    }
    Sprite image = null;
    public virtual Sprite Image
    {
        get
        {
            return image;
        }
        set
        {
            image = Image;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public virtual void UseItem()
    {

    }
}
