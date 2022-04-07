using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] private CharacterAnimation characterAnimation;
    public bool isDead;

    public override void Death()
    {
        base.Death();
        StartCoroutine(DestroyEnemyObject(2.5f));
        Debug.Log(gameObject.name + " has died!");
    }

    IEnumerator DestroyEnemyObject(float delay)
    {
        isDead = true;
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
