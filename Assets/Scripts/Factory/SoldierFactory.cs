using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFactory : CharacterFactory
{

    public override IEnemy CreateEnemy(ENUM_Enemy emEnemy, ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition)
    {
        Debug.LogWarning("SoldierFactory 不应该产生IEnemy对象");
        return null;
    }
    public override void AddAI(ICharacter pRole)
    {
        SoldierAI theAI = CreateSoldierAI();
        pRole.SetAI(theAI);
    }

    public override void AddAttr(ICharacter pRole, int Lv)
    {
        SoldierAttr theSoldierAttr = CreateSoldierAttr(pRole.GetAttrID());
        theSoldierAttr.SetSoldierLv(Lv);
        pRole.SetCharacterAttr(theSoldierAttr);
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
