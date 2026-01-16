using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotView : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private ItemModel item;

    [Header("UI")]
    [SerializeField] private TMP_Text itemCount;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private Image itemIcon;
    [SerializeField] private Toggle toggle;

    public ItemModel Item => item;

    public int ItemCount { get; private set; } = 1;

    public event Action<ItemModel> OnSlotClicked;


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
        itemCount.text = ItemCount.ToString();
    }

    public void SetCount(int count)
    {
        ItemCount = count;
        itemCount.text = ItemCount.ToString();
    }

    public void SetToggleGroup(ToggleGroup toggleGroup)
    {
        toggle.group = toggleGroup;
    }

    private void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            toggle.targetGraphic.color = toggle.colors.selectedColor;
            OnSlotClicked?.Invoke(item);
        }
        else
        {
            toggle.targetGraphic.color = toggle.colors.normalColor;
        }
    }
}
