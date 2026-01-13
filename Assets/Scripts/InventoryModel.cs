using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory/Inventory", order = 0)]
public class InventoryModel : ScriptableObject
{
    private Dictionary<ItemModel, int> _items = new();

    public void AddItem(ItemModel item)
    {
        if (_items.ContainsKey(item))
        {
            _items[item]++;
        }
        else
        {
            _items[item] = 1;
        }
    }

    public void DeleteItem(ItemModel item)
    {
        _items.Remove(item);
    }
}
