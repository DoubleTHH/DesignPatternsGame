using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : ISceneState
{
    public MainMenuState(SceneStateController Controller) : base(Controller)
    {
        this.StateName = G.MAIN_MENU_STATE;
    }

    public override void StateBegin()
    {
        //Button temp = UITool
    }

    void OnStartGameBtnClick()
    {
        m_Controller.SetState(new BattleState(m_Controller), G.BATTLE_STATE);
    }
}
