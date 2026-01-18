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

    public void Construct(InventoryController inventoryController, Canvas canvas, ItemModel itemModel)
    {
        _inventoryController = inventoryController;
        _parentCanvas = canvas;
        _itemModel = itemModel;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragEvents.InvokeInventoryDragStart();
        _inventoryController.SelectInventorySlot(_itemModel);
        _itemPreviewInstance = Instantiate(itemPreviewPrefab, _parentCanvas.transform);
        _itemPreviewInstance.Initialize(_itemModel);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _itemPreviewInstance.transform.position = eventData.position;
        Debug.Log(IsPointerOverDeleteArea(eventData));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        

        if (IsPointerOverDeleteArea(eventData))
        {
            _inventoryController.DeleteItem();
        }
        
        Destroy(_itemPreviewInstance.gameObject);
        DragEvents.InvokeInventoryDragEnd();
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
