using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;

    [SerializeField] private Transform itemsParent;
    InventorySlot[] slots;

    [SerializeField] private GameObject inventoryUI;

    private void Start()
    {
        inventory = Inventory.instance; //store the inventory instance into a variable
        inventory.inventoryChangedCallback += UpdateUI; //when inventory changes call the UpdateUI method

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //put all inventory slots in the slots array
    }

    private void Update()
    {
        if(Input.GetButtonDown("Inventory")) //when inventory button is pressed
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf); //switch inventory UI on/off
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++) //loop through every item slot
        {
            if(i < inventory.items.Count) //if there is room in the inventory
            {
                slots[i].AddItem(inventory.items[i]); //add the picked-up item and store it in the current inventory slot
            }
            else
            {
                slots[i].ClearSlot(); //clear out the current item slot
            }
        }
    }
}
