using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory/Inventory", order = 0)]
public class InventoryModel : ScriptableObject
{
    private Dictionary<ItemModel, int> items = new();

    public void AddItem(ItemModel item)
    {
        if (items.ContainsKey(item))
        {
            items[item]++;
        }
        else
        {
            items[item] = 1;
        }
    }

    public void DeleteItem(ItemModel item)
    {
        items.Remove(item);
    }
}
