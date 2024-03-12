using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map Object", menuName = "Inventory System/Items/Map")]
public class MapObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Map;
    }
}
