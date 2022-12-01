using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myEnemyStats : MyCharacterStat
{

    public override void Die()
    {
        base.Die();
        // ADD RAGDOLL EFFECT/ add death animation
        Destroy(gameObject);
    }

}
