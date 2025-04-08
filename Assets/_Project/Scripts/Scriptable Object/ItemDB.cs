using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Item DB", menuName = "InventoryGame/DB/ItemDB")]
public class ItemDB : ScriptableObject
{
    public List<ItemData> Items = new List<ItemData>();

    public ItemData GetItemByID(int id)
    {
        return Items.Find(item => item.ID == id);
    }
}