using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledObserverAchievement : IGameEventObserver
{
    private EnemyKilledSubject m_Subject = null;
    private AchievementSystem m_AchievementSystem = null;

    public EnemyKilledObserverAchievement(AchievementSystem theAchievementSystem)
    {
        m_AchievementSystem = theAchievementSystem;
    }

    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as EnemyKilledSubject;
    }

    public override void Update()
    {
        m_AchievementSystem.AddEnemyKilledCount();
    }
}
