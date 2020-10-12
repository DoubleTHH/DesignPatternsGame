using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuildParam : ICharacterBuildParam
{
    public Vector3 AttackPosition = Vector3.zero;
    public EnemyBuildParam() { }
}

public class EnemyBuilder : ICharacterBuilder
{
    private EnemyBuildParam m_BuildParam = null;
    public override void AddAI()
    {
        EnemyAI theAI = new EnemyAI(m_BuildParam.NewCharacter, m_BuildParam.AttackPosition);
        m_BuildParam.NewCharacter.SetAI(theAI);
    }

    public override void AddBornEffect()
    {
        throw new System.NotImplementedException();
    }

    public override void AddCharacterSystem(PBaseDefenseGame PBDGame)
    {
        PBDGame.AddEnemy(m_BuildParam.NewCharacter as IEnemy);
    }

    public override void AddHub()
    {
        throw new System.NotImplementedException();
    }

    public override void AddOnClickScript()
    {
        throw new System.NotImplementedException();
    }

    public override void AddWeapon()
    {
        IWeaponFactory WeaponFactory = PBDFactory.GetWeaponFactory();
    }

    public override void LoadAsset(int GameObjectID)
    {
        IAssetFactory AssetFactory = PBDFactory.GetAssetFactory();
    }

    public override void SetBuildParam(ICharacterBuildParam theParam)
    {
        throw new System.NotImplementedException();
    }

    public override void SetCharacterAttr()
    {
        IAttrFactory theAttrFactory = PBDFactory.GetAttrFactory();
        int AttrID = m_BuildParam.NewCharacter.GetAttrID();

    }
}
