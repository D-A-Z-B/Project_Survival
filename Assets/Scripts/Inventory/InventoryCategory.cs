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
        UIManager.Instance.inventory.InventoryCategoryPanel.SelectCategory(type);
        UIManager.Instance.inventory.ItemListPanel.SelectItemList(type);
    }

    public void SetColor(Color color) {
        image.color = color;
    }

    public void Active(bool value) {
        gameObject.SetActive(value);
    }
}
