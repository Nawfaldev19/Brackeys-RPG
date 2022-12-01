using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterStat : MonoBehaviour
{
    public int maxHealth=100;
    public int currentHealth { get; private set;}

    public MyStat damage;
    public MyStat armor;

    void Awake()
    {
        currentHealth = maxHealth;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage,0,int.MaxValue);

        currentHealth-= damage;
        Debug.Log(transform.name +" damage hit:"+ damage.ToString()+" current Health:"+ currentHealth.ToString());
        if(currentHealth <= 0)
        {
            Debug.Log("character has died");
            Die();
        }
    }

    public virtual void Die()
    {
        // die in some way
        // This method is meant to bve overwritten
        Debug.Log(transform.name+ "has died.");
    
    }


}
