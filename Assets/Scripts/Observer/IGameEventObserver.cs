using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGameEventObserver
{
    public abstract void SetSubject(IGameEventSubject theSubject);
    public abstract void Update();
}
