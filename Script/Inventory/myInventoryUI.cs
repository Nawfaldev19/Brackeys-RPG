using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myInventoryUI : MonoBehaviour
{
    MyInventory inventory;
    public Transform itemParent;
    MyInventorySlot[] slots;
    [SerializeField]
    GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        inventory=MyInventory.instance;
        inventory.onItemChangedCallback += UpdateUI;//connection between myINventory and myInventoryUI
        //myInventory is parent in connection
        slots=itemParent.GetComponentsInChildren<MyInventorySlot>();
    }

    void Update()
    {
        PopUpAndDownInventory();
    }

    void PopUpAndDownInventory()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()// the changes I'll do in myInventory-> changes will occur in InventoryUI
    {
        for(int i=0;i<slots.Length;i++)
        {
            if(i<inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            } 
            else slots[i].RemoveItem();
        }
        Debug.Log("Updating UI *chira");
    }

}
