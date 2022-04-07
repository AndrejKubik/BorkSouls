using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] //make sure that unity gets a nav mesh agent every time this component is used
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;

    private void Update()
    {
        if(target != null) //if there is a target
        {
            agent.SetDestination(target.position); //set the agent's destination to the target's position
            FaceTarget(); //turn the player object towards the target object
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point); //set the agent's destination to the chosen point(in this case, where is clicked)
    }

    public void FollowTarget(Interactable newTarget)
    {
        target = newTarget.interactionTransform; //target the clicked interactable
        agent.stoppingDistance = newTarget.radius * 0.8f; //stop the player from moving too close to the target object
        agent.updateRotation = false; //freeze the player rotation
    }

    public void StopFollowingTarget()
    {
        target = null; //clear target
        agent.stoppingDistance = 0f; //remove the movement restriction
        agent.updateRotation = true; //unfreeze the player rotation
    }

    public void FaceTarget()
    {
        Vector3 lookDirection = (target.position - transform.position).normalized; //calculate the vector direction of where to the player should turn
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0f, lookDirection.z)); //calculate the target rotation using the direction vector coordinates(without Y-axis, since we dont need to turn up and down)
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime); //rotate the player object smoothly with a set speed from it's current rotation to the target rotation
    }
}
