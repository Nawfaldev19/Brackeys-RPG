using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInventory : MonoBehaviour
{

    [SerializeField]
    int spaceCapacity=20;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    #region Singleton
    public static MyInventory instance;
    void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance=this;        
    }
    #endregion

    public List<myItem> items= new List<myItem>();
    public bool AddAndIsAdd(myItem  item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count>=spaceCapacity)
            {
                Debug.Log("the space is full");
                return false;
            }
            items.Add(item);
            if(onItemChangedCallback!=null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void RemoveItem(myItem item)
    {
        Debug.Log("remove");
        items.Remove(item);
        if(onItemChangedCallback!=null)
            onItemChangedCallback.Invoke();

    }

}
