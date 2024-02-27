using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> items;
}
