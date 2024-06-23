using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemSO : ScriptableObject
{
    public CategoryType ItemType;
    public bool IsStack;
    public int CanStackMaxAmount;
    public string ItemName;
    public string ItemDescription;
}