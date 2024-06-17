using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public CategoryType type;

    public void Active(bool value) {
        gameObject.SetActive(value);
    }
}
