using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPreview : MonoBehaviour
{
    private ItemModel _itemModel;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;


    public void Initialize(ItemModel itemModel)
    {
        _itemModel = itemModel;

        image.sprite = _itemModel.Icon;
        text.text = _itemModel.Name;
    }
}
