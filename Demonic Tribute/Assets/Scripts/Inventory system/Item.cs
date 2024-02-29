using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingame Item", menuName = "Ingame item")]
public class Item : ScriptableObject
{
    public new string name;
    public string id;

    public int itemWeigth;

}
