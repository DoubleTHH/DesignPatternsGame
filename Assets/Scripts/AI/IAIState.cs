using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAIState 
{
    protected ICharacterAI m_CharacterAI;

    public IAIState() { }

    public void SetCharacterAI(ICharacterAI CharacterAI)
    {
        m_CharacterAI = CharacterAI;
    }

    public virtual void SetAttackPosition(Vector3 AttackPosition) { }

    public abstract void Update(List<ICharacter> Targets);

    public virtual void RemoveTarget(ICharacter Targets) { }

}
