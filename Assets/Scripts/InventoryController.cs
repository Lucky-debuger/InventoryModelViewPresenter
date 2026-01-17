using System;

public class InventoryController
{
    private InventoryModel _inventoryModel;
    private ItemModel _selectedInventoryItem;
    private ItemModel _selectedAddItem;

    public event Action<ItemModel> OnItemAdded;
    public event Action<ItemModel> OnItemDeleted;
    public event Action<ItemModel> OnSlotSelected;
    public event Action OnSlotEnded;


    public ItemModel GetSelectedSlot()
    {
        return _selectedInventoryItem;
    }

    public ItemModel GetSelectedAddItem() => _selectedAddItem;

    public void SelectInventorySlot(ItemModel item)
    {
        _selectedInventoryItem = item;
        OnSlotSelected?.Invoke(item);
    }

    public void SelectAddSlot(ItemModel item)
    {
        _selectedAddItem = item;
    }

    public InventoryController(InventoryModel inventoryModel)
    {
        _inventoryModel = inventoryModel;
    }

    public void AddSelectedItem()
    {
        if (_selectedAddItem == null) return;

        _inventoryModel.AddItem(_selectedAddItem);
        OnItemAdded?.Invoke(_selectedAddItem);
    }

    public void DeleteItem()
    {
        if (_selectedInventoryItem == null) return;

        _inventoryModel.DeleteItem(_selectedInventoryItem);
        OnItemDeleted?.Invoke(_selectedInventoryItem);
        _selectedInventoryItem = null;

        if (_selectedInventoryItem == null)
        {
            OnSlotEnded?.Invoke();
        }
    }
}
