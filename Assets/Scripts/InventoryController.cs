using System;
using UnityEngine;

public class InventoryController
{
    private InventoryModel _inventoryModel;

    private ItemModel _selectedItem;

    public event Action<ItemModel> OnItemAdded;
    public event Action<ItemModel> OnItemDeleted;

    public void SelectItem(ItemModel item)
    {
        _selectedItem = item;
        Debug.Log(item.Name);
    }

    public InventoryController(InventoryModel inventoryModel)
    {
        _inventoryModel = inventoryModel;
    }

    public void AddSelectedItem()
    {
        if (_selectedItem == null) return;

        _inventoryModel.AddItem(_selectedItem);
        OnItemAdded?.Invoke(_selectedItem);
        Debug.Log("Я сработал2");
    }

    public void DeleteItem()
    {
        if (_selectedItem == null) return;

        _inventoryModel.DeleteItem(_selectedItem);
        OnItemDeleted?.Invoke(_selectedItem);
    }
}
