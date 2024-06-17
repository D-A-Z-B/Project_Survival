using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SlotData {
    public ItemSO itemSO;
    public Image itemImage;
    public int amount;
}

public class Slot : MonoBehaviour
{
    [SerializeField] private SlotData slotData;
    private Color color;
    private void Awake() {
        Transform itemImageTransform = transform.Find("ItemImage");
        if (itemImageTransform != null) {
            slotData.itemImage = itemImageTransform.GetComponent<Image>();
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

    public void UpdateSlot(ItemSO itemSO) {
        if (slotData.itemImage != null) {
            slotData.itemSO = itemSO;
            slotData.itemImage.sprite = itemSO.ItemImage;
            color.a = 1;
            slotData.itemImage.color = color;
        } else {
            Debug.LogError("Image component is not assigned, cannot update slot.");
        }
    }
}
