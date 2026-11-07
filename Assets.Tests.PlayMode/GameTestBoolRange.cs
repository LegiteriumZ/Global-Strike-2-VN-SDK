using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Tests.PlayMode;

public class GameTestBoolRange : GameTestProperty
{
	public Dictionary<int, bool> Current = new Dictionary<int, bool>();

	public Dictionary<int, bool> Next = new Dictionary<int, bool>();

	private GameTestBoolRange()
	{
	}

	public GameTestBoolRange(params object[] obs)
	{
		for (int i = 0; i < obs.Length; i++)
		{
			switch (i % 3)
			{
			case 0:
				Indexes.Add((int)obs[i]);
				break;
			case 1:
				Current.Add((int)obs[i - 1], bool.Parse(obs[i].ToString()));
				break;
			case 2:
				Next.Add((int)obs[i - 2], bool.Parse(obs[i].ToString()));
				break;
			}
		}
	}

	public void Add(int idx, bool c, bool n)
	{
		Indexes.Add(idx);
		Current.Add(idx, c);
		Next.Add(idx, n);
	}

	public override bool IsMatch(Type type)
	{
		return type == typeof(bool);
	}

	public override T GetValue<T>(int idx, int step)
	{
		return (T)Get(idx, typeof(T), step);
	}

	public override object Get(int idx, Type type, int step)
	{
		step = Mathf.Clamp(step, 0, 3000);
		return Convert.ChangeType((step % 2 == 0) ? Current[idx] : Next[idx], type);
	}
}
