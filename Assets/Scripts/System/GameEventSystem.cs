using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_GameEvent
{
    Null = 0,
    EnemyKilled,
    SoldierKilled,
    SoldierUpgrate,
    NewStage,
}

public class GameEventSystem : IGameSystem
{
    private Dictionary<ENUM_GameEvent, IGameEventSubject> m_GameEvents = new Dictionary<ENUM_GameEvent, IGameEventSubject>();


    public GameEventSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        Initialize();
    }

    public override void Release()
    {
        m_GameEvents.Clear();
    }

    public void RegisterObserver(ENUM_GameEvent emGameEvent, IGameEventObserver Observer)
    {
        //IGameEventSubject Subject = ge
    }

    private IGameEventSubject GetGameEventSubject(ENUM_GameEvent emGameEvent)
    {
        if (m_GameEvents.ContainsKey(emGameEvent))
        {
            return m_GameEvents[emGameEvent];
        }


        IGameEventSubject pSubject = null;
        switch (emGameEvent)
        {
            case ENUM_GameEvent.Null:
                break;
            case ENUM_GameEvent.EnemyKilled:
                break;
            case ENUM_GameEvent.SoldierKilled:
                break;
            case ENUM_GameEvent.SoldierUpgrate:
                break;
            case ENUM_GameEvent.NewStage:
                break;
            default:
                break;
        }


        m_GameEvents.Add(emGameEvent, pSubject);

        return pSubject;
    }


    public void NotifySubject(ENUM_GameEvent emGameEvent, System.Object Param)
    {
        if (!m_GameEvents.ContainsKey(emGameEvent))
        {
            return;
        }

        m_GameEvents[emGameEvent].SetParam(Param);
    }

    public override void Update()
    {
        base.Update();
    }
}
