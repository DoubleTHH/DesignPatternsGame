using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSystem : IGameSystem
{
    private Dictionary<ENUM_Soldier, ICamp> m_SoldierCamps = new Dictionary<ENUM_Soldier, ICamp>();

    public CampSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        Initialize();
    }

    public override void Initialize()
    {
        m_SoldierCamps.Add(ENUM_Soldier.Rookie, SoldierCampFactory(ENUM_Soldier.Rookie));
        m_SoldierCamps.Add(ENUM_Soldier.Sergeant, SoldierCampFactory(ENUM_Soldier.Sergeant));
        m_SoldierCamps.Add(ENUM_Soldier.Captain, SoldierCampFactory(ENUM_Soldier.Captain));
    }


    private SoldierCamp SoldierCampFactory(ENUM_Soldier emSoldier)
    {
        string GameObjectName = "SoldierCamp_";
        float CoolDown = 0;
        string CampName = "";
        string IconSprite = "";
        switch (emSoldier)
        {
            case ENUM_Soldier.Rookie:
                GameObjectName += "Rookie";
                CoolDown = 3;
                CampName = "菜鸟兵营";
                IconSprite = "RookieCamp";
                break;
            case ENUM_Soldier.Sergeant:
                GameObjectName += "Sergeant";
                CoolDown = 4;
                CampName = "中士兵营";
                IconSprite = "SergeantCamp";
                break;
            case ENUM_Soldier.Captain:
                GameObjectName += "Captain";
                CoolDown = 5;
                IconSprite = "上尉兵营";
                break;
            default:
                Debug.Log("没有指定[" + emSoldier + "]要获取的场景对象名称");
                break;
        }


        GameObject theGameObject = UnityTool.FindGameObject(GameObjectName);

        Vector3 TrainPoint = GetTrainPoint(GameObjectName);
        SoldierCamp NewCamp = new SoldierCamp(theGameObject, emSoldier, CampName, IconSprite, CoolDown, TrainPoint);

        NewCamp.SetPBaseDefenseGame(m_PBDGame);

        AddCampScript(theGameObject, NewCamp);
        return NewCamp;
    }


    private Vector3 GetTrainPoint(string GameObjectName)
    {
        GameObject theCamp = UnityTool.FindGameObject(GameObjectName);
        GameObject theTrainPoint = UnityTool.FindChildGameObject(theCamp, "TrainPoint");
        theTrainPoint.SetActive(false);
        return theTrainPoint.transform.position;
    }

    private void AddCampScript(GameObject theGameObject, ICamp Camp)
    {
        CampOnClick CampScript = theGameObject.AddComponent<CampOnClick>();
        CampScript.theCamp = Camp ;
    }

    public void ShowCaptiveCamp()
    {
        //m_PBDGame.
    }
    public override void Update(){
        foreach (SoldierCamp Camp in m_SoldierCamps.Values)
        {
            Camp.RunCommand();
        }
    
    }
}
