using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Player player;
    //For now, this will store information of the Items that can be added to the inventory
    public List<ItemData> itemDatabase;

    //Store all the inventory slots in the scene here
    public List<InventorySlot> inventorySlots;

    //Store all the equipment slots in the scene here
    public List<EquipmentSlot> equipmentSlots;

    //Singleton implementation. Do not change anything within this region.
    #region SingletonImplementation
    private static InventoryManager instance = null;
    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "Inventory";
                    instance = go.AddComponent<InventoryManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public void UseItem(ItemData data)
    {
        // TODO
        // If the item is a consumable, simply add the attributes of the item to the player.
        // If it is equippable, get the equipment slot that matches the item's slot.
        // Set the equipment slot's item as that of the used item

        //consumable
        if(data.type == ItemType.Consumable)
        {
            player.AddAttributes(data.attributes);
        }

        if(data.type == ItemType.Equipabble)
        {
            equipmentSlots[GetEquipmentSlot(data.slotType)].SetItem(data);
            player.AddAttributes(data.attributes);
        }
    }

   
    public void AddItem(string itemID)
    {
        //TODO
        //1. Cycle through every item in the database until you find the item with the same id.
        //2. Get the index of the InventorySlot that does not have any Item and set its Item to the Item found
        int idbArray = -1;
        for (int x = 0; x < itemDatabase.Count; x++)
        {
            if (itemDatabase[x].id == itemID)
            {
                idbArray = x;
                break;
            }
        }
        inventorySlots[GetEmptyInventorySlot()].SetItem(itemDatabase[idbArray]);
    }

    public int GetEmptyInventorySlot()
    {
        //TODO
        //Check which inventory slot doesn't have an Item and return its index
        int slot = -1;
        for (int x = 0; x < inventorySlots.Count; x++)
        {
            if (!inventorySlots[x].HasItem())
            {
                slot = x;
                break;
            }
        }
        Debug.Log(slot + 1 + " in the inventory");
        return slot;
    }

    public int GetEquipmentSlot(EquipmentSlotType type)
    {
        //TODO
        //Check which equipment slot matches the slot type and return its index
        int eSlot = -1;
        for (int x = 0; x < equipmentSlots.Count; x++)
        {
            if (equipmentSlots[x].type == type)
            {
                if (!equipmentSlots[x].HasItem())
                {
                    eSlot = x;
                    break;
                }
            }
        }
        return eSlot;
    }
}
