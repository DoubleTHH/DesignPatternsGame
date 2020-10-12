using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuilderSystem : IGameSystem
{
    private int m_GameObjectID = 0;
    private bool m_bEnableHUD;
    public CharacterBuilderSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
    }

    public void Construct(ICharacterBuilder theBuilder)
    {
        theBuilder.LoadAsset(++m_GameObjectID);
        theBuilder.AddOnClickScript();
        theBuilder.AddWeapon();
        theBuilder.SetCharacterAttr();
        theBuilder.AddAI();

        if (m_bEnableHUD)
            theBuilder.AddHub();

        theBuilder.AddBornEffect();

        theBuilder.AddCharacterSystem(m_PBDGame);
    }

}
