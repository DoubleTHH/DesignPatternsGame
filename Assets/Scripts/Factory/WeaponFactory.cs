using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : IWeaponFactory
{


    protected override IWeapon CreateWeapon(ENUM_Weapon emWeapon)
    {
        IAttrFactory theAttrFactory = PBDFactory.GetAttrFactory();
        WeaponAttr theWeaponAttr = theAttrFactory.GetWeaponAttr(AttrID);

        pWeapon.SetWeaponAttr(theWeaponAttr);

        return pWeapon;
    }

}
