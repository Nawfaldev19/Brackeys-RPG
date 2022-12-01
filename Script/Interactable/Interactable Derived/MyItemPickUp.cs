using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyItemPickUp : myInteractable
{
    public myItem item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Pick the item Up" + item.name);
        if(MyInventory.instance.AddAndIsAdd(item))//add to inventory and checks if it can be picked up
        {
            Destroy(gameObject);
        }
        //after picking up
    }


}
