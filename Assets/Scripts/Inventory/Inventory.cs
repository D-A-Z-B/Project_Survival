using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IActive
{
    public ItemListPanel itemListPanel {get; private set;}
    public InventoryCategoryPanel inventoryCategoryPanel {get; private set;}
    private Transform visual;

    private void Awake() {
        visual = transform.Find("InventoryPanel");
        itemListPanel = visual.GetComponentInChildren<ItemListPanel>();
        inventoryCategoryPanel = visual.GetComponentInChildren<InventoryCategoryPanel>();
    }

    private void Start() {
        Active(false);
    }

    public void Active(bool value) {
        visual.gameObject.SetActive(value);
    }
}
