using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Tests.PlayMode;

public class GameTestFloatRange : GameTestProperty
{
	public Dictionary<int, float> Max = new Dictionary<int, float>();

	public Dictionary<int, float> Min = new Dictionary<int, float>();

	private GameTestFloatRange()
	{
	}

	public GameTestFloatRange(params object[] obs)
	{
		for (int i = 0; i < obs.Length; i++)
		{
			switch (i % 3)
			{
			case 0:
				Indexes.Add((int)obs[i]);
				break;
			case 1:
				Min.Add((int)obs[i - 1], float.Parse(obs[i].ToString()));
				break;
			case 2:
				Max.Add((int)obs[i - 2], float.Parse(obs[i].ToString()));
				break;
			}
		}
	}

	public void Add(int idx, float min, float max)
	{
		Indexes.Add(idx);
		Min.Add(idx, min);
		Max.Add(idx, max);
	}

	public override bool IsMatch(Type type)
	{
		if (!(type == typeof(float)) && !(type == typeof(double)) && !(type == typeof(int)) && !(type == typeof(short)))
		{
			return type == typeof(long);
		}
		return true;
	}

	public override T GetValue<T>(int idx, int step)
	{
		return (T)Get(idx, typeof(T), step);
	}

	public override object Get(int idx, Type type, int step)
	{
		return Convert.ChangeType(Mathf.Lerp(Min[idx], Max[idx], (float)step / 3000f), type);
	}
}
