using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAIState : IAIState
{
    bool m_bOnMove = false;
    Vector3 m_Position = Vector3.zero;
    const int GUARD_DISTANCE = 3;

    public GuardAIState() { }


    public override void Update(List<ICharacter> Targets)
    {
        if (Targets !=null && Targets.Count > 0)
        {
            m_CharacterAI.ChangeAIState(new IdleAIState());
            return;
        }

        if (m_Position == Vector3.zero)
        {
            GetMovePosition();
        }

        if (m_bOnMove)
        {
            float dist = Vector3.Distance(m_Position, m_CharacterAI.GetPosition());

            if (dist > 0.5f)
            {
                return;
            }

            GetMovePosition();
        }

    }


    private void GetMovePosition()
    {
        m_bOnMove = false;

        Vector3 RandPos = new Vector3(Random.Range(-GUARD_DISTANCE, GUARD_DISTANCE), Random.Range(-GUARD_DISTANCE, GUARD_DISTANCE));


        m_Position = m_CharacterAI.GetPosition() + RandPos;
    }
}
