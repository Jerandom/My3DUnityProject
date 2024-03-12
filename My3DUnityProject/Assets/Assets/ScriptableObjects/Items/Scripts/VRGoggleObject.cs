using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VRGoggle Object", menuName = "Inventory System/Items/VRGoggle")]
public class VRGoggleObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.VRGoggle;
    }
}
