using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListPanel : MonoBehaviour
{
    public ItemList[] itemLists;

    public void SelectItemList(CategoryType type) {
        foreach (ItemList iter in itemLists) {
            if (iter.type == type) {
                iter.Active(true);
                continue;
            }
            iter.Active(false);
        }
    }
}
