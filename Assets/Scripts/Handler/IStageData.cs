using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IStageData
{

    public abstract void Reset();

    public abstract bool IsFinished();

    public abstract void Update();
}
