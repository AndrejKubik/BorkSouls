using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Slider playerHPBar;
    public Slider bossHPBar;

    CharacterStats playerStats;
    CharacterStats bossStats;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject boss;

    private void Update()
    {
        playerStats = player.GetComponent<CharacterStats>();
        playerHPBar.value = playerStats.currentHealth;

        if(boss.gameObject != null)
        {
            bossStats = boss.GetComponent<CharacterStats>();
            bossHPBar.value = bossStats.currentHealth;
        }
    }
}
