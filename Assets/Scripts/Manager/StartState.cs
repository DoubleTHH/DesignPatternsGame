using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : ISceneState
{
    public StartState(SceneStateController Controller) : base(Controller) {
        this.StateName = G.START_STATE;
    }

    public override void StateBegin()
    {
        base.StateBegin();
    }

    public override void StateUpdate()
    {
        m_Controller.SetState(new MainMenuState(m_Controller), G.MAIN_MENU_STATE);
    }
}
