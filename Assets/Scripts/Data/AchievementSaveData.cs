using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSaveData
{
    public int EnemyKilledCount { get; set; }
    public int SoldierKilledCount { get; set; }
    public int StageLv { get; set; }

    public AchievementSaveData(){}


    public void SaveData()
    {

        PlayerPrefs.SetInt("EnemyKilledCount", EnemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount", SoldierKilledCount);
        PlayerPrefs.SetInt("StageLv", StageLv);
    }


    //public static void SaveData(AchievementSystem theSystem)
    //{

    //    PlayerPrefs.SetInt("EnemyKilledCount", theSystem.GetEnmeyKilledCount());
    //    PlayerPrefs.SetInt("SoldierKilledCount", theSystem.GetSoldierKilledCount());
    //    PlayerPrefs.SetInt("StageLv", theSystem.GetStageLv());
    //}


    public void LoadData()
    {
        EnemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount", 0);
        SoldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount", 0);
        StageLv = PlayerPrefs.GetInt("StageLv", 0);
        //int tempValue = 0;
        //tempValue = PlayerPrefs.GetInt("EnemyKilledCount", 0);
        //theSystem.SetEnemyKilledCount(tempValue);

        //tempValue = PlayerPrefs.GetInt("SoldierKilledCount", 0);
        //theSystem.SetSoldierKilledCount(tempValue);


        //tempValue = PlayerPrefs.GetInt("StageLv", 0);
        //theSystem.SetStageLv(tempValue);
    }

    //public static void LoadData(AchievementSystem theSystem)
    //{
    //    int tempValue = 0;
    //    tempValue = PlayerPrefs.GetInt("EnemyKilledCount", 0);
    //    theSystem.SetEnemyKilledCount(tempValue);

    //    tempValue = PlayerPrefs.GetInt("SoldierKilledCount", 0);
    //    theSystem.SetSoldierKilledCount(tempValue);


    //    tempValue = PlayerPrefs.GetInt("StageLv", 0);
    //    theSystem.SetStageLv(tempValue);
    //}
}
