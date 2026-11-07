using System;
using System.Collections.Generic;
using System.Xml;
using SSJJBase.Extensions;
using UnityEngine;

namespace Assets.Sources.Particle.Config;

public class PlayerInfoParticleLoopEffectData : BaseEffectData, IEquatable<PlayerInfoParticleLoopEffectData>
{
	public int EffectNum;

	public int LoopNum;

	public int LoopTime;

	public string EffectName1;

	public int isWeaponSkin;

	public List<string> WomanEffectList = new List<string>();

	public override BaseEffectData Parse(XmlNode xn)
	{
		Key = xn.Read("playerStatus");
		EffectNum = xn.Read("effectNum", 1);
		LoopNum = xn.Read("loopNum", 1);
		LoopTime = xn.Read("loopTime", 0);
		EffectName = xn.Read("effectName");
		EffectName1 = xn.Read("effectName1");
		isWeaponSkin = xn.Read("isWeaponSkin", 0);
		string[] array = EffectName.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			if (!string.IsNullOrEmpty(array[i]))
			{
				WomanEffectList.Add(array[i]);
			}
		}
		return this;
	}

	public List<int> GetEffectList()
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		int num = -1;
		for (int i = 0; i < LoopNum; i++)
		{
			list2.Clear();
			if (num != -1)
			{
				list2.Add(num);
			}
			for (int j = 0; j < EffectNum; j++)
			{
				int num2 = UnityEngine.Random.Range(0, EffectNum);
				while (true)
				{
					bool flag = false;
					for (int k = 0; k < list2.Count; k++)
					{
						if (list2[k] == num2)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						break;
					}
					num2 = UnityEngine.Random.Range(0, EffectNum);
				}
				list.Add(num2);
				list2.Add(num2);
				if (num != -1 && j == 0)
				{
					list2.Remove(num);
					num = -1;
				}
				if (j == EffectNum - 1)
				{
					num = num2;
				}
			}
		}
		return list;
	}

	public override string GetName()
	{
		return "PlayerInfoParticleLoop" + Key;
	}

	public bool Equals(PlayerInfoParticleLoopEffectData other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (Equals((BaseEffectData)other) && EffectNum == other.EffectNum && LoopNum == other.LoopNum && LoopTime == other.LoopTime && isWeaponSkin == other.isWeaponSkin)
		{
			return string.Equals(EffectName1, other.EffectName1);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((PlayerInfoParticleLoopEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (((((((base.GetHashCode() * 397) ^ EffectNum) * 397) ^ LoopNum) * 397) ^ LoopTime) * 397) ^ ((EffectName1 != null) ? EffectName1.GetHashCode() : 0);
	}
}
