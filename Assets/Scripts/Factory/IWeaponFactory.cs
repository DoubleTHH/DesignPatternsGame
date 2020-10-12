using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWeaponFactory 
{
    protected IWeapon pWeapon;
    protected int AttrID;

    protected virtual IWeapon CreateWeapon(ENUM_Weapon emWeapon)
    {
        return new WeaponGun();
    }
    
}
