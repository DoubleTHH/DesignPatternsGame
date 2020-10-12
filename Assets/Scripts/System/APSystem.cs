using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APSystem : IGameSystem
{
    public APSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        m_PBDGame = PBDGame;
    }
    public override void Update()
    {
        base.Update();
    }
}
