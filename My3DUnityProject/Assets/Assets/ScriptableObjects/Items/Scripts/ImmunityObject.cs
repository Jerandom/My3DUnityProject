using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Immunity Object", menuName = "Inventory System/Items/Immunity")]
public class ImmunityObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Immunity;
    }
}
