using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBaseDefenseGame
{
    static PBaseDefenseGame _instance;
    public static PBaseDefenseGame Instance
    {
        get
        {
            if (_instance == null)
                _instance = new PBaseDefenseGame();
            return _instance;
        }
    }

    PBaseDefenseGame() { }
    bool m_bGameOver;

    // 系统
    GameEventSystem m_GameEventSystem = null;
    CampSystem m_CampSystem = null;
    StageSystem m_StageSystem = null;
    CharacterSystem m_CharacterSystem = null;
    APSystem m_APSystem = null;
    AchievementSystem m_AchievementSystem = null;


    //界面
    CampInfoUI m_CampInfoUI = null;
    SoldierInfoUI m_SoldierInfoUI = null;
    GameStateInfoUI m_GameStateInfoUI = null;
    GamePauseUI m_GamePauseUI = null;
    public void Initinal()
    {
        m_bGameOver = false;

        m_GameEventSystem = new GameEventSystem(this);
        m_CampSystem = new CampSystem(this);
        m_StageSystem = new StageSystem(this);
        m_CharacterSystem = new CharacterSystem(this);
        m_APSystem = new APSystem(this);
        m_AchievementSystem = new AchievementSystem(this);

        m_CampInfoUI = new CampInfoUI(this);
        m_SoldierInfoUI = new SoldierInfoUI(this);
        m_GameStateInfoUI = new GameStateInfoUI(this);
        m_GamePauseUI = new GamePauseUI(this);
    }

    public void Update()
    {
        Inputprocess();

        m_GameEventSystem.Update();
        m_CampSystem.Update();
        m_StageSystem.Update();
        m_CharacterSystem.Update();
        m_APSystem.Update();
        m_AchievementSystem.Update();

        m_CampInfoUI.Update();
        m_SoldierInfoUI.Update();
        m_GameStateInfoUI.Update();
        m_GamePauseUI.Update();
    }

    public void Release()
    {

    }

    public bool ThisGameIsOver()
    {
        return m_bGameOver;
    }


    //public int GetUnitCount()
    //{

    //}

    //public int GetUnitCount()
    //{

    //}


    public void AddSoldier(ISoldier soldier)
    {

    }

    public void AddEnemy(IEnemy enemy)
    {

    }

    void Inputprocess()
    {
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            CampOnClick CampClickScript = hit.transform.gameObject.GetComponent<CampOnClick>();
            if (CampClickScript != null)
            {
                return;
            }


            SoldierOnClick SoldierOnClickScript = hit.transform.gameObject.GetComponent<SoldierOnClick>();
            if (SoldierOnClickScript != null)
            {
                SoldierOnClickScript.OnClick();
                return;
            }
        }
    }


    public void ShowCampInfo(ICamp Camp)
    {
        m_CampInfoUI.ShowInfo(Camp);
        m_SoldierInfoUI.Hide();
    }

    public void ShowGameMsg(string msg)
    {

    }

    public void ShowNowStageLv(int lv)
    {

    }

    public void UpgateSoldier()
    {

    }

    public void NotifyGameEvent(ENUM_GameEvent newStage)
    {

    }

    public void NotifyGameEvent(ENUM_GameEvent newStage, ICharacter character)
    {

    }

    public void RegisterGameEvent(ENUM_GameEvent eNUM_GameEvent, IGameEventObserver gameEventObserver)
    {

    }


    private void ResigerGameEvent()
    {
        m_GameEventSystem.RegisterObserver(ENUM_GameEvent.EnemyKilled, new EnemyKilledObserverUI(this));

        ComboObserver theComboObserver = new ComboObserver(this);
        m_GameEventSystem.RegisterObserver(ENUM_GameEvent.EnemyKilled, theComboObserver);
        m_GameEventSystem.RegisterObserver(ENUM_GameEvent.SoldierKilled, theComboObserver);



    }

    public void ShowHeart(int heart)
    {

    }

    public bool CostAP(int cost)
    {
        return false;
    }

    private void SaveData()
    {
        AchievementSaveData SaveData = m_AchievementSystem.CreateSaveData();
        SaveData.SaveData();
    }


    private AchievementSaveData LoadData()
    {
        AchievementSaveData OldData = new AchievementSaveData();
        OldData.LoadData();
        m_AchievementSystem.SetSaveData(OldData);
        return OldData;
    }

    public void ShowSoldierInfo(ISoldier soldier)
    {

    }


    public int GetSoldierCount()
    {
        if (m_CharacterSystem != null)
        {
            return m_CharacterSystem.GetSoldierCount();
        }

        return 0;
    }


    public int GetEnemyCount()
    {
        if (m_CharacterSystem != null)
        {
            return m_CharacterSystem.GetEnemyCount();
        }

        return 0;
    }
}
