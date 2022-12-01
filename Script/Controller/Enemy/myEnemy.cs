using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyCharacterStat))]
public class myEnemy : myInteractable
{
    myPlayerManager playerManager;
    MyCharacterStat myStats;
    
    void Start()
    {
        playerManager=myPlayerManager.instance;
        myStats=GetComponent<MyCharacterStat>();
    }
 
    public override void Interact()
    {
        base.Interact();
        // Debug.Log("interaction Happened of :"+ gameObject.name);
        myCharacterCombat playerCombat = playerManager.playerInstance.GetComponent<myCharacterCombat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);//enemy recieves damage in this
        }
        // Attack the enemy
    }
}
