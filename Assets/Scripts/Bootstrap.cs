using UnityEngine;

public class InventoryCompositionRoot : MonoBehaviour // Composit root разобраться с названием
{
    [SerializeField] private InventoryModel inventoryModel;
    [SerializeField] private InventoryView inventoryView;
    [SerializeField] private AddSlotGeneralView addSlotGeneralView;
    [SerializeField] private ButtonAddSlotView buttonAddSlotView;
    [SerializeField] private ButtonDeleteItemView buttonDeleteItemView;
    [SerializeField] private DescriptionView descriptionView;

    private void Awake()
    {
        InventoryController inventoryController = new InventoryController(inventoryModel);

        inventoryView.Initialize(inventoryController);
        addSlotGeneralView.Initialize(inventoryController);
        buttonAddSlotView.Initialize(inventoryController);
        buttonDeleteItemView.Initialize(inventoryController);
        descriptionView.Initialize(inventoryController);
    }
}
