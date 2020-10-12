using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : ICharacterAI
{
    private static StageSystem m_StageSystem = null;

    private Vector3 m_AttackPosition = Vector3.zero;

    public static void SetStageSystem(StageSystem StageSystem)
    {
        m_StageSystem = StageSystem;
    }

    public EnemyAI(ICharacter Character, Vector3 AttackPosition): base(Character)
    {
        m_AttackPosition = AttackPosition;

        ChangeAIState(new IdleAIState());
    }


    public override void ChangeAIState(IAIState NewAIState)
    {
        ChangeAIState(NewAIState);
        NewAIState.SetAttackPosition(m_AttackPosition);
    }

    public override bool CanAttackHeart()
    {
        //m_StageSystem.LoseHeart();
        return true;
    }

}
