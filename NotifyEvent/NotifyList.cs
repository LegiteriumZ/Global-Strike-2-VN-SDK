using System;
using System.Collections.Generic;
using CommonUtils;

namespace NotifyEvent;

internal class NotifyList<T> : IListNotify, INotify where T : class
{
	private int _size;

	private Action<int, int> _cntevent;

	private Func<List<T>> _getlistfunc;

	private List<NotifyListElement> _elements;

	private NotifyListElement _default;

	private Dictionary<int, Dictionary<string, INotifyPropertyElement>> _bindDictionary;

	public int Id { get; set; }

	public bool Suspend { get; set; }

	public void Bind(Func<List<T>> getfunc)
	{
		_getlistfunc = getfunc;
		_elements = new List<NotifyListElement>();
		List<T> list = _getlistfunc();
		for (int i = 0; i < list.Count; i++)
		{
			_elements.Add(new NotifyListElement());
		}
		_size = list.Count;
	}

	public void AddEvent<T1, TF>(string propertyname, ListGetDelegate<T1, TF> getfunc, ListSetDelegate<T1, TF> setfunc, int bindIndex = -1, int subEventId = -1)
	{
		if (!(getfunc is ListGetDelegate<T, TF>) || !(setfunc is ListSetDelegate<T, TF>))
		{
			return;
		}
		ListGetDelegate<T, TF> callback = getfunc as ListGetDelegate<T, TF>;
		ListSetDelegate<T, TF> setfunc2 = setfunc as ListSetDelegate<T, TF>;
		NotifyProperyElement<T, TF> notifyProperyElement = new NotifyProperyElement<T, TF>(propertyname, null, bindIndex, -1, callback, subEventId);
		notifyProperyElement.AddEvent(setfunc2);
		if (_default == null)
		{
			_default = new NotifyListElement();
		}
		_default.Add(notifyProperyElement);
		if (bindIndex >= 0)
		{
			if (_bindDictionary == null)
			{
				_bindDictionary = new Dictionary<int, Dictionary<string, INotifyPropertyElement>>();
			}
			if (_bindDictionary.TryGetValue(bindIndex, out var value))
			{
				value[propertyname] = notifyProperyElement.CloneNew<T>(null, bindIndex, bindIndex);
			}
			else
			{
				value = new Dictionary<string, INotifyPropertyElement>();
				value[propertyname] = notifyProperyElement.CloneNew<T>(null, bindIndex, bindIndex);
				_bindDictionary[bindIndex] = value;
			}
		}
		for (int i = 0; i < _elements.Count; i++)
		{
			_default.CloneTo<T>(_elements[i], null, i, bindIndex);
		}
	}

	public void RemoveEvent(string propertyname)
	{
		for (int i = 0; i < _elements.Count; i++)
		{
			_elements[i].Remove(propertyname);
		}
	}

	private void Update()
	{
		if (_getlistfunc != null && _getlistfunc() != null)
		{
			_ = _elements;
		}
	}

	public bool TryNotify(int frame)
	{
		if (_getlistfunc == null)
		{
			return false;
		}
		List<T> list = _getlistfunc();
		if (list == null || _elements == null)
		{
			return false;
		}
		bool result = _size != list.Count;
		for (int i = 0; i < list.Count; i++)
		{
			T target = list[i];
			if (i < _elements.Count)
			{
				if (_elements[i].TryNotify(target, i, ElementStatus.InList))
				{
					result = true;
				}
				continue;
			}
			NotifyListElement notifyListElement = new NotifyListElement();
			int count = _elements.Count;
			Dictionary<string, INotifyPropertyElement> value = null;
			bool flag = _bindDictionary != null && _bindDictionary.TryGetValue(i, out value);
			if (_default != null)
			{
				_default.CloneTo<T>(notifyListElement, null, i, flag ? i : (-1));
			}
			else if (count > 0)
			{
				_elements[0].CloneTo<T>(notifyListElement, null, i);
			}
			else
			{
				DebugLogger.LogWarning("has a no-event element");
			}
			if (flag)
			{
				foreach (KeyValuePair<string, INotifyPropertyElement> item in value)
				{
					notifyListElement.Add(item.Value);
				}
			}
			_elements.Add(notifyListElement);
			if (notifyListElement.TryNotify(target, i, ElementStatus.NewInList))
			{
				result = true;
			}
		}
		for (int num = _elements.Count - 1; num >= list.Count; num--)
		{
			NotifyListElement notifyListElement2 = _elements[num];
			notifyListElement2.TryNotify<T>(null, num, ElementStatus.RemoveFromList);
			_elements.RemoveAt(num);
		}
		if (_size != list.Count && _cntevent != null)
		{
			_cntevent(_size, list.Count);
		}
		_size = list.Count;
		return result;
	}

	public void ForceInvoke(int subEvnetId = -1)
	{
		if (_getlistfunc == null)
		{
			return;
		}
		List<T> list = _getlistfunc();
		if (list == null || _elements == null)
		{
			return;
		}
		_ = _size;
		_ = list.Count;
		for (int i = 0; i < list.Count; i++)
		{
			T target = list[i];
			if (i < _elements.Count)
			{
				NotifyListElement notifyListElement = _elements[i];
				if (notifyListElement != null)
				{
					if (subEvnetId == -1)
					{
						notifyListElement.ForceInvoke(target, i);
					}
					else
					{
						notifyListElement.ForceInvokeByEventId(target, i, subEvnetId);
					}
				}
				continue;
			}
			NotifyListElement notifyListElement2 = new NotifyListElement();
			int count = _elements.Count;
			Dictionary<string, INotifyPropertyElement> value = null;
			bool flag = _bindDictionary != null && _bindDictionary.TryGetValue(i, out value);
			if (_default != null)
			{
				_default.CloneTo<T>(notifyListElement2, null, i, flag ? i : (-1));
			}
			else if (count > 0)
			{
				_elements[0].CloneTo<T>(notifyListElement2, null, i);
			}
			else
			{
				DebugLogger.LogWarning("has a no-event element");
			}
			if (flag)
			{
				foreach (KeyValuePair<string, INotifyPropertyElement> item in value)
				{
					notifyListElement2.Add(item.Value);
				}
			}
			_elements.Add(notifyListElement2);
			notifyListElement2.TryNotify(target, i, ElementStatus.NewInList);
		}
		for (int num = _elements.Count - 1; num >= list.Count; num--)
		{
			_elements[num].TryNotify<T>(null, num, ElementStatus.RemoveFromList);
			_elements.RemoveAt(num);
		}
		if (_size != list.Count && _cntevent != null)
		{
			_cntevent(_size, list.Count);
		}
		_size = list.Count;
	}

	public void Release()
	{
		NotifyManager.PushToPool(this);
	}

	public void AddCountChange(Action<int, int> handler)
	{
		if (_cntevent != null)
		{
			_cntevent = (Action<int, int>)Delegate.Remove(_cntevent, handler);
			_cntevent = (Action<int, int>)Delegate.Combine(_cntevent, handler);
		}
		else
		{
			_cntevent = handler;
		}
	}

	public void RemoveCountChange(Action<int, int> handler)
	{
		if (_cntevent != null)
		{
			_cntevent = (Action<int, int>)Delegate.Remove(_cntevent, handler);
		}
	}
}
