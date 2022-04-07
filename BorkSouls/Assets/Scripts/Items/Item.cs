using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public int itemEquipTrigger;
    public PlayerItemChange playerItemChange;

    public virtual void Use()
    {
        playerItemChange = FindObjectOfType<PlayerItemChange>(); //find the player object for the script
        Debug.Log("Using " + name); //send message of the item name being used
        playerItemChange.equipTrigger = itemEquipTrigger;
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.RemoveItem(this); //remove the current item from the inventory
    }
}
