using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAttrFactory
{

    public virtual SoldierAttr GetSoldierAttr(int AttrID)
    {
        return null;
    }

    public virtual EnemyAttr GetEnemyAttr(int AttrID)
    {
        return null;
    }

    public virtual WeaponAttr GetWeaponAttr(int AttrID)
    {
        return null;
    }
}
