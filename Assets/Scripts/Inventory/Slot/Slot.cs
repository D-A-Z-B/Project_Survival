using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class SlotData {
    public ItemSO itemSO;
    public Image itemImage;
    public int amount;
}

public class Slot : MonoBehaviour
{
    public SlotData slotData;
    public bool isEmpty;
    private TMP_Text amountText;
    private Color color;
    public ItemIconDrag itemIcon {get; private set;} 
    public Item currentSavingItem {get; private set;}
    private void Awake() {
        isEmpty = true;
        itemIcon = transform.Find("ItemIcon").GetComponent<ItemIconDrag>();
        amountText = itemIcon.transform.Find("Amount").GetComponent<TMP_Text>();
        if (itemIcon != null) {
            slotData.itemImage = itemIcon.transform.Find("ItemImage").GetComponent<Image>();
            if (slotData.itemImage != null) {
                color = slotData.itemImage.color;
                if (slotData.itemImage.sprite == null) {
                    color.a = 0;
                    slotData.itemImage.color = color;
                }
            } else {
                Debug.LogError("Failed to find Image component on 'ItemImage' object.");
            }
        } else {
            Debug.LogError("Failed to find 'ItemImage' child object.");
        }
    }

    public void UpdateSlot(Item item) {
        currentSavingItem = item;
        if (slotData.itemImage != null) {
            slotData.itemSO = item.itemSO;
            slotData.itemImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            color.a = 1;
            slotData.itemImage.color = color;
        } else {
            Debug.LogError("Image component is not assigned, cannot update slot.");
        }
        if (amountText != null && item.itemSO.IsStack) {
            slotData.amount++;
            amountText.text = slotData.amount.ToString();
        }
        isEmpty = false;
    }

    public void UpdateSlot(Slot slot) {
        currentSavingItem = slot.currentSavingItem;
        if (slotData.itemImage != null) {
            slotData.itemSO = slot.slotData.itemSO;
            slotData.itemImage.sprite = slot.itemIcon.itemImage.sprite;
            if (slotData.itemImage.sprite == null) {
                color.a = 0;
                isEmpty = true;
            }
            else {
                color.a = 1;
                isEmpty = false;
            }
            slotData.itemImage.color = color;
        } else {
            Debug.LogError("Image component is not assigned, cannot update slot.");
        }
        if (amountText != null && slot.slotData.itemSO != null && slot.slotData.itemSO.IsStack) {
            slotData.amount++;
            amountText.text = slotData.amount.ToString();
        }
    }

    public void RemoveSlotItem(int amount) {
        slotData.amount -= amount;
        if (slotData.amount <= 0) {
            ClearSlot();
        }
    }

    private void Update() {
        /* 
        //테스트용
        if (Input.GetKeyDown(KeyCode.T)) {
            ClearSlot();
        } 
        */
    }
    
    private void ClearSlot() {
        isEmpty = true;
        currentSavingItem = null;
        slotData.amount = 0;
        slotData.itemSO = null;
        slotData.itemImage.sprite = null;
        color.a = 0;
        slotData.itemImage.color = color;
        amountText.text = " ";
    }
}
