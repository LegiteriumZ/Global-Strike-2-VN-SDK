using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Tests.PlayMode;

public class GameTestStringRange : GameTestProperty
{
	public Dictionary<int, string> FormatString = new Dictionary<int, string>();

	public Dictionary<int, int> Min = new Dictionary<int, int>();

	public Dictionary<int, int> Max = new Dictionary<int, int>();

	private GameTestStringRange()
	{
	}

	public GameTestStringRange(params object[] obs)
	{
		for (int i = 0; i < obs.Length; i++)
		{
			switch (i % 4)
			{
			case 0:
				Indexes.Add((int)obs[i]);
				break;
			case 1:
				FormatString.Add((int)obs[i - 1], (string)obs[i]);
				break;
			case 2:
				Min.Add((int)obs[i - 2], (int)obs[i]);
				break;
			case 3:
				Max.Add((int)obs[i - 3], (int)obs[i]);
				break;
			}
		}
	}

	public void Add(int idx, string format, int min, int max)
	{
		Indexes.Add(idx);
		FormatString.Add(idx, format);
		Min.Add(idx, min);
		Max.Add(idx, max);
	}

	public override bool IsMatch(Type type)
	{
		return type == typeof(string);
	}

	public override T GetValue<T>(int idx, int step)
	{
		return (T)Get(idx, typeof(T), step);
	}

	public override object Get(int idx, Type type, int step)
	{
		step = Mathf.Clamp(step, 0, 3000);
		int num = (int)Mathf.Lerp(Min[idx], Max[idx], (float)step / 3000f);
		return Convert.ChangeType(string.Format(FormatString[idx], num), type);
	}
}
