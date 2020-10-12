using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRookie : ISoldier
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameObject(GameObject go)
    {

    }

    public void SetWeapon(IWeapon weapon)
    {

    }

    public void SetCharacterAttr(SoldierAttr soldierAttr)
    {

    }

    public void SetAI(SoldierAI soldierAI)
    {

    }

    public override void DoPlayHitSound()
    {
        throw new System.NotImplementedException();
    }

    public override void DoShowHitEffect()
    {
        throw new System.NotImplementedException();
    }
}
