using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseAttr : BaseAttr
{
    private int m_MaxHP;
    private float m_MoveSpeed;
    private string m_AttrName;
    protected int m_CritRate = 0;

    public EnemyBaseAttr(int MaxHP, float MoveSpeed, int CritRate, string AttrName,int a) : base(MaxHP,MoveSpeed,AttrName)
    {
        m_MaxHP = MaxHP;
        m_MoveSpeed = MoveSpeed;
        m_AttrName = AttrName;
        m_CritRate = CritRate;
    }
    public int InitCritRate()
    {
        return m_CritRate;
    }

}
