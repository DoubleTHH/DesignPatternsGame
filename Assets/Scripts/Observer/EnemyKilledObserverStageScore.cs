using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledObserverStageScore : IGameEventObserver
{
    private EnemyKilledSubject m_Subject = null;
    private StageSystem m_StageSystem = null;

    public EnemyKilledObserverStageScore(StageSystem theStageSystem)
    {
        m_StageSystem = theStageSystem;
    }




    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as EnemyKilledSubject;
    }

    public override void Update()
    {
        m_StageSystem.SetEnemyKilledCount(m_Subject.GetKilledCount());
    }
}
