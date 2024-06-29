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
    [HideInInspector] public Transform itemIcon;
    private void Awake() {
        isEmpty = true;
        itemIcon = transform.Find("ItemIcon");
        amountText = itemIcon.transform.Find("Amount").GetComponent<TMP_Text>();
        if (itemIcon != null) {
            slotData.itemImage = itemIcon.Find("ItemImage").GetComponent<Image>();
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
}
