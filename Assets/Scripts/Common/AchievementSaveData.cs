using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AchievementSaveData
{
    public static void SaveData(AchievementSystem theSystem)
    {

        PlayerPrefs.SetInt("EnemyKilledCount", theSystem.GetEnmeyKilledCount());
        PlayerPrefs.SetInt("SoldierKilledCount", theSystem.GetSoldierKilledCount());
        PlayerPrefs.SetInt("StageLv", theSystem.GetStageLv());
    }


    public static void LoadData(AchievementSystem theSystem)
    {
        int tempValue = 0;
        tempValue = PlayerPrefs.GetInt("EnemyKilledCount", 0);
        theSystem.SetEnemyKilledCount(tempValue);

        tempValue = PlayerPrefs.GetInt("SoldierKilledCount", 0);
        theSystem.SetSoldierKilledCount(tempValue);


        tempValue = PlayerPrefs.GetInt("StageLv", 0);
        theSystem.SetStageLv(tempValue);
    }
}
