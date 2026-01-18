using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddItemButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas parentCanvas;
    [SerializeField] private ItemPreview itemPreviewPrefab;
    [SerializeField] private ItemModel itemModel;

    private InventoryController _inventoryController;
    private ItemPreview _flyingPreview;

    public void Initialize(InventoryController inventoryController)
    {
        _inventoryController = inventoryController;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _flyingPreview = Instantiate(itemPreviewPrefab, parentCanvas.transform);
        _flyingPreview.Initialize(itemModel);
        _flyingPreview.transform.SetAsLastSibling();

        _inventoryController.SelectAddSlot(itemModel);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _flyingPreview.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsPointerOverInventory(eventData))
        {
            _inventoryController.AddSelectedItem();
        }

        Destroy(_flyingPreview.gameObject);
    }

    private bool IsPointerOverInventory(PointerEventData eventData) // [ ] Разобраться, как работает
    {
        var results = new List<RaycastResult>(); // [ ] Почему не могу нормально задать тип?
        EventSystem.current.RaycastAll(eventData, results); // [ ] Точно хороший способ?

        foreach (var r in results)
        {
            if (r.gameObject.tag == "InventoryPanel") // [ ] Может лучше через тег?
            {
                return true;
            }
        }

        return false;
    }
}
