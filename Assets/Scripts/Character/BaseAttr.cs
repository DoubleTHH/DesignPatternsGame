using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttr
{
    private int m_MaxHP;
    private float m_MoveSpeed;
    private string m_AttrName;

    public BaseAttr(int MaxHP, float MoveSpeed, string AttrName)
    {
        this.m_MaxHP = MaxHP;
        this.m_MoveSpeed = MoveSpeed;
        this.m_AttrName = AttrName;
    }

    public int GetMaxHP()
    {
        return m_MaxHP;
    }

    public float GetMoveSpeed()
    {
        return m_MoveSpeed;
    }

    public string GetAttrName()
    {
        return m_AttrName;
    }
}
