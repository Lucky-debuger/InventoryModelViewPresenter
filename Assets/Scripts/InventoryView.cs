using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] GameObject slot;
    [SerializeField] Transform inventoryPanel;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] Image descriptionIcon;
    [SerializeField] private List<SlotView> precreatedAddSlots;

    private List<SlotView> slotViews = new List<SlotView>();
    private InventoryController _inventoryController;

    public void Initialize(InventoryController inventoryController)
    {
        _inventoryController = inventoryController;
        _inventoryController.OnItemAdded += UpdateOrCreateSlots;
        _inventoryController.OnItemDeleted += DeleteSlot;

        SubscribeSlots();
    }

    private void SubscribeSlots()
    {
        foreach (SlotView slot in precreatedAddSlots)
        {
            slot.OnSlotClicked += HandleSlotClicked;
        }
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

        slotView.SetupDescriptionPanel(descriptionText, descriptionIcon);
        slotView.SetItem(item);
        slotView.Render();

        Debug.Log("CreateSlot: " + slotView.name);
        Debug.Log("Subscribed to: " + slotView.name);
        slotView.OnSlotClicked += HandleSlotClicked;

        slotViews.Add(slotView);
    }

    private void HandleSlotClicked(SlotView slotView)
    {
        Debug.Log("HandleSlotClicked");
        _inventoryController.SelectItem(slotView.Item);
        ShowDescription(slotView);
    }

    private void ShowDescription(SlotView slotView)
    {
        descriptionText.text = slotView.Item.Description;
        descriptionIcon.sprite = slotView.Item.Icon;
    }

    public void AddSelectedItem()
    {
        _inventoryController.AddSelectedItem();
    }

}
