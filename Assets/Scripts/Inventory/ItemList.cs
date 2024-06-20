using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemList : MonoBehaviour, IActive
{
    public CategoryType type;
    private GameObject content;
    private Slot[] slots;

    private void Awake() {
        if (content == null) {
            content = transform.Find("Viewport").Find("Content").gameObject;
            if (content == null) {
                Debug.LogError(gameObject.name + " item list does not exist");
            }
            else {
                slots = content.GetComponentsInChildren<Slot>();    
            }
        }
        else {
            slots = content.GetComponentsInChildren<Slot>();
        }
    }

    public void Active(bool value) {
        gameObject.SetActive(value);
    }

    public bool AddItem(Item item) {
        if (item.itemSO.IsStack) {
            foreach (Slot slot in slots) {
                if (slot.slotData.itemSO == item.itemSO) {
                    if (slot.slotData.amount < item.itemSO.CanStackMaxAmount) {
                        slot.UpdateSlot(item);
                        return true;
                    }   
                }
            }
            // 여기까지 오면 겹치는게 없는 거임
            foreach (Slot slot in slots) {
                if (slot.isEmpty) {
                    slot.UpdateSlot(item);
                    return true;
                }
            }
        }
        foreach (Slot slot in slots) {
            Debug.Log("ddd");
            if (slot.isEmpty) {
                slot.UpdateSlot(item);
                return true;
            }
        }
        Debug.Log("인벤 꽉참 ㅋㅋ");
        return false;
    }
}
