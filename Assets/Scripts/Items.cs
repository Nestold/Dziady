using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Items")]
public class Items : ScriptableObject
{
    public List<Item> ItemsList = null;
}
