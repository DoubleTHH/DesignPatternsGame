using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterFactory : ICharacterFactory
{
    private CharacterBuilderSystem m_BuilderDirector = new CharacterBuilderSystem(PBaseDefenseGame.Instance);

    public override IEnemy CreateEnemy(ENUM_Enemy emEnemy, ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition)
    {
        EnemyBuildParam EnemyParam = new EnemyBuildParam();
        switch (emEnemy)
        {
            case ENUM_Enemy.Elf:
                EnemyParam.NewCharacter = new EnemyElf();
                break;
            case ENUM_Enemy.Troll:
                EnemyParam.NewCharacter = new EnemyTrol();
                break;
            case ENUM_Enemy.Ogre:
                EnemyParam.NewCharacter = new EnemyOgre();
                break;
            default:
                Debug.LogError("无法生产[" + emEnemy + "]");
                return null;
        }
        EnemyParam.emWeapon = emWeapon;
        EnemyParam.SpawnPosition = SpawnPosition;
        EnemyParam.AttackPosition = AttackPosition;
        EnemyBuilder theEnemyBuilder = new EnemyBuilder();
        theEnemyBuilder.SetBuildParam(EnemyParam);
        m_BuilderDirector.Construct(theEnemyBuilder);
        return EnemyParam.NewCharacter as IEnemy;
    }

    public override ISoldier CreateSoldier(ENUM_Soldier emSoldier, ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition)
    {
        SoldierBuilderParam SoldierParam = new SoldierBuilderParam();
        switch (emSoldier)
        {
            case ENUM_Soldier.Rookie:
                SoldierParam.NewCharacter = new SoldierRookie();
                break;
            case ENUM_Soldier.Sergeant:
                SoldierParam.NewCharacter = new SoldierSergeant();
                break;
            case ENUM_Soldier.Captain:
                SoldierParam.NewCharacter = new SoldierCaptain();
                break;
            default:
                Debug.LogError("无法生产[" + emSoldier + "]");
                return null;
        }

        if (SoldierParam.NewCharacter == null)
            return null;
        SoldierParam.emWeapon = emWeapon;
        SoldierParam.SpawnPosition = SpawnPosition;
        SoldierParam.Lv = Lv;
        SoldierBuilder theSoldierBuilder = new SoldierBuilder();
        theSoldierBuilder.SetBuildParam(SoldierParam);
        m_BuilderDirector.Construct(theSoldierBuilder);
        return SoldierParam.NewCharacter as ISoldier;
    }


    public void AddCharacterFuncs(ICharacter pRole, ENUM_Weapon emWeapon, int Lv)
    {
        AddGameObject(pRole);

        AddWeapon(pRole, emWeapon);

        AddAttr(pRole, Lv);

        AddAI(pRole);
    }


    public abstract void AddGameObject(ICharacter pRole);
    public abstract void AddWeapon(ICharacter pRole, ENUM_Weapon emWeapon);
    public abstract void AddAttr(ICharacter pRole, int Lv);
    public abstract void AddAI(ICharacter pRole);

    protected GameObject CreateGameObject(string name)
    {
        return new GameObject();
    }

    protected IWeapon CreateWeapon(ENUM_Weapon eNUM_Weapon)
    {
        return new WeaponGun();
    }

    protected SoldierAttr CreateSoldierAttr(int num)
    {
        return new SoldierAttr();
    }

    protected EnemyAttr CreateEnemyAttr(int num)
    {
        return new EnemyAttr();
    }

    protected SoldierAI CreateSoldierAI()
    {
        return new SoldierAI(new SoldierRookie());
    }

    protected EnemyAI CreateEnemyAI()
    {
        return new EnemyAI(new EnemyOgre(),Vector3.zero);
    }

}


public class CharacterFactory_Generic : TCharacterFactory_Generic
{
    public IEnemy CreateEnemy<T>(ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition) where T : IEnemy, new()
    {
        IEnemy theEnemy = new T();
        if (theEnemy == null)
            return null;

        GameObject tmpGameObject = CreateGameObject("OgreGameObjectName");


        tmpGameObject.gameObject.name = "Enemy" + typeof(T).ToString();
        theEnemy.SetGameObject(tmpGameObject);


        IWeapon Weapon = CreateWeapon(emWeapon);
        theEnemy.SetWeapon(Weapon);

        EnemyAttr theEnemyAttr = CreateEnemyAttr(theEnemy.GetAttrID());
        theEnemy.SetCharacterAttr(theEnemyAttr);


        EnemyAI theAI = CreateEnemyAI();
        theEnemy.SetAI(theAI);

        PBaseDefenseGame.Instance.AddEnemy(theEnemy);
        return theEnemy;
    }

    public ISoldier CreateSoldier<T>(ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition) where T : ISoldier, new()
    {
        ISoldier theSoldier = new T();
        if (theSoldier == null)
            return null;

        GameObject tmpGameObject = CreateGameObject("CaptainGameObjectName");


        tmpGameObject.gameObject.name = "Soldier" + typeof(T).ToString();
        theSoldier.SetGameObject(tmpGameObject);


        IWeapon Weapon = CreateWeapon(emWeapon);
        theSoldier.SetWeapon(Weapon);

        SoldierAttr theSoldierAttr = CreateSoldierAttr(3);
        theSoldierAttr.SetSoldierLv(Lv);
        theSoldier.SetCharacterAttr(theSoldierAttr);


        SoldierAI theAI = CreateSoldierAI();
        theSoldier.SetAI(theAI);

        PBaseDefenseGame.Instance.AddSoldier(theSoldier);
        return theSoldier;
    }


    protected GameObject CreateGameObject(string name)
    {
        return new GameObject();
    }

    protected IWeapon CreateWeapon(ENUM_Weapon eNUM_Weapon)
    {
        return new WeaponGun();
    }

    protected SoldierAttr CreateSoldierAttr(int num)
    {
        return new SoldierAttr();
    }

    protected EnemyAttr CreateEnemyAttr(int num)
    {
        return new EnemyAttr();
    }

    protected SoldierAI CreateSoldierAI()
    {
        return new SoldierAI(new SoldierRookie());
    }

    protected EnemyAI CreateEnemyAI()
    {
        return new EnemyAI(new EnemyOgre(), Vector3.zero);
    }
}
