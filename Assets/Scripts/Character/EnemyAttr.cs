using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttr : ICharacterAttr
{
    protected int m_CritRate = 0;
    public EnemyAttr() { }


    public void SetEnemyAttr(EnemyBaseAttr EnemyBaseAttr)
    {
        base.SetBaseAttr(EnemyBaseAttr);
        m_CritRate = EnemyBaseAttr.InitCritRate();
    }

    public int GetCritRate()
    {
        return m_CritRate;
    }

    public void CutdownCritRate()
    {
        m_CritRate -= m_CritRate / 2;
    }
}
