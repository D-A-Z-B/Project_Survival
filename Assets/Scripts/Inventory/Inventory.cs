using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoSingleton<Inventory>
{
    public ItemListPanel itemListPanel {get; private set;}
    public InventoryCategoryPanel inventoryCategoryPanel {get; private set;}
    
    private void Awake() {
        itemListPanel = GetComponentInChildren<ItemListPanel>();
        inventoryCategoryPanel = GetComponentInChildren<InventoryCategoryPanel>();
    }

    public void AddItem(ItemSO itemSO) {

    }
}
