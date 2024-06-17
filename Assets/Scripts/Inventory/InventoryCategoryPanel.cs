using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCategoryPanel : MonoBehaviour
{
    [SerializeField] private Color selectedColor;
    private InventoryCategory[] categorys;

    private void Awake() {
        categorys = GetComponentsInChildren<InventoryCategory>();
    }

    public void SelectCategory(CategoryType type) {
        foreach (InventoryCategory iter in categorys) {
            if (iter.type == type) {
                iter.SetColor(selectedColor);
                continue;
            }
            iter.SetColor(Color.black);
        }
    }
}
