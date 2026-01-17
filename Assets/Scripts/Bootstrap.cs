using UnityEngine;

public class InventoryCompositionRoot : MonoBehaviour // Composit root разобраться с названием
{
    [SerializeField] private InventoryModel inventoryModel;
    [SerializeField] private InventoryView inventoryView;
    [SerializeField] private AddSlotGeneralView addSlotGeneralView;
    [SerializeField] private ButtonAddSlotView buttonAddSlotView;
    [SerializeField] private ButtonDeleteItemView buttonDeleteItemView;
    [SerializeField] private DescriptionView descriptionView;
    [SerializeField] private AddItemButton addItemButtonShortSword; // [ ] Точно стоит так делать с кнопками?
    [SerializeField] private AddItemButton addItemButtonHandAxe;
    [SerializeField] private AddItemButton addItemButtonAstrologersStaff;

    private InventoryController _inventoryController;

    private void Awake()
    {
        _inventoryController = new InventoryController(inventoryModel);

        inventoryView.Initialize(_inventoryController);
        addSlotGeneralView.Initialize(_inventoryController);
        buttonAddSlotView.Initialize(_inventoryController);
        buttonDeleteItemView.Initialize(_inventoryController);
        descriptionView.Initialize(_inventoryController);
        addItemButtonShortSword.Initialize(_inventoryController);
        addItemButtonAstrologersStaff.Initialize(_inventoryController);
        addItemButtonHandAxe.Initialize(_inventoryController);
    }

    public InventoryController GetInventoryController() // [ ] Убрать?
    {
        return _inventoryController;
    }
}
