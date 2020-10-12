using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierKilledObserverAchievement : IGameEventObserver
{
    private SoldierKilledSubject m_Subject = null;
    private AchievementSystem m_AchievementSystem = null;

    public SoldierKilledObserverAchievement(AchievementSystem theAchievementSystem)
    {
        m_AchievementSystem = theAchievementSystem;
    }

    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as SoldierKilledSubject;
    }

    public override void Update()
    {
        m_AchievementSystem.AddEnemyKilledCount();
    }
}
