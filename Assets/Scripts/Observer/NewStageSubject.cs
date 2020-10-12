using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageSubject : IGameEventSubject
{
    private int m_StageCount = 1;

    public NewStageSubject() { }

    public int GetStageCount()
    {
        return m_StageCount;
    }

    public override void SetParam(object Param)
    {
        base.SetParam(Param);
        m_StageCount = (int)Param;

        Notify();
    }
}
