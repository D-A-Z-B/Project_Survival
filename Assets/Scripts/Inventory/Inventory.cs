using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IActive
{
    public ItemListPanel ItemListPanel {get; private set;}
    public InventoryCategoryPanel InventoryCategoryPanel {get; private set;}
    public InventoryWeight InventoryWeight {get; private set;}
    public BagSO CurrentBag {get; private set;}
    public event Action<BagSO> UpdateBag;
    private Transform visual;

    private void Awake() {
        visual = transform.Find("InventoryPanel");
        ItemListPanel = visual.GetComponentInChildren<ItemListPanel>();
        InventoryCategoryPanel = visual.GetComponentInChildren<InventoryCategoryPanel>();
        InventoryWeight = visual.GetComponent<InventoryWeight>();
    }

    private void Start() {
        Active(false);
    }

    public void UpdateBagSO(BagSO bagSO) {
        CurrentBag = bagSO;
        UpdateBag?.Invoke(CurrentBag);
    }

    public void Active(bool value) {
        visual.gameObject.SetActive(value);
    }
}
