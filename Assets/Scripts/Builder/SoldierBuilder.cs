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

    public override void SetBuildParam(ICharacterBuildParam theParam)
    {
        m_BuildParam = theParam as SoldierBuilderParam;
    }

    public override void LoadAsset(int GameObjectID)
    {
        IAssetFactory AssetFactory = PBDFactory.GetAssetFactory();
        GameObject SoldierGameObject = AssetFactory.LoadEnemy(m_BuildParam.NewCharacter.GetAssetName());
        SoldierGameObject.transform.position = m_BuildParam.SpawnPosition;
        SoldierGameObject.gameObject.name = string.Format("Soldier[{0}]", GameObjectID);
        m_BuildParam.NewCharacter.SetGameObject(SoldierGameObject);

    }

    public override void AddOnClickScript()
    {
        SoldierOnClick Script = m_BuildParam.NewCharacter.GetGameObject().AddComponent<SoldierOnClick>();
        Script.Soldier = m_BuildParam.NewCharacter as ISoldier;

    }


    public override void AddWeapon()
    {
        IWeaponFactory WeaponFactory = PBDFactory.GetWeaponFactory();
        IWeapon Weapon = WeaponFactory.CreateWeapon(m_BuildParam.emWeapon);

        // 設定給角色
        m_BuildParam.NewCharacter.SetWeapon(Weapon);
    }

    public override void SetCharacterAttr()
    {
        // 取得Enemy的數值
        IAttrFactory theAttrFactory = PBDFactory.GetAttrFactory();
        int AttrID = m_BuildParam.NewCharacter.GetAttrID();
        SoldierAttr theSoldierAttr = theAttrFactory.GetSoldierAttr(AttrID);

        // 設定數值的計算策略
        theSoldierAttr.SetAttStrategy(new SoldierAttrStrategy());

        // 設定給角色
        m_BuildParam.NewCharacter.SetCharacterAttr(theSoldierAttr);
    }


    public override void AddAI()
    {
        SoldierAI theAI = new SoldierAI(m_BuildParam.NewCharacter);
        m_BuildParam.NewCharacter.SetAI(theAI);
    }


    public override void AddCharacterSystem(PBaseDefenseGame PBDGame)
    {
        PBDGame.AddSoldier(m_BuildParam.NewCharacter as ISoldier);
    }

    public override void AddBornEffect()
    {
        Debug.Log("未定义出生特效");
    }


    public override void AddHub()
    {
        Debug.Log("未定义社区");
    }
}
