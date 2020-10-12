using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PBDFactory
{
    private static bool m_bLoadFromResource = true;
    private static ICharacterFactory m_CharacterFactory = null;
    private static IAssetFactory m_AssetFactory = null;
    private static IWeaponFactory m_WeaponFactory = null;
    private static IAttrFactory m_AttrFactory = null;

    private static TCharacterFactory_Generic m_TCharacterFactory = null;

    public static IAssetFactory GetAssetFactory()
    {
        if (m_AssetFactory == null)
        {
            if (m_bLoadFromResource)
                m_AssetFactory = new ResourceAssetFactory();
            else
                m_AssetFactory = new RemoteAssetFactory();
        }
        return m_AssetFactory;
    }


    public static TCharacterFactory_Generic GetTCharacterFactory()
    {
        if (m_TCharacterFactory == null)
            m_TCharacterFactory = new CharacterFactory_Generic();
        return m_TCharacterFactory;
    }

    public static ICharacterFactory GetCharacterFactory()
    {
        return m_CharacterFactory;
    }


    public static IWeaponFactory GetWeaponFactory()
    {
        if (m_WeaponFactory == null)
            m_WeaponFactory = new IWeaponFactory();
        return m_WeaponFactory;
    }

    public static IAttrFactory GetAttrFactory()
    {
        if (m_AttrFactory == null)
            m_AttrFactory = new AttrFactory();
        return m_AttrFactory;
    }
}
