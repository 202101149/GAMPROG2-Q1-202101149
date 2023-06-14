using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private ItemData itemData;
    public Image itemIcon;

    public void SetItem(ItemData data)
    {
        // TODO
        // Set the item data the and icons here
        itemData = data;
        itemIcon.sprite = data.icon;
        itemIcon.enabled = true;
    }

    public void UseItem()
    {
        // TODO
        // Reset the item data and the icons here
        EventSystem.current.SetSelectedGameObject(null);
        
        if(itemData.type == ItemType.Consumable)
        {
            InventoryManager.Instance.UseItem(itemData);
            itemIcon.sprite = null;
            itemIcon.enabled = false;
            itemData = null;
        }
        if (itemData.type == ItemType.Equipabble && InventoryManager.Instance.GetEquipmentSlot(itemData.slotType) != -1)
        {
            InventoryManager.Instance.UseItem(itemData);
            itemIcon.sprite = null;
            itemIcon.enabled = false;
            itemData = null;
        }
        if (itemData.type == ItemType.StoryItems)
        {
            itemIcon.sprite = null;
            itemIcon.enabled = false;
            itemData = null;
        }
    }

    public string getId()
    {
        if (itemData == null)
        {
            return null;
        }
        else
        {
            return itemData.id;
        }
        
    }

    public bool HasItem()
    {
        return itemData != null;
    }
}
