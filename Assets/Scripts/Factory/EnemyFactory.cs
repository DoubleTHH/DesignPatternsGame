using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : CharacterFactory
{
    public override ISoldier CreateSoldier(ENUM_Soldier emSoldier, ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition)
    {
        Debug.LogWarning("EnemyFactory 不应该产生ISoldier对象");
        return null;
    }
    public override void AddAI(ICharacter pRole)
    {
        EnemyAI theAI = CreateEnemyAI();
        pRole.SetAI(theAI);
    }

    public override void AddAttr(ICharacter pRole, int Lv)
    {
        EnemyAttr theEnemyAttr = CreateEnemyAttr(pRole.GetAttrID());
        pRole.SetCharacterAttr(theEnemyAttr);
    }

    public override void AddGameObject(ICharacter pRole)
    {
        GameObject tmpGameObject = CreateGameObject("CaptainGameObjectName");
        tmpGameObject.gameObject.name = "Soldier" + pRole.ToString();
        pRole.SetGameObject(tmpGameObject);
    }

    public override void AddWeapon(ICharacter pRole, ENUM_Weapon emWeapon)
    {
        IWeapon Weapon = CreateWeapon(emWeapon);
        pRole.SetWeapon(Weapon);
    }
}
