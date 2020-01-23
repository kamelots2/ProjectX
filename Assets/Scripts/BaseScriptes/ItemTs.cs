using UnityEngine;

public class ItemTs : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject item = null;
    public int count = 0;

    public virtual void UseItem()
    {
        Debug.Log("Using " + name);
    }

    public virtual void PickUp() { count++; }
}
