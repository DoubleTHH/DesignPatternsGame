using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAttrStrategy : MonoBehaviour
{
    public abstract void InitAttr(ICharacterAttr CharacterAttr);

    public abstract int GetAtkPlusValue(ICharacterAttr CharacterAttr);

    public abstract int GetDmgDescValue(ICharacterAttr CharacterAttr);

}
