using System;
using System.Collections.Generic;
using SSJJBase.Pool;
using UnityEngine;

namespace CommonUtils;

[Serializable]
public abstract class BaseFrDictionary<TK, TV>
{
	[SerializeField]
	protected List<TK> _keys;

	[SerializeField]
	protected List<TV> _values;

	public TV this[TK key]
	{
		get
		{
			TryGetValue(key, out var v);
			return v;
		}
		set
		{
			try
			{
				int num = _keys.IndexOf(key);
				if (num == -1)
				{
					_values.Add(value);
					_keys.Add(key);
				}
				else
				{
					_values[num] = value;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}

	public TK this[TV key]
	{
		get
		{
			TryGetKey(key, out var v);
			return v;
		}
		set
		{
			try
			{
				int num = _values.IndexOf(key);
				if (num == -1)
				{
					_values.Add(key);
					_keys.Add(value);
				}
				else
				{
					_keys[num] = value;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}

	public int Count => _keys.Count;

	public List<TK> ReadOnlyKeys => _keys;

	public List<TV> ReadOnlyValues => _values;

	public List<TK> Keys
	{
		get
		{
			List<TK> list = ListPool<TK>.Get();
			list.AddRange(_keys);
			return list;
		}
	}

	public List<TV> Values
	{
		get
		{
			List<TV> list = ListPool<TV>.Get();
			list.AddRange(_values);
			return list;
		}
	}

	public void Clear()
	{
		_values.Clear();
		_keys.Clear();
	}

	public List<TV> FindAll(Predicate<TK> p)
	{
		List<TV> list = ListPool<TV>.Get();
		List<TK> list2 = _keys.FindAll(p);
		for (int i = 0; i < list2.Count; i++)
		{
			list.Add(this[list2[i]]);
		}
		return list;
	}

	public bool RemoveAll(Predicate<TK> p)
	{
		List<TK> list = _keys.FindAll(p);
		if (list.Count == 0)
		{
			return false;
		}
		for (int i = 0; i < list.Count; i++)
		{
			TK val = list[i];
			_values.Remove(this[val]);
			list.Remove(val);
		}
		return true;
	}

	public bool TryGetValue(TK key, out TV v)
	{
		try
		{
			int num = _keys.IndexOf(key);
			if (num == -1)
			{
				v = default(TV);
				return false;
			}
			v = _values[num];
			return true;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			v = default(TV);
			return false;
		}
	}

	public bool TryGetKey(TV key, out TK v)
	{
		try
		{
			int num = _values.IndexOf(key);
			if (num == -1)
			{
				v = default(TK);
				return false;
			}
			v = _keys[num];
			return true;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			v = default(TK);
			return false;
		}
	}

	public void Add(TK key, TV value)
	{
		this[key] = value;
	}

	public bool Remove(TK key)
	{
		int num = _keys.IndexOf(key);
		if (num != -1)
		{
			_keys.RemoveAt(num);
			_values.RemoveAt(num);
			return true;
		}
		return false;
	}

	public bool RemoveValue(TV value)
	{
		int num = _values.IndexOf(value);
		if (num != -1)
		{
			_keys.RemoveAt(num);
			_values.RemoveAt(num);
			return true;
		}
		return false;
	}
}
