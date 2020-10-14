using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 字首
public class PrefixBaseAttr : BaseAttrDecorator
{
	public PrefixBaseAttr()
	{ }

	public override int GetMaxHP()
	{
		return m_AdditionialAttr.GetStrength() + m_Component.GetMaxHP();
	}

	public override float GetMoveSpeed()
	{
		return m_AdditionialAttr.GetAgility() * 0.2f + m_Component.GetMoveSpeed();
	}

	public override string GetAttrName()
	{
		return m_AdditionialAttr.GetName() + m_Component.GetAttrName();
	}
}
