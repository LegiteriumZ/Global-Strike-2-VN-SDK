using System;
using System.Collections.Generic;

namespace CommonUtils;

[Serializable]
public class FrDictionary<TK, TV> : BaseFrDictionary<TK, TV> where TK : IEquatable<TK>
{
	public FrDictionary()
		: this(0)
	{
	}

	public FrDictionary(int cap)
	{
		_keys = new List<TK>(cap);
		_values = new List<TV>(cap);
	}

	public FrDictionary(int cap, bool enable)
	{
		_keys = new List<TK>(cap);
		_values = new List<TV>(cap);
	}

	public bool ContainsKey(TK k)
	{
		for (int i = 0; i < _keys.Count; i++)
		{
			if (_keys[i].Equals(k))
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsValue(TV v)
	{
		for (int i = 0; i < _values.Count; i++)
		{
			if (_values[i].Equals(v))
			{
				return true;
			}
		}
		return false;
	}
}
