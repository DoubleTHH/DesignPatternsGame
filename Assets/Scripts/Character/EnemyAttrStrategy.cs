using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttrStrategy : IAttrStrategy
{
    public override int GetAtkPlusValue(ICharacterAttr CharacterAttr)
    {
        EnemyAttr theEnemyAttr = CharacterAttr as EnemyAttr;
        if (theEnemyAttr == null)
            return 0;

        int RandValue = UnityEngine.Random.Range(0, 100);
        if (theEnemyAttr.GetCritRate() > RandValue)
        {
            theEnemyAttr.CutdownCritRate();
            return theEnemyAttr.GetMaxHP() * 5;
        }
        return 0;
    }

    public override int GetDmgDescValue(ICharacterAttr CharacterAttr)
    {
        return 0;
    }

    public override void InitAttr(ICharacterAttr CharacterAttr)
    {
        
    }
}
