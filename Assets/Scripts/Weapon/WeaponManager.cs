using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoSingleton<WeaponManager>
{
    [field:SerializeField] public Weapon[] Weapons {get; private set;}
    private Weapon mainWeapon;
    private Weapon subWeapon;

    public void UpdateMainWeapon(Weapon weapon) {

    }

    public void UpdateSubWeapon(Weapon weapon) {
        
    }
}
