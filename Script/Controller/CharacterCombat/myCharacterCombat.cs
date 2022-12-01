using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyCharacterStat))]
public class myCharacterCombat : MonoBehaviour
{
    MyCharacterStat myStats;
    public float attackSpeed=1f;
    private float attackCooldown=0f;
    public float attackDelay =.6f;
    
    public event System.Action OnAttack;
    
    void Start()
    {
        myStats= GetComponent<MyCharacterStat>();
    }
    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(MyCharacterStat targetStats)
    {
        if(attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            if(OnAttack!= null)
                OnAttack();
            attackCooldown = 1f/ attackSpeed;
        }
    }

    
    IEnumerator DoDamage(MyCharacterStat stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
    }

}
