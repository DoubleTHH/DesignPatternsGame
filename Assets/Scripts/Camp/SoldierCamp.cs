using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCamp : ICamp
{
    private const int MAX_LV = 3;
    private ENUM_Weapon m_emWeapon = ENUM_Weapon.Gun;
    private int m_Lv = 1;
    private Vector3 m_Position;

    public SoldierCamp(GameObject theGameObject, ENUM_Soldier emSoldier, string CampName
        ,string IconSprite, float TrainCoolDown, Vector3 Position ) : base (theGameObject,TrainCoolDown,CampName,IconSprite)
    {
        m_emSoldier = emSoldier;
        m_Position = Position;
    }

    public override int GetLevel()
    {
        return m_Lv;
    
    }

    public override int GetLevelUpCost()
    {
        if (m_Lv >= MAX_LV)
        {
            return 0;
        }
        return 100;
    }

    public override void LevelUp()
    {
        m_Lv++;
        m_Lv = Mathf.Min(m_Lv, MAX_LV);
    }

    public override ENUM_Weapon GetWeaponType()
    {
        return m_emWeapon;
    }

    public override int GetWeaponLevelUpCost()
    {
        if ((m_emWeapon +1) >= ENUM_Weapon.Max) 
        {
            m_emWeapon--;
        }
        return 100;
    }


    public override void WeaponLevelUp()
    {
        m_emWeapon++;
        if (m_emWeapon >= ENUM_Weapon.Max)
        {
            m_emWeapon--;
        }


    }
    public override int GetTrainCost()
    {
        return m_TrainCost.GetTrainCost(m_emSoldier, m_Lv, m_emWeapon);
    }

    public override void Train()
    {
        TrainSoldierCommand NewCommand = new TrainSoldierCommand(m_emSoldier, m_emWeapon, m_Lv, m_Position);
        AddTrainCommand(NewCommand);
    }


    private void OnAddSoldier()
    {
        ENUM_Weapon emWeapon = GetWeaponType();
        int Lv = GetLevel();
        Vector3 Position = GetPosition();
        ENUM_Soldier emSoldier = GetSoldierType();


        TrainSoldierCommand NewCommand = new TrainSoldierCommand(emSoldier, emWeapon, Lv, Position);

        NewCommand.Execute();
    }


    private Vector3 GetPosition()
    {
        return Vector3.zero;
    }

}
