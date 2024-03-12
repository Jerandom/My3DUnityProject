using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int Y_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;

    Dictionary<InvetorySlot, GameObject> itemDisplay = new Dictionary<InvetorySlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0;i<inventory.InventoryList.Count;i++) 
        {
            var obj = Instantiate(inventory.InventoryList[i].Item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = getPosition(i);
            //obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.InventoryList[i].amount.ToString("n0");
            itemDisplay.Add(inventory.InventoryList[i], obj);
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.InventoryList.Count; i++)
        {
            if (itemDisplay.ContainsKey(inventory.InventoryList[i]))
            {
                //itemDisplay[inventory.InventoryList[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.InventoryList[i].amount.ToString("n0"); 
            }
            else
            {
                var obj = Instantiate(inventory.InventoryList[i].Item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = getPosition(i);
                //obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.InventoryList[i].amount.ToString("n0");
                itemDisplay.Add(inventory.InventoryList[i], obj);
            }
        }
    }

    public Vector3 getPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEM * (i / NUMBER_OF_COLUMN)), 0f);
    }
}
