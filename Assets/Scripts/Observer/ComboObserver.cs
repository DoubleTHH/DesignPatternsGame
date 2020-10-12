using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboObserver : IGameEventObserver
{
    private SoldierKilledSubject m_SoldierKilledSubject = null;
    private EnemyKilledSubject m_EnemyKilledSubject = null;
    private PBaseDefenseGame m_PBDGame = null;

    private int m_EnemyComboCount = 0;
    private int m_SoldierKilledCount = 0;
    private int m_EnemyKilledCount = 0;


    public ComboObserver(PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
    }

    public override void SetSubject(IGameEventSubject theSubject)
    {
        if (theSubject is SoldierKilledSubject)
        {
            m_SoldierKilledSubject = theSubject as SoldierKilledSubject;
        }
        if (theSubject is EnemyKilledSubject)
        {
            m_EnemyKilledSubject = theSubject as EnemyKilledSubject ;
        }
    }

    public override void Update()
    {
        int NowSoldierKilledCount = m_SoldierKilledSubject.GetKilledCount();
        int NowEnemyKilledCount = m_EnemyKilledSubject.GetKilledCount();

        if (NowSoldierKilledCount > m_SoldierKilledCount)//当我方士兵死亡，combo为0
        {
            m_EnemyComboCount = 0;
        }

        if (NowEnemyKilledCount > m_EnemyKilledCount)//当地方士兵死亡，combo++
        {
            m_EnemyKilledCount++;
        }


        m_SoldierKilledCount = NowSoldierKilledCount;
        m_EnemyKilledCount = NowEnemyKilledCount;

        m_PBDGame.ShowGameMsg("连续击退敌人数: " + m_EnemyComboCount.ToString());
    }
}
