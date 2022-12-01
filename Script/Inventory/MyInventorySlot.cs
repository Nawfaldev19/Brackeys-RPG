using UnityEngine;
using UnityEngine.UI;

public class MyInventorySlot : MonoBehaviour
{
    myItem item;
    [SerializeField]
    Image icon;
    [SerializeField]
    Button removeButton;

    public void AddItem(myItem itemToAdd)
    {
        item=itemToAdd;
        icon.sprite=item.icon;
        icon.enabled=true;
        removeButton.interactable=true;
    }

    public void RemoveItem()
    {
        if(item==null)
        {
            // Debug.Log("inventory-remove");
            return;
        }

        item=null;
        icon.enabled=false;
        icon.sprite=null;
        removeButton.interactable=false;

    }

    public void OnPressRemoveButton()
    {
        MyInventory.instance.RemoveItem(item);
    }
    
    public void UseItem()
    {
        if(item!=null)
        {
            item.Use();
        }
    }
}
