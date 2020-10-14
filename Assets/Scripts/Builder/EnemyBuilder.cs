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

    public override void SetBuildParam(ICharacterBuildParam theParam)
    {
        m_BuildParam = theParam as EnemyBuildParam;

    }

    public override void LoadAsset(int GameObjectID)
    {
        IAssetFactory AssetFactory = PBDFactory.GetAssetFactory();
        GameObject EnemyGameObject = AssetFactory.LoadEnemy(m_BuildParam.NewCharacter.GetAssetName());
        EnemyGameObject.transform.position = m_BuildParam.SpawnPosition;
        EnemyGameObject.gameObject.name = string.Format("Enemy[{0}]", GameObjectID);
        m_BuildParam.NewCharacter.SetGameObject(EnemyGameObject);
    }

    public override void AddOnClickScript()
    {
        Debug.Log("未定义点击事件");
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
        EnemyAttr theEnemyAttr = theAttrFactory.GetEnemyAttr(AttrID);

        // 設定數值的計算策略
        theEnemyAttr.SetAttStrategy(new EnemyAttrStrategy());

        // 設定給角色
        m_BuildParam.NewCharacter.SetCharacterAttr(theEnemyAttr);
    }


    public override void AddAI()
    {
        EnemyAI theAI = new EnemyAI(m_BuildParam.NewCharacter, m_BuildParam.AttackPosition);
        m_BuildParam.NewCharacter.SetAI(theAI);
    }

    public override void AddCharacterSystem(PBaseDefenseGame PBDGame)
    {
        PBDGame.AddEnemy(m_BuildParam.NewCharacter as IEnemy);
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
