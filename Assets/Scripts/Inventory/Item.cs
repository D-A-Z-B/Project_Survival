using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Item : MonoBehaviour
{
    public ItemSO itemSO;
    public Vector2 playrCheckBoxSize;

    private void Update() {
        if (PlayerCheck()) {
            if (Keyboard.current.fKey.wasPressedThisFrame) {
                AddItem();
            }
            else {
                //Debug.Log("F를 눌러 아이템 먹으셈");
            }
        }
    }

    private void AddItem() {
        foreach (ItemList list in UIManager.Instance.inventory.itemListPanel.itemLists) {
            if (list.type == itemSO.ItemType) {
                bool flag = list.AddItem(this);
                Debug.Log(list.type);
                if (flag) {
                    Destroy(gameObject);
                }
                break;
            }
        }
    }

    private bool PlayerCheck() {
        return  Physics2D.OverlapBox(transform.position, playrCheckBoxSize, 0, LayerMask.GetMask("Player"));
    }

    private void OnDrawGizmos() {
        // player Check gizmos
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, playrCheckBoxSize);
    }
}
