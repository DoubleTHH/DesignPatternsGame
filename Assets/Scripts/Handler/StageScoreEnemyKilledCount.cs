using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScoreEnemyKilledCount : IStageScore
{
    private int m_EnemyKilledCount = 0;
    private StageSystem m_StageSystem = null;


    public StageScoreEnemyKilledCount(int KilledCount, StageSystem theStageSystem)
    {
        m_EnemyKilledCount = KilledCount;
        m_StageSystem = theStageSystem;
    }

    public override bool CheckScore()
    {
        return (m_StageSystem.GetEnmeyKilledCount() >= m_EnemyKilledCount);
    }
}
