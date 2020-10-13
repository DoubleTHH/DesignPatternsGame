using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBuilderParam : ICharacterBuildParam
{
    public int Lv = 0;
    public SoldierBuilderParam() { }
}

public class SoldierBuilder : ICharacterBuilder
{
    private SoldierBuilderParam m_BuildParam = null;


    public override void AddAI()
    {
        SoldierAI theAI = new SoldierAI(m_BuildParam.NewCharacter);
        m_BuildParam.NewCharacter.SetAI(theAI);
    }

    public override void AddBornEffect()
    {
        throw new System.NotImplementedException();
    }

    public override void AddCharacterSystem(PBaseDefenseGame PBDGame)
    {
        PBDGame.AddSoldier(m_BuildParam.NewCharacter as ISoldier);
    }

    public override void AddHub()
    {
        throw new System.NotImplementedException();
    }

    public override void AddOnClickScript()
    {
        SoldierOnClick Script = m_BuildParam.NewCharacter.GetGameObject().AddComponent<SoldierOnClick>();
        Script.Soldier = m_BuildParam.NewCharacter as ISoldier;

    }

    public override void AddWeapon()
    {
        IWeaponFactory WeaponFactory = PBDFactory.GetWeaponFactory();
        //IWeapon Weapon = WeaponFactory.cr
    }

    public override void LoadAsset(int GameObjectID)
    {
        IAssetFactory AssetFactory = PBDFactory.GetAssetFactory();
        //GameObject SoldierGameObject = AssetFactory.load

    }

    public override void SetBuildParam(ICharacterBuildParam theParam)
    {
        m_BuildParam = theParam as SoldierBuilderParam;
    }

    public override void SetCharacterAttr()
    {
        IAttrFactory theAttrFactory = PBDFactory.GetAttrFactory();
        int AttrID = m_BuildParam.NewCharacter.GetAttrID();

        //SoldierAttr theSoldierAttr = theAttrFactory.GetSoldierAttr(AttrID);
    }


}
