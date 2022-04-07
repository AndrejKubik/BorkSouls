using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("more than 1 inventory");
            return;
        }

        instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();

    public int space = 20;

    public delegate void InventoryChanged();
    public InventoryChanged inventoryChangedCallback;


    public bool AddItem(Item item)
    {
        if (!item.isDefaultItem) //if the item is a picked-up item
        {
            if(items.Count >= space) //if there is no more room in the inventory
            {
                Debug.Log("Inventory is full"); //send message
                return false; //item is not added to the inventory
            }
            items.Add(item); //add the item to the inventory list
            if (inventoryChangedCallback != null) inventoryChangedCallback.Invoke(); //if the inventory was changed, trigger a certain method
        }
        return true; //the item was added to the inventory
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item); //remove the item from the inventory list
        if (inventoryChangedCallback != null) inventoryChangedCallback.Invoke(); //if the inventory was changed, trigger a certain method
    }
}
