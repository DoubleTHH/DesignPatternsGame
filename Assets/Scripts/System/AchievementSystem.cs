using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AchievementSystem : IGameSystem
{
    private int m_EnemyKilledCount = 0;
    private int m_SoldierKilledCount = 0;
    private int m_StageLv = 0;
    private bool m_KillOgreEquipRocket = false;


    public AchievementSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        Initialize();
    }



    public override void Initialize()
    {
        base.Initialize();


        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.EnemyKilled, new EnemyKilledObserverAchievement(this));
        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.SoldierKilled, new SoldierKilledObserverAchievement(this));
        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.NewStage, new NewStageObserverAchievement(this));
    }

    public void AddEnemyKilledCount()
    {
        m_EnemyKilledCount++;

    }

    public void AddSoldierKilledCount()
    {
        m_SoldierKilledCount++;
    }

    public void SetNowStageLevel(int NowStageLevel)
    {
        m_StageLv = NowStageLevel;
    }

    public void NotifyGameEvent(ENUM_GameEvent emGameEvent, System.Object Param1,System.Object Param2)
    {
        switch (emGameEvent)
        {
            case ENUM_GameEvent.NewStage:
                break;
            case ENUM_GameEvent.EnemyKilled:
                break;
            case ENUM_GameEvent.SoldierKilled:
                break;
            case ENUM_GameEvent.SoldierUpgrate:
                break;
            default:
                break;
        }
    }

    public int GetEnmeyKilledCount()
    {
        return m_EnemyKilledCount;
    }

    public int GetSoldierKilledCount()
    {
        return m_SoldierKilledCount;
    }

    public int GetStageLv()
    {
        return m_StageLv;
    }

    public void SetEnemyKilledCount(int iValue)
    {
        m_EnemyKilledCount = iValue;
    }

    public void SetSoldierKilledCount(int iValue)
    {
        m_SoldierKilledCount = iValue;
    }

    public void SetStageLv(int iValue)
    {
        m_StageLv = iValue;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("EnemyKilledCount", m_EnemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount", m_SoldierKilledCount);
        PlayerPrefs.SetInt("StageLv", m_StageLv);
    }

    public void LoadData()
    {
        m_EnemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount", 0);
        m_SoldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount", 0);
        m_StageLv = PlayerPrefs.GetInt("StageLv", 0);
    }

    public override void Update()
    {
        base.Update();
    }
}
