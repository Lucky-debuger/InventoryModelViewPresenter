using System;
using UnityEngine;
using UnityEngine.UI;

public class AddSlotView : MonoBehaviour
{
    [SerializeField] Toggle toggle;
    [SerializeField] ItemModel itemModel;

    public event Action<ItemModel> OnAddSlotViewClicked;

    private void Awake()
    {
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            toggle.targetGraphic.color = toggle.colors.selectedColor;
            OnAddSlotViewClicked?.Invoke(itemModel);
        }
        else
        {
            toggle.targetGraphic.color = toggle.colors.normalColor;
        }
    }
}
