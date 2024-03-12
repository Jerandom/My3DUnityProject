using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mask Object", menuName = "Inventory System/Items/Mask")]
public class MaskObject : ItemObject
{
    public float DefenceBonus;

    public void Awake()
    {
        type = ItemType.Mask;
    }
}
