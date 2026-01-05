using System;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryModel inventoryModel;
    
    private ItemModel _selectedItem;
    
    public event Action<ItemModel> OnItemAdded;
    public event Action<ItemModel> OnItemDeleted;

    public void SelectItem(ItemModel item)
    {
        _selectedItem = item;
    }

    public void AddSelectedItem()
    {
        if (_selectedItem == null) return;

        inventoryModel.AddItem(_selectedItem);
        OnItemAdded?.Invoke(_selectedItem);
    }

    public void DeleteItem()
    {
        if (_selectedItem == null) return;

        inventoryModel.DeleteItem(_selectedItem);
        OnItemDeleted?.Invoke(_selectedItem);
    }
}
