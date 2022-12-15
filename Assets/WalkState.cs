using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WalkState : StateMachineBehaviour
{
    public GameObject go;
    float timer;
    List <Transform> Waypoints = new List <Transform>();
    NavMeshAgent agent;
    Transform player;
    float chaseRange = 8;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();      
        timer = 0;
         go = GameObject.FindWithTag("WayPoints");
        foreach (Transform t in go.transform)
            Waypoints.Add(t);
        agent.speed = 1.5f;


        agent.SetDestination(Waypoints[Random.Range(0, Waypoints.Count)].position);


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(Waypoints[Random.Range(0, Waypoints.Count)].position);
        timer += Time.deltaTime;
        if (timer > 10)
            animator.SetBool("IsWalking", false);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange)
            animator.SetBool("IsRoling", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
