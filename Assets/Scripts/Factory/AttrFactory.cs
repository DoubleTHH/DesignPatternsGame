using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrFactory : IAttrFactory
{
    private Dictionary<int, BaseAttr> m_SoldierAttrDB = null;
    private Dictionary<int, EnemyBaseAttr> m_EnemyAttrDB = null;
    private Dictionary<int, WeaponAttr> m_WeaponAttrDB = null;


    public AttrFactory()
    {
        InitSoldierAttr();
        InitEnemyAttr();
        InitWeaponAttr();
    }

    private void InitSoldierAttr()
    {
        m_SoldierAttrDB = new Dictionary<int, BaseAttr>();
        m_SoldierAttrDB.Add(1, new BaseAttr(10, 3.0f, "新兵"));
        m_SoldierAttrDB.Add(2, new BaseAttr(20, 3.2f, "中士"));
        m_SoldierAttrDB.Add(3, new BaseAttr(30, 3.4f, "上尉"));
    }

    private void InitEnemyAttr()
    {
        m_EnemyAttrDB = new Dictionary<int, EnemyBaseAttr>();
        m_EnemyAttrDB.Add(1, new EnemyBaseAttr(5, 3.0f, 5, "精灵",10));
        m_EnemyAttrDB.Add(2, new EnemyBaseAttr(15, 3.1f, 10, "山妖",20));
        m_EnemyAttrDB.Add(3, new EnemyBaseAttr(20, 3.3f, 15, "怪物",40));
    }

    private void InitWeaponAttr()
    {
        m_WeaponAttrDB = new Dictionary<int, WeaponAttr>();
        m_WeaponAttrDB.Add(1, new WeaponAttr(2, 4, "短枪"));
        m_WeaponAttrDB.Add(2, new WeaponAttr(4, 7, "长枪"));
        m_WeaponAttrDB.Add(3, new WeaponAttr(8, 10, "火箭炮"));
    }


    public override SoldierAttr GetSoldierAttr(int AttrID)
    {
        if (!m_SoldierAttrDB.ContainsKey(AttrID))
        {
            Debug.LogWarning("GetSoldierAttr: AttrID[" + AttrID + "]属性不存在");
            return null;
        }

        SoldierAttr NewAttr = new SoldierAttr();
        NewAttr.SetSoldierAttr(m_SoldierAttrDB[AttrID]);
        return NewAttr;
    }

    public override EnemyAttr GetEnemyAttr(int AttrID)
    {
        if (!m_EnemyAttrDB.ContainsKey(AttrID))
        {
            Debug.LogWarning("GetSoldierAttr: AttrID[" + AttrID + "]属性不存在");
            return null;
        }

        EnemyAttr NewAttr = new EnemyAttr();
        NewAttr.SetEnemyAttr(m_EnemyAttrDB[AttrID]);
        return NewAttr;
    }

    public override WeaponAttr GetWeaponAttr(int AttrID)
    {
        if (!m_WeaponAttrDB.ContainsKey(AttrID))
        {
            Debug.LogWarning("GetWeaponAttr: AttrID[" + AttrID + "]属性不存在");
            return null;
        }
        return m_WeaponAttrDB[AttrID];
    }
}
