using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ENUM_Soldier
{
    Null,
    Rookie,
    Sergeant,
    Captain
}

public enum ENUM_Enemy
{
    Null,
    Elf,
    Troll,
    Ogre
}
public abstract class ICharacterFactory 
{
    public abstract ISoldier CreateSoldier(ENUM_Soldier emSoldier, ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition);

    public abstract IEnemy CreateEnemy(ENUM_Enemy emEnemy, ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition);


}
