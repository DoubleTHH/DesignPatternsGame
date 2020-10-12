using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateInfoUI : IUserInterface
{
    public GameStateInfoUI(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        m_PBDGame = PBDGame;
    }
    public override void Hide()
    {
        base.Hide();
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Show()
    {
        base.Show();
    }


    public override void Update()
    {
        base.Update();
    }
}
