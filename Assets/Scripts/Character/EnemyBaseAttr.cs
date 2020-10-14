using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敵方角色的基本數值
public class EnemyBaseAttr : CharacterBaseAttr
{
	public int m_InitCritRate;  // 爆擊率
	public EnemyBaseAttr(int MaxHP, float MoveSpeed, string AttrName, int CritRate) : base(MaxHP, MoveSpeed, AttrName)
	{
		m_InitCritRate = CritRate;
	}

	public virtual int GetInitCritRate()
	{
		return m_InitCritRate;
	}
}
