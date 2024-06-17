using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCategory : MonoBehaviour, IPointerClickHandler
{
    public CategoryType type;
    private Image image;
    
    private void Awake() {
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        Inventory.Instance.inventoryCategoryPanel.SelectCategory(type);
        Inventory.Instance.itemListPanel.SelectItemList(type);
    }

    public void SetColor(Color color) {
        image.color = color;
    }

    public void Active(bool value) {
        gameObject.SetActive(value);
    }
}
