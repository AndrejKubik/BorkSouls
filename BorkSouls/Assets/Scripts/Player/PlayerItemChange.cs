using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemChange : MonoBehaviour
{
    public bool swordEquipped;
    [SerializeField] private GameObject sword;

    public bool shieldEquipped;
    [SerializeField] private GameObject shield;

    public int equipTrigger;

    private void Update()
    {
        if (equipTrigger == 1)
        {
            swordEquipped = !swordEquipped;
            equipTrigger = 0;
        }
        if (equipTrigger == 2)
        {
            shieldEquipped = !shieldEquipped;
            equipTrigger = 0;
        }

        if (swordEquipped) sword.SetActive(true);
        else sword.SetActive(false);

        if (shieldEquipped) shield.SetActive(true);
        else shield.SetActive(false);
    }
}
