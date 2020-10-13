using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISoldier : ICharacter
{

    public ISoldier() { }

    public override void UnderAttack(ICharacter Attacker)
    {
        m_Attribute.CalDmgValue(Attacker);

        if (m_Attribute.GetNowHP() <= 0)
        {
            DoPlayHitSound();
            DoShowHitEffect();
            Killed();
        }
    }

    public override void UpdateAI(List<ICharacter> Targets)
    {
        switch (m_AiState)
        {
            case ENUM_AI_State.Idle:
                ICharacter theNearTarget = GetNearTarget(Targets);
                if (theNearTarget == null)
                    return;

                if (TargetInAttackRange(theNearTarget))
                {
                    m_AttackTarget = theNearTarget;
                    m_AiState = ENUM_AI_State.Attack;
                }
                else
                {
                    m_ChaseTarget = theNearTarget;
                    m_AiState = ENUM_AI_State.Chase;
                }
                break;
            case ENUM_AI_State.Chase:
                if (m_ChaseTarget == null || m_ChaseTarget.IsKilled())
                {
                    m_AiState = ENUM_AI_State.Idle;
                    return;
                }

                if (TargetInAttackRange(m_ChaseTarget))
                {
                    StopMove();
                    m_AiState = ENUM_AI_State.Attack;
                    return;
                }

                if (m_bOnChase)
                {
                    float dist = GetTargetDist(m_ChaseTarget);
                    if (dist < CHASE_CHECK_DIST)
                        m_AiState = ENUM_AI_State.Idle;
                    return;
                }


                m_bOnChase = true;
                MoveTo(m_ChaseTarget.GetPosition());
                break;
            case ENUM_AI_State.Attack:
                if (m_AttackTarget == null || m_AttackTarget.IsKilled() || Targets == null || Targets.Count == 0)
                {
                    m_AiState = ENUM_AI_State.Idle;
                    return;
                }

                if (!TargetInAttackRange(m_AttackTarget))
                {
                    m_ChaseTarget = m_AttackTarget;
                    m_AiState = ENUM_AI_State.Chase;
                    return;
                }

                Attack(m_AttackTarget);
                break;
            case ENUM_AI_State.Move:
                break;
            default:
                break;
        }
    }

    void Killed()
    {

    }

    ICharacter GetNearTarget(List<ICharacter> Targets)
    {
        return null;
    }

    bool TargetInAttackRange(ICharacter theCharacter)
    {
        return false;
    }


    void MoveTo(Vector3 pos)
    {

    }

    void StopMove()
    {

    }

    float GetTargetDist(ICharacter theCharacter)
    {
        return 0.0f;
    }

    public ENUM_Soldier GetSoldierType()
    {
        return ENUM_Soldier.Null;
    }

    public abstract void DoPlayHitSound();
    public abstract void DoShowHitEffect();
}
