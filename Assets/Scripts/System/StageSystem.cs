using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : IGameSystem
{

    private List<IStageHandler> m_StageHandlers;
    public const int MAX_HEART = 3;
    private int m_NowHeart = MAX_HEART;
    private int m_NowStageLv = 1;
    private int m_EnemyKilledCount = 0;


    private IStageHandler m_NowStageHandler = null;
    private IStageHandler m_RootStageHandler = null;

    private List<Vector3> m_SpawnPosition = null;
    private Vector3 m_AttackPos = Vector3.zero;
    private bool m_bCreateStage = false;

    public StageSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        Initialize();
    }

    public override void Initialize()
    {
        InitializeStageData();
        m_NowStageHandler = m_RootStageHandler;
        m_NowStageLv = 1;
    }

    public override void Release()
    {
        base.Release();
        m_SpawnPosition.Clear();
        m_SpawnPosition = null;
        m_AttackPos = Vector3.zero;
        m_NowHeart = MAX_HEART;
        m_EnemyKilledCount = 0;
    }

    public void LoseHeart()
    {
        m_NowHeart--;
        m_PBDGame.ShowHeart(m_NowHeart);
    }

    public void AddEnemyKilledCount()
    {
        m_EnemyKilledCount++;
    }

    public void SetEnemyKilledCount(int KilledCount)
    {
        m_EnemyKilledCount = KilledCount;
    }

    public int GetEnmeyKilledCount()
    {
        return m_EnemyKilledCount;
    }

    private void InitializeStageData()
    {
        if (m_RootStageHandler !=null)
        {
            return;
        }

        Vector3 AttackPosition = GetAttackPosition();

        NormalStageData StageData = null;
        IStageScore StageScore = null;
        IStageHandler NewStage = null;

        //第一关
        StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
        StageData.AddStageData(ENUM_Enemy.Elf, ENUM_Weapon.Gun, 3);
        StageScore = new StageScoreEnemyKilledCount(3, this);
        NewStage = new NormalStageHandler(StageScore, StageData);

        StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
        StageData.AddStageData(ENUM_Enemy.Elf, ENUM_Weapon.Rocket, 3);
        StageData.AddStageData(ENUM_Enemy.Troll, ENUM_Weapon.Rocket, 3);
        StageData.AddStageData(ENUM_Enemy.Ogre, ENUM_Weapon.Rocket, 3);

        StageScore = new StageScoreEnemyKilledCount(30, this);
        NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));

    }

    public override void Update()
    {
        m_NowStageHandler.Update();

        if (m_PBDGame.GetEnemyCount() == 0)
        {
            IStageHandler NewStageData = m_NowStageHandler.CheckStage();
            if (!NewStageData.IsFinished())
            {
                return;
            }

            if (m_NowStageHandler == NewStageData)
            {
                m_NowStageHandler.Reset();
            }
            else
            {
                m_NowStageHandler = NewStageData;
            }

            NotiyfNewStage();
        }
    }


    public void LoadHeart()
    {
        m_NowHeart -= m_NowStageHandler.LoseHeart();
        m_PBDGame.ShowHeart(m_NowHeart);
    }


    private void NotiyfNewStage()
    {
        m_PBDGame.ShowGameMsg("新的关卡");
        m_NowStageLv++;


        m_PBDGame.ShowNowStageLv(m_NowStageLv);

        m_PBDGame.UpgateSoldier();

        m_PBDGame.NotifyGameEvent(ENUM_GameEvent.NewStage);
    }



    private void CreateStage()
    {
        ICharacterFactory Factory = PBDFactory.GetCharacterFactory();
        Vector3 AttackPosition = GetAttackPosition();
        switch (m_NowStageLv)
        {
            case 1:
                Factory.CreateEnemy(ENUM_Enemy.Elf, ENUM_Weapon.Gun, GetSpawnPosition(), AttackPosition);
                Factory.CreateEnemy(ENUM_Enemy.Elf, ENUM_Weapon.Gun, GetSpawnPosition(), AttackPosition);
                Factory.CreateEnemy(ENUM_Enemy.Elf, ENUM_Weapon.Gun, GetSpawnPosition(), AttackPosition);
                break;
            default:
                break;
        }
    }


    private bool CheckNextStage()
    {
        switch (m_NowStageLv)
        {
            case 1:
                if (GetEnmeyKilledCount() >=3)
                {
                    return true;
                }
                break;
            default:
                return false;
                break;
        }
        return false;
    }


    private Vector3 GetSpawnPosition()
    {
        if (m_SpawnPosition == null)
        {
            m_SpawnPosition = new List<Vector3>();
            for (int i = 1; i <=3; ++i)
            {
                string name = string.Format("EnemySpawnPosition{0}", i);
                GameObject tempObj = UnityTool.FindGameObject(name);
                if (tempObj == null)
                {
                    continue;
                }

                tempObj.SetActive(false);
                m_SpawnPosition.Add(tempObj.transform.position);
            }
        }


        int index = Random.Range(0, m_SpawnPosition.Count - 1);
        return m_SpawnPosition[index];
    }


    private Vector3 GetAttackPosition()
    {
        if (m_AttackPos == Vector3.zero)
        {
            GameObject tempObj = UnityTool.FindGameObject("EnmeyAttackPosition");
            if (tempObj == null)
            {
                return Vector3.zero;
            }

            tempObj.SetActive(false);
            m_AttackPos = tempObj.transform.position;
        }
        return m_AttackPos;
    }
}
