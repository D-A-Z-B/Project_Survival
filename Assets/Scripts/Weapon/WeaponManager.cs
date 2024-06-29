using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoSingleton<WeaponManager>
{
    [field:SerializeField] public Weapon[] MeleeWeapons {get; private set;}
    [field:SerializeField] public Weapon[] RangedWeapons {get; private set;}
    [field:SerializeField] public Weapon CurrentEquippedWeapon {get; private set;}
    private Weapon mainWeapon;
    private Weapon subWeapon;

    public void UpdateMainWeapon(Weapon weapon) {

    }

    public void UpdateSubWeapon(Weapon weapon) {

    }
}
