using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerStats : MyCharacterStat
{
    // Start is called before the first frame update
    void Start()
    {
        MyEquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }
    
    // public override void
    public override void Die()
    {
        base.Die();
        //Kill the Player
        myPlayerManager.instance.KillPlayer();
    }
    
    void OnEquipmentChanged(myEquipment newItem, myEquipment oldItem)
    {
        Debug.Log("OEC");
        if(newItem!= null){
            Debug.Log("newItem in");
            armor.AddModifier(newItem.armorModifier);  
            damage.AddModifier(newItem.damageModifier);
        }
        if(oldItem !=null)
        {
            Debug.Log("odlItem in");
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }
}
