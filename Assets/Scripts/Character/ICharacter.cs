using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public enum ENUM_AI_State 
{ 
    Idle = 0,
    Chase,
    Attack,
    Move,
}

public abstract class ICharacter
{
    protected ICharacterAI m_AI = null;

    protected ENUM_AI_State m_AiState = ENUM_AI_State.Idle;

    protected const float MOVE_CHECK_DIST = 1.5f;
    protected bool m_bOnMove = false;

    protected bool m_bSetAttackPosition = false;
    protected Vector3 m_AttackPosition;

    protected bool m_bOnChase = false;
    protected ICharacter m_ChaseTarget = null;
    protected const float CHASE_CHECK_DIST = 2.0f;

    protected ICharacter m_AttackTarget = null;


    private IWeapon m_Weapon = null;
    protected ICharacterAttr m_Attribute = null;

    protected string m_Name = ""; // 名称
    protected GameObject m_GameObject = null; //显示模型
    protected NavMeshAgent m_NavAgent = null; //控制角色移动
    protected AudioSource m_Audio = null; 
    protected string m_IconSpriteName = ""; //显示Icon

    protected bool m_bKilled = false; //是否阵亡
    protected bool m_bCheckKilled = false; //是否确认过阵亡事件
    protected float m_RemoveTimer = 1.5f; //阵亡后多久移除
    protected bool m_bCanRemove = false; //是否可以删除

    public ICharacter() { }

    public abstract void UpdateAI(List<ICharacter> Targets);


    public virtual void SetCharacterAttr(ICharacterAttr CharacterAttr)
    {
        m_Attribute = CharacterAttr;
        m_Attribute.InitAttr();

        m_NavAgent.speed = m_Attribute.GetMoveSpeed();

        m_Name = m_Attribute.GetAttrName();
    }

    public void Attack(ICharacter Target)
    {


        WeaponAttackTarget(Target);
    }

    public void SetGameObject(GameObject theGameObject)
    {
        m_GameObject = theGameObject;
        m_NavAgent = m_GameObject.GetComponent<NavMeshAgent>();
        m_Audio = m_GameObject.GetComponent<AudioSource>();
    }

    public GameObject GetGameObject()
    {
        return m_GameObject;
    }



    public void Release()
    {
        if (m_GameObject != null)
            GameObject.Destroy(m_GameObject);
    }

    public string GetName()
    {
        return m_Name;
    }

    public void SetIconSpriteName(string SpriteName)
    {
        m_IconSpriteName = SpriteName;
    }

    public string GetIconSpriteName()
    {
        return m_IconSpriteName;
    }


    public Vector3 GetPosition()
    {
        return Vector3.zero;
    }

    protected void WeaponAttackTarget(ICharacter Target)
    {
        m_Weapon.Fire(Target);
    }


    public float GetAttackRange()
    {
        return 0.0f;
    }

    public int GetAttrID()
    {
        return 1;
    }

    public void MoveTo(Vector3 pos)
    {

    }


    public void StopMove()
    {

    }

    public void Killed()
    {

    }


    public bool IsKilled()
    {
        return false;
    }

    public void SetAI(ICharacterAI CharacterAI)
    {
        m_AI = CharacterAI;
    }

    //public void UpdateAI(List<ICharacter> Targets)
    //{

    //}

    public bool CheckKilledEvent()
    {
        return false;
    }

    public bool CanRemove()
    {
        return false;
    }


    public void RemoveAITarget(ICharacter character)
    {

    }

    public void Update()
    {

    }

    public int GetAtkValue()
    {
        return 0;
    }


    public void SetWeapon(IWeapon weapon)
    {
        m_Weapon = weapon;
    }

    //public abstract void Attack(ICharacter Target);

    public abstract void UnderAttack(ICharacter Attacker);
}
