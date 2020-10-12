using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageHandler : NormalStageHandler
{
    public BossStageHandler(IStageScore StageScore, IStageData StageData) : base(StageScore, StageData)
    {

    }

    public override int LoseHeart()
    {
        return StageSystem.MAX_HEART;
    }
}
