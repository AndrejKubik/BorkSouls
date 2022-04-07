using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float lookRadius = 10f;
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private float distance;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Quaternion lookRotation;

    Combat combat;
    CharacterStats targetStats;
    PlayerManager playerManager;
    [SerializeField] private EnemyStats enemyStats;

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        combat = GetComponent<Combat>();
        playerManager = PlayerManager.instance;
    }

    private void Update()
    {
        distance = Vector3.Distance(target.position, transform.position); //calculate the distance from the enemy to it's target(player)

        if(distance <= lookRadius && !enemyStats.isDead) //when the player enters the enemy look radius
        {
            playerManager.musicStart = true; //trigger the music start

            agent.SetDestination(target.position); //move the enemy towards the target(player)

            if(distance <= agent.stoppingDistance)
            {
                targetStats = target.GetComponent<CharacterStats>(); //find target's stats

                if(targetStats != null) //if there are stats found
                {
                    combat.Attack(targetStats); //commence the attack onto the target
                }

                FaceTarget(); //look towards the player
            }
        }
    }

    void FaceTarget()
    {
        direction = (target.position - transform.position).normalized; //calculate the turn direction vector
        lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); //use the vector to make a quaternion to actually rotate
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); //smoothly change the rotation towards the target
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
