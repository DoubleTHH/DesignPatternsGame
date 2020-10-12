using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSoldierCommand : ITrainCommand
{
    private ENUM_Soldier m_emSoldier;
    private ENUM_Weapon m_emWeapon;
    private int m_Lv;
    private Vector3 m_Position;

    public TrainSoldierCommand(ENUM_Soldier emSoldier, ENUM_Weapon emWeapon,int Lv, Vector3 Position)
    {
        m_emSoldier = emSoldier;
        m_emWeapon = emWeapon;
        m_Lv = Lv;
        m_Position = Position;
    }
    public override void Execute()
    {
        ICharacterFactory Factory = PBDFactory.GetCharacterFactory();
        ISoldier Soldier = Factory.CreateSoldier(m_emSoldier, m_emWeapon, m_Lv, m_Position);

    }
}
