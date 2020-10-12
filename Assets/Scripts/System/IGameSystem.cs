using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGameSystem {

    protected PBaseDefenseGame m_PBDGame = null;
    public IGameSystem (PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
    }

    public virtual void Initialize() { }

    public virtual void Release() { }

    public virtual void Update() { }


}
