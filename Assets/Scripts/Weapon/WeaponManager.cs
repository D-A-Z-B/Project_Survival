using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoSingleton<WeaponManager>
{
    [field:SerializeField] public Weapon[] MeleeWeapons {get; private set;}
    [field:SerializeField] public Weapon[] RangedWeapons {get; private set;}
    [field:SerializeField] public Weapon CurrentEquippedWeapon {get; private set;}
    public Weapon mainWeapon {get; private set;}
    public Weapon subWeapon {get; private set;}

    public void UpdateMainWeapon(Weapon weapon) {

    }

    public void UpdateSubWeapon(Weapon weapon) {

    }
}
