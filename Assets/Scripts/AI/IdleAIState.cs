using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAIState : IAIState
{
    bool m_bSetAttackPosition = false;

    public IdleAIState() { }

    public override void SetAttackPosition(Vector3 AttackPosition)
    {
        m_bSetAttackPosition = true;
    }
    public override void Update(List<ICharacter> Targets)
    {
        if (Targets == null || Targets.Count == 0)
        {
            if (m_bSetAttackPosition)
                m_CharacterAI.ChangeAIState(new MoveAIState());
            else
                m_CharacterAI.ChangeAIState(new GuardAIState());

            return;
        }
    }
}
