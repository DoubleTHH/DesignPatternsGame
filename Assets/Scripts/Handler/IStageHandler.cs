using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IStageHandler
{
    protected IStageData m_StageData = null;
    protected IStageScore m_StageScore = null;
    protected IStageHandler m_NextHandler = null;

    public IStageHandler SetNextHandler(IStageHandler NextHandler)
    {
        m_NextHandler = NextHandler;
        return m_NextHandler;
    }

    public abstract IStageHandler CheckStage();
    public abstract void Update();
    public abstract void Reset();
    public abstract bool IsFinished();
    public abstract int LoseHeart();
}
