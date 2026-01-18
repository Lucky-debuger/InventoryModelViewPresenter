using UnityEngine;

public class DeleteAreaView : MonoBehaviour
{
    [SerializeField] private GameObject imageDropToDelete;

    private void OnEnable() // [ ] Почему не Awake()? 
    {
        DragEvents.OnInventoryDragStart += Show;
        DragEvents.OnInventoryDragEnd += Hide;
    }

    private void OnDisable()
    {
        DragEvents.OnInventoryDragStart -= Show;
        DragEvents.OnInventoryDragEnd -= Hide;
    }

    private void Show() => imageDropToDelete.SetActive(true);
    private void Hide() => imageDropToDelete.SetActive(false);
}
