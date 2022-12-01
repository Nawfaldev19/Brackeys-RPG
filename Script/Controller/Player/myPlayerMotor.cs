using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class myPlayerMotor : MonoBehaviour
{

    NavMeshAgent agent;
    [Header("Follow")]
    [SerializeField]
    float delayForFollowing=.5f;
    [SerializeField]
    float nearFollowObj=.8f;
    [SerializeField]
    float targetFollowRotationSpeed=.5f;
    Transform targetTransform;
    
    void Awake()
    {
        agent=GetComponent<NavMeshAgent>();
    }

    public void MovePlayerPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }    

    public float GetDistanceOfNavAgent()//getter func for nav.distance used in myinteractable
    {
        return agent.remainingDistance;
    }


    #region PursuitTarget

    void FaceTarget()//Direction,quaternion->rotation
    {
        Vector3 direction= (targetTransform.position-transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,targetFollowRotationSpeed*Time.deltaTime);
    }

    public void StartPursuit()//rotation False//StartCoroutine
    {
        targetTransform = MyPlayerController.instance.focus.GetComponent<myInteractable>().interactionTransform;
        agent.stoppingDistance = MyPlayerController.instance.focus.GetComponent<myInteractable>().radius * nearFollowObj ;
        agent.updateRotation = false;
        StartCoroutine(FollowPlayerCycle());
    }

    public void StopPursuitObj()//rotation true//StopCoroutine
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        StopCoroutine(FollowPlayerCycle());
    }
    IEnumerator FollowPlayerCycle()//Facetarget()-SetDestination
    {
        while(true)
        {
            if(MyPlayerController.instance.focus!=null)
            {
                FaceTarget();
                MovePlayerPoint(targetTransform.position);
            }
            else break;
            yield return new WaitForSeconds(delayForFollowing);
        }
    }
    #endregion PursuitTarget

}
