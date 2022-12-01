using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEquipment", menuName ="Inventory/Equipment")]
public class myEquipment : myItem
{
    public MyEquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public MyEquipmentMeshRegion[] coveredMeshRegion;
    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        // Debug.Log("myequipment");
        MyEquipmentManager.instance.Equip(this);
        //remove it from inventory
        RemoveFromInventory();
    }


}

public enum MyEquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet}
public enum MyEquipmentMeshRegion{ Legs, Arms,Torso};