using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUpgrateSubject : IGameEventSubject
{
    private int m_UpgateCount = 0;
    private ISoldier m_Soldier = null;

    public SoldierUpgrateSubject() { }

    public int GetUpgateCount()
    {
        return m_UpgateCount;
    }

    public override void SetParam(object Param)
    {
        base.SetParam(Param);
        m_Soldier = Param as ISoldier;
        m_UpgateCount++;

        Notify();
    }

    public ISoldier GetSoldier()
    {
        return m_Soldier;
    }
}
