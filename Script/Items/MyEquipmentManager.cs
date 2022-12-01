using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEquipmentManager : MonoBehaviour
{
    #region Singleton
    public static MyEquipmentManager instance;
    void Awake()
    {
        instance=this;
    }
#endregion

    public delegate void OnEquipmentChanged(myEquipment newItem,myEquipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    myEquipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;
    MyInventory inventorySystem;
    public SkinnedMeshRenderer targetMesh;
    public myEquipment[] defaultItems;

    void Start()
    {
        inventorySystem=MyInventory.instance;

        int numSlots = System.Enum.GetNames(typeof(MyEquipmentSlot)).Length;
        currentEquipment = new myEquipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
        EquipDefaultItems();
    }

    public void Equip(myEquipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        myEquipment oldItem=UnEquip(slotIndex);
        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem,oldItem);
        }
        SetEquipmentBlendShapes(newItem,100);

        currentEquipment[slotIndex]=newItem;
        SkinnedMeshRenderer newMesh=Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones=targetMesh.bones;
        newMesh.rootBone=targetMesh.rootBone;
        currentMeshes[slotIndex]=newMesh;  
        Debug.Log("Emanager: Equip");
               
    }

    void SetEquipmentBlendShapes(myEquipment item, int weight)
    {
        foreach(MyEquipmentMeshRegion blendShape in item.coveredMeshRegion)
        {
            Debug.Log(blendShape.ToString());
            targetMesh.SetBlendShapeWeight((int)blendShape, weight);
            // Debug.Log("IN BLEND SHAPES:"+ targetMesh.GetBlendShapeWeight((int)blendShape));

        }
    }

    void EquipDefaultItems()
    {
        foreach(myEquipment item in defaultItems)
        {
            // Debug.Log(item.name);
            Equip(item);
        }
    }

    public myEquipment UnEquip(int slotIndex)
    {
        if(currentEquipment[slotIndex]!=null)
        {
            if(currentMeshes[slotIndex]!=null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            myEquipment oldItem=currentEquipment[slotIndex];
            SetEquipmentBlendShapes(oldItem,0);
            inventorySystem.AddAndIsAdd(oldItem);
            
            currentEquipment[slotIndex]=null;

            if(onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null,oldItem);
            }
            return oldItem;
        }
        return null;
    }

    public void UnEquipAll()
    {
        for(int i=0;i<currentEquipment.Length;i++)
        {
            UnEquip(i);
        }
        EquipDefaultItems();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnEquipAll();
        }
    }

}
