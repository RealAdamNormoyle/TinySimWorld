using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInventory
{
    public int Coins;
    public int Gems;
    public List<Item> Items = new List<Item>();
}
