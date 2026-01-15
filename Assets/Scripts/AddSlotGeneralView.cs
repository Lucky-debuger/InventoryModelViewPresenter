using UnityEngine;
using System.Collections.Generic;

public class AddSlotGeneralView : MonoBehaviour
{
    private InventoryController _inventoryController;

    [SerializeField] List<AddSlotView> addSlotsView;


    public void Initialize(InventoryController inventoryController)
    {
        _inventoryController = inventoryController;


        SubscribeOnAddSlotView();
    }

    private void SubscribeOnAddSlotView()
    {
        foreach (AddSlotView addSlotView in addSlotsView)
        {
            addSlotView.OnAddSlotViewClicked += SelectAddSlot;
        }
    }

    private void SelectAddSlot(ItemModel itemModel)
    {
        _inventoryController.SelectAddSlot(itemModel);
    }
}
