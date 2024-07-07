using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    [field:SerializeField] public FireMode FireMode {get; private set;}
    [field:SerializeField] public float FireRate {get; private set;}

    private float lastShootTime;
    public float LastShootTime {
        get => lastShootTime;
        set => lastShootTime = value;
    }
    
    public abstract void Shoot();
}
