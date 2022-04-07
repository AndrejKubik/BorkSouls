using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stat damage;
    public Stat armor;

    public Animator animator;
    public string animation;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.T))
        //{
        //    TakeDamage(10);
        //}
    }
    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue(); //subtract the armor value from the damage value, to lessen the damage taken
        damage = Mathf.Clamp(damage, 0, int.MaxValue); //keep the damage from going bellow 0 so that the character doesn't heal instead when armor value is greater than the damage taken value

        currentHealth -= damage; //subtract the damage value from current hp
        Debug.Log(transform.name + " takes " + damage + " damage! Current HP = " + currentHealth);

        if (currentHealth <= 0) Death(); //when the character hp goes to 0 or bellow, the character dies
    }

    public virtual void Death()
    {
        animator.Play(animation);
    }
}
