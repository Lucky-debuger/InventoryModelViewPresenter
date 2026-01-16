using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionView : MonoBehaviour
{
    private InventoryController _inventoryController;

    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject descriptionContent;

    public void Initialize(InventoryController inventoryController)
    {
        _inventoryController = inventoryController;
        _inventoryController.OnSlotSelected += ShowDescription;
        _inventoryController.OnSlotEnded += HideDescription;
    }

    private void ShowDescription(ItemModel itemModel)
    {
        descriptionContent.gameObject.SetActive(true);
        image.sprite = itemModel.Icon;
        text.text = itemModel.Description;
    }

    private void HideDescription()
    {
        descriptionContent.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _inventoryController.OnSlotSelected -= ShowDescription;
        _inventoryController.OnSlotEnded -= HideDescription;
    }
}

