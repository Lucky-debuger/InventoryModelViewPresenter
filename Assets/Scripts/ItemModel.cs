using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Inventory/Item", order = 1)]
public class ItemModel : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Icon;
}
