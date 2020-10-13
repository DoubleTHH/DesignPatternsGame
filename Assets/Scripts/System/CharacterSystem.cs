using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CharacterSystem : IGameSystem
{
    private List<ICharacter> m_Soldiers = new List<ICharacter>();
    private List<ICharacter> m_Enemys = new List<ICharacter>();


    public CharacterSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        m_PBDGame = PBDGame;
    }

    public void AddSoldier(ISoldier theSoldier)
    {
        m_Soldiers.Add(theSoldier);
    }

    public void RemoveSoldier(ISoldier theSoldier)
    {
        m_Soldiers.Remove(theSoldier);
    }

    public void AddEnemy(IEnemy theEnemy)
    {
        m_Enemys.Add(theEnemy);
    }

    public void RemoveEnemy(IEnemy theEnemy)
    {
        m_Enemys.Remove(theEnemy);
    }

    public void RemoveCharacter()
    {
        RemoveCharacter(m_Soldiers, m_Enemys, ENUM_GameEvent.SoldierKilled);
        RemoveCharacter(m_Enemys, m_Soldiers, ENUM_GameEvent.EnemyKilled);

    }


    public void RemoveCharacter(List<ICharacter> Characters, List<ICharacter> Opponents, ENUM_GameEvent emEvent)
    {
        List<ICharacter> CanRemoves = new List<ICharacter>();
        foreach (ICharacter Character in Characters)
        {
            if (!Character.IsKilled())
                continue;

            if (!Character.CheckKilledEvent())
            {
                m_PBDGame.NotifyGameEvent(emEvent, Character);
            }

            if (Character.CanRemove())
            {
                CanRemoves.Add(Character);
            }
        }


        foreach (ICharacter CanRemove in CanRemoves)
        {
            foreach (ICharacter Opponent in Opponents)
            {
                Opponent.RemoveAITarget(CanRemove);
            }


            CanRemove.Release();
            Characters.Remove(CanRemove);
        }


    }

    private void UpdateCharacter()
    {
        foreach (ICharacter Character in m_Soldiers)
        {
            Character.Update();
        }

        foreach (ICharacter Character in m_Enemys)
        {
            Character.Update();
        }
    }


    private void UpdateAI()
    {
        UpdateAI(m_Soldiers, m_Enemys);
        UpdateAI(m_Enemys, m_Soldiers);

        RemoveCharacter();
    }

    private void UpdateAI(List<ICharacter> Characters, List<ICharacter> Targets)
    {
        foreach (ICharacter Character in Characters)
        {
            Character.UpdateAI(Targets);
        }
    }

    public override void Update()
    {

    }

    public int GetSoldierCount()
    {
        return m_Soldiers.Count; ;
    }

    public int GetSoldierCount(ENUM_Soldier emSoldier)
    {
        int Count = 0;
        foreach (ISoldier pSoldier in m_Soldiers)
        {
            if (pSoldier == null)
            {
                continue;
            }

            if (pSoldier.GetSoldierType() == emSoldier)
            {
                Count++;
            }

            return Count;
        }
        return m_Soldiers.Count;
    }

    public int GetEnemyCount()
    {
        return m_Enemys.Count;
    }
}
