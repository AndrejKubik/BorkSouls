using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Combat : MonoBehaviour
{
    private CharacterStats attackerStats;
    [SerializeField] private CharacterAnimation characterAnimation;

    public float attackSpeed = 1f;
    private float attackCooldown = 0;
    public float attackAnimationDelay;

    public event System.Action Attacked;

    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip attackSound1;
    [SerializeField] private AudioClip attackSound2;

    private int randomSound;

    private void Start()
    {
        attackerStats = GetComponent<CharacterStats>();
    }

    public void Attack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0 && targetStats.currentHealth >= 0) //if attack cooldown has passed and the target is not dead
        {
            randomSound = Random.Range(1, 3); //get random int for attack sound randomization
            characterAnimation.isAttacking = true;
            StartCoroutine(DoDamageAfter(targetStats, attackAnimationDelay));
            attackCooldown = 1f / attackSpeed; //reset the attack cooldown and calculate it again considering the attack speed value (higher attack speed = less cooldown)

            if(Attacked != null)
            {
                Attacked();
            }
        }
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    IEnumerator DoDamageAfter(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay); //ayo hol up!

        if (randomSound == 1) audio.PlayOneShot(attackSound1);
        else if (randomSound == 2) audio.PlayOneShot(attackSound2);

        stats.TakeDamage(attackerStats.damage.GetValue()); //the target takes damage based on the attacker's damage stat
    }
}
