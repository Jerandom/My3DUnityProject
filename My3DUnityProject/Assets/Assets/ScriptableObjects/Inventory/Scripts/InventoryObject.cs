using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InvetorySlot> InventoryList = new List<InvetorySlot>();
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for(int i = 0; i < InventoryList.Count; i++)
        {
            if (InventoryList[i].Item == _item)
            {
                InventoryList[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            InventoryList.Add(new InvetorySlot(_item, _amount));
        }
    }

    public bool itemMapCheck()
    {
        for (int i = 0; i < InventoryList.Count; i++)
        {
            if (InventoryList[i].Item.type == ItemType.Map)
            {
                return true;
            }
        }
        return false;
    }

    public bool itemMaskCheck()
    {
        for (int i = 0; i < InventoryList.Count; i++)
        {
            if (InventoryList[i].Item.type == ItemType.Mask)
            {
                return true;
            }
        }
        return false;
    }

    public bool itemImmunityCheck()
    {
        for (int i = 0; i < InventoryList.Count; i++)
        {
            if (InventoryList[i].Item.type == ItemType.Immunity)
            {
                return true;
            }
        }
        return false;
    }

    public bool itemVRGoggleCheck()
    {
        for (int i = 0; i < InventoryList.Count; i++)
        {
            if (InventoryList[i].Item.type == ItemType.VRGoggle)
            {
                return true;
            }
        }
        return false;
    }

    public bool itemVaccine()
    {
        for (int i = 0; i < InventoryList.Count; i++)
        {
            if (InventoryList[i].Item.type == ItemType.Vaccine)
            {
                return true;
            }
        }
        return false;
    }
}

[System.Serializable]
public class InvetorySlot
{
    public ItemObject Item;
    public int amount;

    public InvetorySlot(ItemObject _item, int _amount)
    {
        Item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
