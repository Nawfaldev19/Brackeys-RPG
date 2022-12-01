using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class myEnemyController : MonoBehaviour
{
    public float lookRadius=10f; 
    Transform target;
    NavMeshAgent agent;
    [SerializeField]
    float rotationSmoothness=5f;
    myCharacterCombat combat;

    // Start is called before the first frame update
    void Start()
    {
        target=myPlayerManager.instance.playerInstance.transform;
        agent= GetComponent<NavMeshAgent>();
        combat = GetComponent<myCharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovementToPlayer();
    }

    void EnemyMovementToPlayer()
    {
        float distanceBetweenPlayer= Vector3.Distance(target.position,transform.position);
        if(distanceBetweenPlayer<=lookRadius)
        {
            agent.updateRotation=false;
            FaceTarget();
            agent.SetDestination(target.position);
            if(distanceBetweenPlayer<= agent.stoppingDistance)// its close enough to interact
            {
                MyCharacterStat targetCombatStats=target.GetComponent<MyCharacterStat>();
                if(targetCombatStats!=null)
                {
                    combat.Attack(targetCombatStats);
                    // attack the player--------------------------
                }
            }
        }
        else
            agent.updateRotation=true;
    }

    void FaceTarget()
    {
        // transform.LookAt(new Vector3(target.position.x,0,target.position.z),Vector3.up);
        Vector3 direction= (transform.position- target.position).normalized;
        Quaternion lookRotation= Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation= Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*rotationSmoothness);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);    
    }

}
