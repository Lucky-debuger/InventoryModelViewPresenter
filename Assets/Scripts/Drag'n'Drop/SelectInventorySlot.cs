using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class SelectInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private ItemPreview itemPreviewPrefab;

    private Canvas _parentCanvas;
    private ItemPreview _itemPreviewInstance;
    private ItemModel _itemModel;
    private InventoryController _inventoryController;

    private void Initialize()
    {
        _itemModel = this.gameObject.GetComponent<SlotView>().Item; // [ ] Плохо ли так делать?
        _parentCanvas = GameObject.Find("Canvas").GetComponent<Canvas>(); // [ ] Нужно убрать?
        _inventoryController = GameObject.Find("Inventory").GetComponent<InventoryCompositionRoot>().GetInventoryController(); // [ ] Точно нужно убрать!
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Initialize();
        _inventoryController.SelectInventorySlot(_itemModel);
        _itemPreviewInstance = Instantiate(itemPreviewPrefab, _parentCanvas.transform);
        _itemPreviewInstance.Initialize(_itemModel);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _itemPreviewInstance.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsPointerOverDeleteArea(eventData))
        {
            _inventoryController.DeleteItem();
        }
        Destroy(_itemPreviewInstance.gameObject);
    }

    private bool IsPointerOverDeleteArea(PointerEventData eventData)
    {
        var results = new List<RaycastResult>(); // [ ] Почему не могу нормально задать тип?
        EventSystem.current.RaycastAll(eventData, results); // [ ] Точно хороший способ?

        foreach (var r in results)
        {
            if (r.gameObject.tag == "DeleteArea") // [ ] Может лучше через тег?
            {
                return true;
            }
        }

        return false;
    }
}
