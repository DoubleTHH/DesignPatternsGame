using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStageHandler : IStageHandler
{

    protected IStageData m_StageData = null;
    public NormalStageHandler (IStageScore StateScore, IStageData StageData)
    {
        m_StageScore = StateScore;
        m_StageData = StageData;
    }



    public override IStageHandler CheckStage()
    {
        if (!m_StageScore.CheckScore())
        {
            return this;
        }


        if (m_NextHandler == null)
        {
            return this;
        }

        return m_NextHandler.CheckStage();
    }

    public override bool IsFinished()
    {
        return m_StageData.IsFinished();
    }

    public override int LoseHeart()
    {
        return 1;
    }

    public override void Reset()
    {
        m_StageData.Reset();
    }

    public override void Update()
    {
        m_StageData.Update();
    }
}
