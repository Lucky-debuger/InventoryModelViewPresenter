using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotView : MonoBehaviour, IPointerClickHandler
{
    [Header("Data")]
    [SerializeField] private ItemModel item;

    [Header("UI")]
    [SerializeField] private TMP_Text itemCount;

    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image itemIcon;
    [SerializeField] private Image descriptionIcon;
    [SerializeField] private Button button;

    public ItemModel Item => item;

    public int ItemCount {get; private set;} = 1;
    
    public event Action<SlotView> OnSlotClicked;
    private ColorBlock _defaultColor;
    private ColorBlock _highlightedColor;

    private void Start()
    {
        _defaultColor = button.colors;

        _highlightedColor = button.colors;
        _highlightedColor.colorMultiplier = 3f;
    }

    public void SetItem(ItemModel itemModel)
    {
        item = itemModel;
    }
    public void Render()
    {
        itemName.text = item.Name;
        itemIcon.sprite = item.Icon;
        descriptionText.text = item.Description;
        descriptionIcon.sprite = item.Icon;
        itemCount.text = ItemCount.ToString();
    }

    public void SetCount(int count)
    {
        ItemCount = count;
        itemCount.text = ItemCount.ToString();
    }

    public void SetupDescriptionPanel(TMP_Text description, Image Icon)
    {
        descriptionText = description;
        descriptionIcon = Icon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSlotClicked?.Invoke(this);
    }

    public void Highlight()
    {
        button.colors = _highlightedColor;
    }

    public void SetDefaultColor()
    {
        button.colors = _defaultColor;
    }
}
