using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] InventoryController inventoryController;
    [SerializeField] GameObject slot;
    [SerializeField] Transform inventoryPanel;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] Image descriptionIcon;

    private List<SlotView> slotViews = new List<SlotView>();

    private void Awake()
    {
        inventoryController.OnItemAdded += UpdateOrCreateSlots;
        inventoryController.OnItemDeleted += DeleteSlot;
    }

    private void OnDestroy()
    {
        inventoryController.OnItemAdded -= UpdateOrCreateSlots;
        inventoryController.OnItemDeleted -= DeleteSlot;
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
                slotView.SetCount(slotView.ItemCount+1);
                return;
            }
        }
        CreateSlot(item);
        
    }

    private void CreateSlot(ItemModel item)
    {
        SlotView slotView = Instantiate(slot, inventoryPanel).GetComponent<SlotView>();

        slotView.SetupDescriptionPanel(descriptionText, descriptionIcon);
        slotView.SetItem(item);
        slotView.Render();

        slotView.OnSlotClicked += HandleSlotClicked;

        slotViews.Add(slotView);
    }

    private void HandleSlotClicked(SlotView slotView)
    {
        inventoryController.SelectItem(slotView.Item);
        ShowDescription(slotView);
        HighlightSlot(slotView);
    }

    private void ShowDescription(SlotView slotView)
    {
        descriptionText.text = slotView.Item.Description;
        descriptionIcon.sprite = slotView.Item.Icon;
    }

    private void HighlightSlot(SlotView slotView)
    {
        foreach (SlotView slot in slotViews)
        {
            if (slot == slotView)
            {
                slot.Highlight();
            }

            else
            {
                slot.SetDefaultColor();
            }
        }
        
    } 

}
