using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttr
{
    protected int m_Atk = 0;
    protected float m_Range = 0.0f;

    public WeaponAttr(int AtkValue, float Range,string name)
    {
        m_Atk = AtkValue;
        m_Range = Range;
    }

    public virtual int GetAtkValue()
    {
        return m_Atk;
    }

    public virtual float GetAtkRange()
    {
        return m_Range;
    }
}
