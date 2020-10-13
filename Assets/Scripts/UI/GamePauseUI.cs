using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : IUserInterface
{
    private Text m_EnemyKilledCountText = null;
    private Text m_SoldierKilledCountText = null;
    private Text m_StageLvCountText = null;



    public GamePauseUI(PBaseDefenseGame PBDGame) : base(PBDGame)
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

    public void ShowGamePause(AchievementSaveData SaveData)
    {
        m_EnemyKilledCountText.text = string.Format("当前杀敌数总和： {0}", SaveData.EnemyKilledCount);
        m_SoldierKilledCountText.text = string.Format("当前我方单位阵亡总和： {0}", SaveData.SoldierKilledCount);
        m_StageLvCountText.text = string.Format("最高关卡数： {0}", SaveData.StageLv);

        Show();
    }
}
