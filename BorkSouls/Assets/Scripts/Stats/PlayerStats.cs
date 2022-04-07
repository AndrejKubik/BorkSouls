using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    [SerializeField] private CharacterAnimation characterAnimation;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private GameObject deathScreen;
    private void Start()
    {
        EquipmentManager.instance.equipmentChanged += EquipmentChanged;
    }

    public void EquipmentChanged(Equipment newItem, Equipment currentItem)
    {
        if(newItem != null) //if there is a new item being equipped
        {
            armor.AddModifier(newItem.armorModifier); //add it's armor modifier
            damage.AddModifier(newItem.damageModifier); //add it's damage modifier
        }

        if(currentItem != null) //if there was an item equipped
        {
            armor.RemoveModifier(currentItem.armorModifier); //remove it's armor modifier
            damage.RemoveModifier(currentItem.damageModifier); //remove it's damage modifier
        }
    }

    public override void Death()
    {
        base.Death();
        StartCoroutine(PlayPlayerDeath(deathSound.length));
    }

    IEnumerator PlayPlayerDeath(float delay)
    {
        deathScreen.SetActive(true);
        audio.PlayOneShot(deathSound, 1f);

        yield return new WaitForSeconds(delay);
        PlayerManager.instance.KillPlayer();
    }
}
