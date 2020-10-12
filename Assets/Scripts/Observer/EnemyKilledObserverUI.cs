using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledObserverUI : IGameEventObserver
{
    private EnemyKilledSubject m_Subject = null;
    private PBaseDefenseGame m_PBDGame = null;

    public EnemyKilledObserverUI(PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
    }

    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as EnemyKilledSubject;
    }

    public override void Update()
    {
        m_PBDGame.ShowGameMsg("敌方单位阵亡");
    }
}
