using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName ="Inventory/Item")]
public class myItem : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    
    public virtual void Use()
    {
        // use the item
        // something will happen
        // Debug.Log("Script: myItem, use item"+ name);
    }

    public void RemoveFromInventory()
    {
        MyInventory.instance.RemoveItem(this);

    }


}
 