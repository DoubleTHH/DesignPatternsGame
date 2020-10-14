using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 字尾
public class SuffixBaseAttr : BaseAttrDecorator
{
	public SuffixBaseAttr()
	{ }

	public override int GetMaxHP()
	{
		return m_Component.GetMaxHP() + m_AdditionialAttr.GetStrength();
	}

	public override float GetMoveSpeed()
	{
		return m_Component.GetMoveSpeed() + m_AdditionialAttr.GetAgility() * 0.2f;
	}

	public override string GetAttrName()
	{
		return m_Component.GetAttrName() + m_AdditionialAttr.GetName();
	}
}
