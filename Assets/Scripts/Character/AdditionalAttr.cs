using UnityEngine;
using System.Collections.Generic;

// 用於加乘用的數值
public class AdditionalAttr
{
	private int m_Strength; // 力量
	private int m_Agility;  // 敏捷
	private string m_Name;      // 數值的名稱	

	public AdditionalAttr(int Strength, int Agility, string Name)
	{
		m_Strength = Strength;
		m_Agility = Agility;
		m_Name = Name;
	}

	public int GetStrength()
	{
		return m_Strength;
	}

	public int GetAgility()
	{
		return m_Agility;
	}

	public string GetName()
	{
		return m_Name;
	}
}