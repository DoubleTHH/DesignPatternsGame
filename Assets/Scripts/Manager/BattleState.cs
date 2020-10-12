using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : ISceneState
{
    public BattleState(SceneStateController Controller) : base(Controller)
    {
        this.StateName = G.BATTLE_STATE;
    }

    public override void StateBegin()
    {
        PBaseDefenseGame.Instance.Initinal();
    }

    public override void StateEnd()
    {
        PBaseDefenseGame.Instance.Release();
    }

    public override void StateUpdate()
    {
        PBaseDefenseGame.Instance.Update();

        if (PBaseDefenseGame.Instance.ThisGameIsOver())
        {
            m_Controller.SetState(new MainMenuState(m_Controller), G.MAIN_MENU_STATE);
        }
    }
}
