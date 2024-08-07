using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemIconDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [HideInInspector] public Transform startParent;
    [HideInInspector] public Vector3 startPos;
    public Image itemImage { get; private set; }
    private Slot slot;

    private void Awake()
    {
        slot = GetComponentInParent<Slot>();
        itemImage = GetComponentInChildren<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
        startParent = transform.parent;
        if (slot.slotData.itemSO == null) {
            transform.SetParent(startParent);
            transform.position = startPos;
            return;
        }
        itemImage.raycastTarget = false;
        transform.SetParent(UIManager.Instance.InGameUICanvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(startParent);
        transform.localPosition = Vector3.zero; // 부모의 위치로 되돌립니다.
        itemImage.raycastTarget = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Slot targetSlot;
        try {
            targetSlot = eventData.pointerDrag.GetComponent<ItemIconDrag>().slot;
        }
        catch {
            return;
        }
        if (slot.isEmpty) {
            for (int i = 0; i <= targetSlot.slotData.amount; ++i) {
                slot.UpdateSlot(targetSlot);
                targetSlot.RemoveSlotItem(1);
            }
        }
        /* else {
            if (slot.slotData.itemSO.IsStack == true) {
                for (int i = targetSlot.slotData.amount; i < targetSlot.slotData.itemSO.CanStackMaxAmount + 1; ++i) {
                    slot.UpdateSlot(targetSlot);
                    targetSlot.RemoveSlotItem(1);
                }
            }
            else {

            }
        } */
    }
}
