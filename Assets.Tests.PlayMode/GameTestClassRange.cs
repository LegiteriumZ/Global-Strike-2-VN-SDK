using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assets.Tests.PlayMode;

public class GameTestClassRange : GameTestProperty
{
	public Dictionary<int, List<string>> PropertyName = new Dictionary<int, List<string>>();

	public Dictionary<int, GameTestProperty> SubPropery = new Dictionary<int, GameTestProperty>();

	private GameTestClassRange()
	{
	}

	public GameTestClassRange(params object[] valobjects)
	{
		if (!valobjects[0].GetType().IsArray)
		{
			Add(valobjects);
			return;
		}
		for (int i = 0; i < valobjects.Length; i++)
		{
			object[] obs = valobjects[i] as object[];
			Add(obs);
		}
	}

	private void Add(object[] obs)
	{
		Type type = null;
		for (int i = 0; i < obs.Length; i++)
		{
			switch (i % 4)
			{
			case 0:
				Indexes.Add((int)obs[i]);
				break;
			case 1:
			{
				int key2 = (int)obs[i - 1];
				string item = (string)obs[i];
				if (PropertyName.ContainsKey(key2))
				{
					PropertyName[key2].Add(item);
					break;
				}
				PropertyName.Add(key2, new List<string> { item });
				break;
			}
			case 2:
				type = (Type)obs[i];
				break;
			case 3:
			{
				List<object> list = new List<object>();
				for (int j = i; j < obs.Length; j++)
				{
					list.Add(obs[j]);
				}
				int key = (int)obs[i - 3];
				if (SubPropery.TryGetValue(key, out var value))
				{
					value.GetType().GetMethod("Add", BindingFlags.Instance | BindingFlags.Public).Invoke(value, list.ToArray());
					return;
				}
				value = (GameTestProperty)Activator.CreateInstance(type, new object[1] { list.ToArray() });
				SubPropery.Add(key, value);
				return;
			}
			}
		}
	}

	public override bool IsMatch(Type type)
	{
		return true;
	}

	public bool TryGet(int index, string key, out int propertyindex)
	{
		propertyindex = -1;
		if (PropertyName.TryGetValue(index, out var value))
		{
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i] == key)
				{
					propertyindex = i;
					break;
				}
			}
		}
		return propertyindex >= 0;
	}

	public object Get(int idx, int subidx, Type type, int step)
	{
		return SubPropery[idx].Get(subidx, type, step);
	}

	public T GetValue<T>(int idx, int subidx, int step)
	{
		return (T)Get(idx, subidx, typeof(T), step);
	}

	public override T GetValue<T>(int idx, int step)
	{
		return default(T);
	}

	public override object Get(int idx, Type type, int step)
	{
		return null;
	}
}
