using System;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType {
    Weapon,
    Potion,
    Ingredient,
    Etc
}

public abstract class ItemSO : ScriptableObject
{
    public ItemType ItemType;
    public bool IsStack;
    public int CanStackMaxAmount;
    public Sprite ItemImage;
    public String ItemName;
    public String ItemDescription;
}
