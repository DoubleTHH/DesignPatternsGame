using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUpgateObserverUI : IGameEventObserver
{
    private SoldierUpgrateSubject m_Subject = null;
    private SoldierInfoUI m_InfoUI = null;

    public SoldierUpgateObserverUI(SoldierInfoUI InfoUI)
    {
        m_InfoUI = InfoUI;
    }

    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as SoldierUpgrateSubject;
    }

    public override void Update()
    {
        m_InfoUI.RefreshSoldier(m_Subject.GetSoldier());
    }
}
