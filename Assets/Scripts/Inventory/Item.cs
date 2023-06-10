using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public override void Interact()
    {
        // TODO: Add the item to the inventory. Make sure to destroy the prefab once the item is collected
        Debug.Log(id + " is an interactable object");

        //check if inventory slot is available
        //InventoryManager.Instance.AddItem(id);
        Debug.Log(InventoryManager.Instance.GetEmptyInventorySlot());

        //if empty slot is available, put in inventory and destroy


        //else return debug inventory full
        //Destroy(gameObject);
    }
}
