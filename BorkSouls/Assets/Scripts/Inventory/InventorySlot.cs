using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Item item;
    public Image icon;

    [SerializeField] private Button removeButton;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
    }

    public void DropItem()
    {
        Inventory.instance.RemoveItem(item); //remove the item from the inventory
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
