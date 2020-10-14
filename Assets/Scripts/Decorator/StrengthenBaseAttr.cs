using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 直接強化
public class StrengthenBaseAttr : BaseAttrDecorator
{
	protected List<AdditionalAttr> m_AdditionialAttrs;  // 多個強化的數值

	public StrengthenBaseAttr()
	{ }

	public override int GetMaxHP()
	{
		int MaxHP = m_Component.GetMaxHP();
		foreach (AdditionalAttr theAttr in m_AdditionialAttrs)
			MaxHP += theAttr.GetStrength();
		return MaxHP;
	}

	public override float GetMoveSpeed()
	{
		float MoveSpeed = m_Component.GetMoveSpeed();
		foreach (AdditionalAttr theAttr in m_AdditionialAttrs)
			MoveSpeed += theAttr.GetAgility() * 0.2f;
		return MoveSpeed;
	}

	public override string GetAttrName()
	{
		return "直接強化" + m_Component.GetAttrName();
	}
}
