using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;

    #region Singleton
    private void Awake()
    {
        instance = this;
    }
    #endregion
    Inventory inventory;
    Equipment currentItem;
    [SerializeField] private Equipment[] currentEquipment;
    [SerializeField] private int numberOfSlots;
    private int slotIndex;

    public delegate void EquipmentChanged(Equipment newItem, Equipment currentItem);
    public EquipmentChanged equipmentChanged;

    private void Start()
    {
        inventory = Inventory.instance;
        numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length; //get the total number of equipment slots
        currentEquipment = new Equipment[numberOfSlots]; //initialize an empty inventory
    }

    public void Equip(Equipment newItem)
    {
        slotIndex = (int)newItem.equipSlot; //store the EquipmentSlot enum index of the item
        
        currentItem = null; //clear the current item variable

        if(currentEquipment[slotIndex] != null) //if something is currently equipped on the needed slot
        {
            currentItem = currentEquipment[slotIndex]; //store the currently equipped item
            inventory.AddItem(currentItem); //put the currently equipped item back to the inventory
        }

        if(equipmentChanged != null) //when there was a change in the equipment
        {
            equipmentChanged.Invoke(newItem, currentItem); //call the according methods for the item change
        }

        currentEquipment[slotIndex] = newItem; //swap the item from the [slotIndex] equipment slot to the newly equipped item
    }

    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null) //if the chosen slot for unequipping is not enmpty
        {
            currentItem = currentEquipment[slotIndex]; //store the currently equipped item
            inventory.AddItem(currentItem); //put the currently equipped item back to the inventory
            currentEquipment[slotIndex] = null; //clear the equipment slot

            if (equipmentChanged != null) //when there was a change in the equipment
            {
                equipmentChanged.Invoke(null, currentItem); //call the according methods for the item change
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++) //for every equipment slot
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}
