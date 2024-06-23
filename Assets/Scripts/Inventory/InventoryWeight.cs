using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWeight : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    private Slider slider;
    private Image fill;
    private int currentMaxWeight;
    private int currntWeight;

    private void Awake() {
        slider = GetComponentInChildren<Slider>();
        fill = slider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
        fill.color = gradient.Evaluate(0);
        slider.value = 0;
    }

    private void  Start() {
        UIManager.Instance.inventory.UpdateBag += UpdateBagHandle;
        foreach (ItemList list in UIManager.Instance.inventory.ItemListPanel.itemLists) {
            list.AddItemEvent +=  AddItemHandle;
        }
    }

    private void AddItemHandle(Item item) {
        // 아래 값은 테스트임
        currntWeight += 100;
    }

    private void UpdateBagHandle(BagSO bagSO) {
        currentMaxWeight = bagSO.weight;
    }
}
