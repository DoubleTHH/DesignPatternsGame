using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampInfoUI : IUserInterface
{
    private Text m_AliveCountTxt = null, m_CampLvTxt = null, m_WeaponLvTxt = null, m_TrainCostText = null, m_TrainTimerTxt = null,
        m_OnTrainCountTxt = null, m_CampNameTxt = null;
    private Image m_CampImage = null;
    private ICamp m_Camp;

    private Button m_LevelUpBtn = null, m_WeaponLvUpBtn = null, m_TrainBtn = null, m_CancelBtn = null;
    public CampInfoUI(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        Initialize();
    }

    
    public override void Hide()
    {
        base.Hide();
    }

    public override void Initialize()
    {
        m_RootUI = UITool.FindUIGameObject("CampInfoUI");


        m_CampLvTxt = UITool.GetUIComponent<Text>(m_RootUI, "CampNameText");
        m_CampImage = UITool.GetUIComponent<Image>(m_RootUI, "CampIcon");
        m_AliveCountTxt = UITool.GetUIComponent<Text>(m_RootUI, "AliveCountText");
        m_CampLvTxt = UITool.GetUIComponent<Text>(m_RootUI, "CampLevelText");
        m_WeaponLvTxt = UITool.GetUIComponent<Text>(m_RootUI, "WeaponLevelText");
        m_OnTrainCountTxt = UITool.GetUIComponent<Text>(m_RootUI, "TrainCostText");
        m_TrainTimerTxt = UITool.GetUIComponent<Text>(m_RootUI, "TrainTimerText");


        m_LevelUpBtn = UITool.GetUIComponent<Button>(m_RootUI, "CampLevelUpBtn");
        m_LevelUpBtn.onClick.AddListener(() => { OnLevelUpBtnClick(); });

        m_WeaponLvUpBtn = UITool.GetUIComponent<Button>(m_RootUI, "WeaponLevelUpBtn");
        m_WeaponLvUpBtn.onClick.AddListener(() => { OnWeaponLevelUpBtnClick(); });

        m_TrainBtn = UITool.GetUIComponent<Button>(m_RootUI, "TrainSoldierBtn");
        m_TrainBtn.onClick.AddListener(() => { OnTrainBtnClick(); });

        m_CancelBtn = UITool.GetUIComponent<Button>(m_RootUI, "CancelTrainBtn");
        m_CancelBtn.onClick.AddListener(() => { OnCancelBtnClick(); });


        Hide();
    }

    private void OnCancelBtnClick()
    {
        m_Camp.RemoveLastTrainCommand();
        ShowInfo(m_Camp);
    }

    private void OnTrainBtnClick()
    {
        int Cost = m_Camp.GetTrainCost();
        if (!CheckRule(Cost > 0, "无法训练"))
        {
            return;
        }

        string Msg = string.Format("AP不足无法训练，需要{0}点AP", Cost);
        if (!CheckRule(m_PBDGame.CostAP(Cost), Msg))
        {
            return;
        }

        m_Camp.Train();
        ShowInfo(m_Camp);

    }

    private bool CheckRule(bool isEnough, string tips)
    {
        return false;
    }
    private void OnWeaponLevelUpBtnClick()
    {
        int Cost = m_Camp.GetWeaponLevelUpCost();
        if (!CheckRule(Cost > 0, "已达最高等级"))
            return;
        string Msg = string.Format("AP不足无法升级，需要{0}点AP", Cost);
        if (!CheckRule(m_PBDGame.CostAP(Cost), Msg))
            return;

        m_Camp.WeaponLevelUp();
        ShowInfo(m_Camp);
    }

    private void OnLevelUpBtnClick()
    {
        int Cost = m_Camp.GetLevelUpCost();
        if (!CheckRule(Cost > 0, "已达最高等级"))
            return;
        string Msg = string.Format("AP不足无法升级，需要{0}点AP", Cost);
        if (!CheckRule(m_PBDGame.CostAP(Cost), Msg))
            return;

        m_Camp.LevelUp();
        ShowInfo(m_Camp);
    }


    public void ShowInfo(ICamp Camp)
    {
        Show();
        m_Camp = Camp;
        m_CampNameTxt.text = m_Camp.GetName();

        m_TrainCostText.text = string.Format("AP:{0}", m_Camp.GetTrainCost());
        ShowOnTrainInfo();

        IAssetFactory Factory = PBDFactory.GetAssetFactory();
        m_CampImage.sprite = Factory.LoadSprite(m_Camp.GetIconSpriteName());

        if (m_Camp.GetLevel() <=0)
        {
            EnableLevelInfo(false);
        }
        else
        {
            EnableLevelInfo(true);
            m_CampLvTxt.text = string.Format("等级： " + m_Camp.GetLevel());

            ShowWeaponLv();
        }


    }


    private void ShowWeaponLv()
    {

    }

    private void EnableLevelInfo(bool isOn)
    {

    }

    public void ShowOnTrainInfo()
    {

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
