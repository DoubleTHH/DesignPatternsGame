using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterAttr
{
    protected BaseAttr m_BaseAttr = null;
    protected int m_NowHP = 0;
    protected IAttrStrategy m_AttrStrategy = null;

    public ICharacterAttr() { }


    public virtual void InitAttr()
    {
        m_AttrStrategy.InitAttr(this);
        FullNowHP();
    }

    protected void SetBaseAttr(BaseAttr BaseAttr)
    {
        m_BaseAttr = BaseAttr;
    }

    public BaseAttr GetBaseAttr()
    {
        return m_BaseAttr;
    }


    public void SetAttrStrategy(IAttrStrategy theAttrStrategy)
    {
        m_AttrStrategy = theAttrStrategy;
    }

    public IAttrStrategy GetAttrStategy()
    {
        return m_AttrStrategy;
    }


    public int GetAtkPlusValue()
    {
        return m_AttrStrategy.GetAtkPlusValue(this);
    }

    public void CalDmgValue(ICharacter Attracker)
    {
        int AtkValue = Attracker.GetAtkValue();
        AtkValue -= m_AttrStrategy.GetDmgDescValue(this);
        m_NowHP -= AtkValue;

    }
    public int GetNowHP()
    {
        return m_NowHP;
    }

    public virtual int GetMaxHP()
    {
        return m_BaseAttr.GetMaxHP();
    }

    public virtual float GetMoveSpeed()
    {
        return m_BaseAttr.GetMoveSpeed();
    }

    public string GetAttrName()
    {
        return m_BaseAttr.GetAttrName();
    }

    public void SetCharacterAttr(ICharacterAttr characterAttr)
    {

    }

    public void FullNowHP()
    {
        m_NowHP = GetMaxHP();
    }
}
