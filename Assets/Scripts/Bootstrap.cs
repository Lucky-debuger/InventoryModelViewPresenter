using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private InventoryModel inventoryModel;
    [SerializeField] private InventoryView inventoryView;

    private void Awake()
    {
        InventoryController inventoryController = new InventoryController(inventoryModel);
        inventoryView.Initialize(inventoryController);
    }
}
