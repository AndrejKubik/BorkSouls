using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    Combat combat;

    CharacterStats enemyStats;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        enemyStats = GetComponent<CharacterStats>();
    }
    public override void Interact()
    {
        base.Interact();
        combat = playerManager.player.GetComponent<Combat>();

        if(combat != null)
        {
            combat.Attack(enemyStats);
        }
    }
}
