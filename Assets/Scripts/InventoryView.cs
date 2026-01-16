using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject slot;
    [SerializeField] private Transform inventoryPanel;
    [SerializeField] private ToggleGroup toggleGroup;

    private List<SlotView> slotViews = new List<SlotView>();
    private InventoryController _inventoryController;

    public void Initialize(InventoryController inventoryController)
    {
        _inventoryController = inventoryController;
        _inventoryController.OnItemAdded += UpdateOrCreateSlots;
        _inventoryController.OnItemDeleted += DeleteSlot;
    }

    private void OnDestroy()
    {
        _inventoryController.OnItemAdded -= UpdateOrCreateSlots;
        _inventoryController.OnItemDeleted -= DeleteSlot;
    }

    private void DeleteSlot(ItemModel item)
    {
        for (int i = 0; i < slotViews.Count; i++)
        {
            if (slotViews[i].Item == item)
            {
                Destroy(slotViews[i].gameObject);
                slotViews.RemoveAt(i);
                return;
            }
        }
    }

    private void UpdateOrCreateSlots(ItemModel item)
    {
        foreach (SlotView slotView in slotViews)
        {
            if (slotView.Item == item)
            {
                slotView.SetCount(slotView.ItemCount + 1);
                return;
            }
        }
        CreateSlot(item);

    }

    private void CreateSlot(ItemModel item)
    {
        SlotView slotView = Instantiate(slot, inventoryPanel).GetComponent<SlotView>();

        slotView.gameObject.name = $"Slot_{item.Name}";
        slotView.SetItem(item);
        slotView.SetToggleGroup(toggleGroup);
        slotView.Render();

        slotView.OnSlotClicked += HandleSlotClicked;

        slotViews.Add(slotView);
    }

    private void HandleSlotClicked(ItemModel itemModel)
    {
        _inventoryController.SelectInventorySlot(itemModel);
    }


    public void AddSelectedItem()
    {
        _inventoryController.AddSelectedItem();
    }

}
