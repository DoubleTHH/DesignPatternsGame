using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageObserverAchievement : IGameEventObserver
{
    private NewStageSubject m_Subject = null;
    private AchievementSystem m_AchievementSystem = null;

    public NewStageObserverAchievement(AchievementSystem theAchievementSystem)
    {
        m_AchievementSystem = theAchievementSystem;
    }

    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as NewStageSubject;
    }

    public override void Update()
    {
        m_AchievementSystem.SetNowStageLevel(m_Subject.GetStageCount());
    }
}
