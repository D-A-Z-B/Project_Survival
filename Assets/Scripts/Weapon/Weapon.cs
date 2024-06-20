using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;
    private Player player;

    private void Awake() {
        Transform parent;
        parent = GetComponent<Transform>();
        player = parent.GetComponentInParent<Player>();
    }

    private void Update() {
        LookMousePos();
    }

    public virtual void LookMousePos() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - (Vector2)player.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.position = (Vector2)player.transform.position + new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) * offset,Mathf.Sin(angle * Mathf.Deg2Rad) * offset);
        Debug.Log(angle);
        if (Mathf.Abs(angle) > 90) {
            transform.eulerAngles = new Vector3(180, 0, -angle);
        }
        else {
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}
