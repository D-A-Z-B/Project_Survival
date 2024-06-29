using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemIconDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beginDraggedIcon;
    [HideInInspector] public Transform startParent ;
    private Vector2 startPosition;
    public Slot slot {get; private set;}

    public void OnBeginDrag(PointerEventData eventData) {
        startParent = transform.parent;
        slot = startParent.GetComponent<Slot>();
        beginDraggedIcon = gameObject;
        startPosition = transform.position;
        transform.SetParent(UIManager.Instance.InGameUICanvas.transform);
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        beginDraggedIcon = null;
        SetDefaultPosition();
    }

    private void SetDefaultPosition() {
        transform.position = startPosition;
        transform.SetParent(startParent);
    }

}
