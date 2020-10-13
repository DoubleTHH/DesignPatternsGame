using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierInfoUI : IUserInterface
{
    private ISoldier m_Soldier = null;

    private Image m_Icon = null;
    private Text m_NameTxt = null;
    private Text m_HPTxt = null;
    private Text m_LvTxt = null;
    private Text m_AtkTxt = null;
    private Text m_AtkRangeTxt = null;
    private Text m_SpeedTxt = null;
    private Slider m_HPSlider = null;

    public SoldierInfoUI(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        Initialize();
    }
    public override void Hide()
    {
        base.Hide();
        m_Soldier = null;
    }

    public override void Initialize()
    {
        m_RootUI = UITool.FindUIGameObject("SoldierInfoUI");

        m_Icon = UITool.GetUIComponent<Image>(m_RootUI, "SoldierIcon");

        m_NameTxt = UITool.GetUIComponent<Text>(m_RootUI, "SoldierNameText");

        m_HPTxt = UITool.GetUIComponent<Text>(m_RootUI, "SoldierHPText");
        m_LvTxt = UITool.GetUIComponent<Text>(m_RootUI, "SoldierLvText");
        m_AtkTxt = UITool.GetUIComponent<Text>(m_RootUI, "SoldierAtkText");
        m_AtkRangeTxt = UITool.GetUIComponent<Text>(m_RootUI, "SoldierAtkRangeText");
        m_SpeedTxt = UITool.GetUIComponent<Text>(m_RootUI, "SoldierSpeedText");


        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.SoldierKilled, new SoldierKilledObserverUI(this));

        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.SoldierUpgrate, new SoldierUpgateObserverUI(this));

        Hide();
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
        if (m_Soldier == null)
        {
            return;
        }

        if (m_Soldier.IsKilled())
        {
            m_Soldier = null;
            Hide();
            return;
        }


        RefreshHPInfo();
    }


    public void ShowInfo(ISoldier Soldier)
    {
        m_Soldier = Soldier;
        if (m_Soldier == null || m_Soldier.IsKilled())
        {
            Hide();
            return;
        }

        Show();


        IAssetFactory Factory = PBDFactory.GetAssetFactory();
        m_Icon.sprite = Factory.LoadSprite(m_Soldier.GetIconSpriteName());

        m_NameTxt.text = m_Soldier.GetName();

        //m_LvTxt.text = string.Format("等级 : {0}", m_Soldier.)


        RefreshHPInfo();
    }


    public void RefreshSoldier(ISoldier Soldier)
    {
        if (Soldier == null)
        {
            m_Soldier = null;
            Hide();
        }

        if (m_Soldier != Soldier)
        {
            return;
        }

        ShowInfo(Soldier);
    }


    public void RefreshHPInfo()
    {
        //int NowHP = m_Soldier.GetSoldierValue()

    }
}
