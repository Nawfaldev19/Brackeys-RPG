using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyCharacterAnimator : MonoBehaviour
{
    [SerializeField]
    float smoothingRunToWalk=.1f;
    NavMeshAgent agent;
    Animator animator;
    
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        animator=GetComponentInChildren<Animator>();
    }

    void MotionRunToWalk()
    {
        float speedPercent = agent.velocity.magnitude/agent.speed;
        animator.SetFloat("speedPercent",speedPercent,smoothingRunToWalk,Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        MotionRunToWalk();
    }
}
