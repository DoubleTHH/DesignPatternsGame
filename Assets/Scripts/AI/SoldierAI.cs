using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAI : ICharacterAI
{
    public SoldierAI(ICharacter Character) : base (Character)
    {
        ChangeAIState(new IdleAIState());
    }
    public override bool CanAttackHeart()
    {
        return false;
    }
}
