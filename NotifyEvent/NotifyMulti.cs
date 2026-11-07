using System;
using System.Collections.Generic;

namespace NotifyEvent;

internal class NotifyMulti : IMultiNotify, IValueNotify, INotify
{
	private readonly List<IValueNotify> _properties;

	public bool Suspend { get; set; }

	public int Id { get; set; }

	public NotifyMulti()
	{
		_properties = new List<IValueNotify>();
	}

	public void Add(object element)
	{
		if (element is IValueNotify)
		{
			_properties.Add((IValueNotify)element);
		}
	}

	public void Remove(object element)
	{
		if (element is IValueNotify)
		{
			_properties.Remove((IValueNotify)element);
		}
	}

	public void ForceInvoke(int subEvnetId = -1)
	{
		for (int i = 0; i < _properties.Count; i++)
		{
			_properties[i].ForceInvoke();
		}
	}

	public bool TryNotify(int frame)
	{
		bool result = false;
		for (int i = 0; i < _properties.Count; i++)
		{
			if (_properties[i].TryNotify(frame))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public void AddEvent<T>(Func<T> getfunc, Action<T, T> setfunc)
	{
	}

	public void RemoveEvent<T>(Func<T> getfunc, Action<T, T> setfunc)
	{
		for (int i = 0; i < _properties.Count; i++)
		{
			if (_properties[i].ContainsEvent(getfunc) && _properties[i].ContainsEvent(setfunc))
			{
				_properties.RemoveAt(i);
				break;
			}
		}
	}

	public bool ContainsEvent<T>(Func<T> getfunc)
	{
		for (int i = 0; i < _properties.Count; i++)
		{
			if (_properties[i].ContainsEvent(getfunc))
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsEvent<T>(Action<T, T> setfunc)
	{
		for (int i = 0; i < _properties.Count; i++)
		{
			if (_properties[i].ContainsEvent(setfunc))
			{
				return true;
			}
		}
		return false;
	}

	public void Release()
	{
		NotifyManager.PushToPool(this);
	}
}
