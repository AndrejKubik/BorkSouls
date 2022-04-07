using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float smoothingFactor = 0.1f;
    private Combat combat;

    public bool isAttacking;
    public bool attackEnded;
    private int randomAnim;

    private void Start()
    {
        combat = GetComponent<Combat>();
    }


    private void Update()
    {
        movementSpeed = agent.velocity.magnitude / agent.speed; //calculate the player's speed by dividing his current speed with maximum speed
        animator.SetFloat("MovementSpeed", movementSpeed, smoothingFactor, Time.deltaTime); //change the actual value of player's movement speed in the animator smoothly over time

        if(isAttacking) //if an attack is starting
        {
            combat.attackAnimationDelay = 0.394f; //wait for the attack animation to connect
            randomAnim = Random.Range(1, 3); //choose a random attack animation
            if (randomAnim == 1) animator.Play("Attack01");
            else if (randomAnim == 2) animator.Play("Attack02");

            isAttacking = false; //reset the attack animation trigger
        }
    }
}
