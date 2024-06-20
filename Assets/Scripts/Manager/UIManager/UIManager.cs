using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType{
    Inventory,
}

public class UIManager : MonoSingleton<UIManager>
{
    private Canvas inGameUICanvas;
    public Inventory inventory {get; private set;}
    public InputReader inputReader;

    private void Awake() {
        inGameUICanvas = FindObjectOfType<Canvas>();
        inventory = inGameUICanvas.GetComponentInChildren<Inventory>();
        inputReader.InvenEvent += InvenEventHandle;
    }

    bool isOpen = false;  
    private void InvenEventHandle()
    {
        if (!isOpen) {
            Open(UIType.Inventory);
            isOpen = true;
        }
        else {
            Close(UIType.Inventory);
            isOpen = false;
        }
    }

    public void Open(UIType type) {
        switch (type) {
            case UIType.Inventory: {
                inventory.Active(true);
                break;
            }
        }
    }
        
    public void Open(string type) {
        if (type == UIType.Inventory.ToString()) {
            inventory.Active(true);
            return;
        }
    }

    public void Close(UIType type) {
        switch (type) {
            case UIType.Inventory: {
                inventory.Active(false);
                break;
            }
        }
    }
    public void Close(string type) {
        if (type == UIType.Inventory.ToString()) {
            inventory.Active(false);
            return;
        }
    }
}
