using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

public abstract class PoolableMono : MonoBehaviour
{
    public PoolingType type;
    public abstract void ResetItem();
}
