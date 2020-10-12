using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ENUM_Weapon
{
    Null,
    Gun,
    Rocket,
    Rifle,
    Max,
}
public abstract class IWeapon
{
    protected int m_AtkPlusValue = 0; //额外攻击力
    protected int m_Atk = 0; //攻击力
    protected float m_Range = 0.0f;

    protected GameObject m_GameObject = null; //显示的模型
    protected ICharacter m_WeaponOwner = null; //武器拥有者

    protected WeaponAttr m_WeaponAttr = null;

    protected float m_EffectDisplayTime = 0;
    protected ParticleSystem m_Particles;
    protected LineRenderer m_Line;
    protected AudioSource m_Audio;
    protected Light m_Light;


    public void SetWeaponAttr(WeaponAttr theWeaponAttr)
    {
        m_WeaponAttr = theWeaponAttr;
    }

    public void SetAtkPlusValue(int Value)
    {
        m_AtkPlusValue = Value;
    }

    public int GetAtkValue()
    {
        return m_WeaponAttr.GetAtkValue() + m_AtkPlusValue;
    }


    public float GetAtkRange()
    {
        return m_WeaponAttr.GetAtkRange();
    }

    protected void ShowBulletEffect(Vector3 TargetPosition, float LineWidth, float DisplayTime)
    {
        if (m_Line == null)
            return;
        m_Line.enabled = true;
        m_Line.startWidth = LineWidth;
        m_Line.endWidth = LineWidth;
        m_Line.SetPosition(0, m_GameObject.transform.position);
        m_Line.SetPosition(1, TargetPosition);
        m_EffectDisplayTime = DisplayTime;
    }


    protected void ShowShootEffect()
    {
        if (m_Particles != null)
        {
            m_Particles.Stop();
            m_Particles.Play();
        }

        if (m_Light !=null)
        {
            m_Line.enabled = true;
        }
    }

    protected void ShowSoundEffect(string ClipName)
    {
        if (m_Audio == null)
            return;

        
        //m_Audio.clip = 
    }

    //public abstract void Fire(ICharacter theTarget);
    public void Fire(ICharacter theTarget)
    {
        ShowShootEffect();
        DoShowBulletEffect(theTarget);
        DoShowSoundEffect();
    }

    protected abstract void DoShowBulletEffect(ICharacter theTarget);

    protected abstract void DoShowSoundEffect();

}
