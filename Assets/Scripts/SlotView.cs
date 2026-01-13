using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotView : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private ItemModel item;

    [Header("UI")]
    [SerializeField] private TMP_Text itemCount;

    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image itemIcon;
    [SerializeField] private Image descriptionIcon;
    [SerializeField] private Toggle toggle;

    public ItemModel Item => item;

    public int ItemCount { get; private set; } = 1;

    public event Action<SlotView> OnSlotClicked;


    private void Awake()
    {
        toggle.onValueChanged.AddListener(OnToggleChanged);
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

    private void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            Debug.Log("ToggleChanged: " + name);

            OnSlotClicked?.Invoke(this);
        }
    }
}
