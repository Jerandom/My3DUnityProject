using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vaccine Object", menuName = "Inventory System/Items/Vaccine")]
public class VaccineObject : ItemObject
{
    public int restoreHealthValue;

    public void Awake()
    {
        type = ItemType.Vaccine;
    }
}
