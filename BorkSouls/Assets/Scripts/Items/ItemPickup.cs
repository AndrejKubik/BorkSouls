using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.AddItem(item); //add the picked up item to player's inventory and trigger the pickedUp bool
        if(wasPickedUp) Destroy(gameObject); //if the item was picked up, remove the it from the scene

    }
}
