using System.Collections.Generic;
using SSJJBase.Pool;
using UnityEngine;

namespace Assets.Sources.Utils.Ui;

public class UiReferences : MonoBehaviour
{
	public Component[] StaticRefs;

	private Dictionary<string, List<Component>> _cacheTrans;

	private List<string> _failedKey;

	public Component this[string key]
	{
		get
		{
			return Get<Component>(key);
		}
		set
		{
			Push(key, value);
		}
	}

	private void Awake()
	{
		BindForStaticRefs();
	}

	private void OnDestroy()
	{
		if (_cacheTrans == null)
		{
			return;
		}
		foreach (KeyValuePair<string, List<Component>> cacheTran in _cacheTrans)
		{
			ListPool<Component>.Release(cacheTran.Value);
		}
		_cacheTrans = null;
	}

	private void BindForStaticRefs()
	{
		if (StaticRefs != null)
		{
			Component[] staticRefs = StaticRefs;
			foreach (Component component in staticRefs)
			{
				Push(component.name, component);
			}
		}
	}

	public T Get<T>(string key) where T : Component
	{
		List<Component> list = FindTrans(key);
		if (list != null && list.Count > 0)
		{
			T val = list[0] as T;
			if (val != null)
			{
				return val;
			}
			return list[0].GetComponent<T>();
		}
		return null;
	}

	public Transform Get(string key)
	{
		List<Component> list = FindTrans(key);
		if (list != null && list.Count > 0)
		{
			return list[0].transform;
		}
		return null;
	}

	public void Set<T>(string key, T comp) where T : Component
	{
		Push(key, comp);
	}

	public void Set(string key, GameObject comp)
	{
		Push(key, comp.transform);
	}

	public List<Component> FindTrans(string key)
	{
		List<Component> value = null;
		if (_cacheTrans != null && _cacheTrans.TryGetValue(key, out value))
		{
			return value;
		}
		if (_failedKey == null)
		{
			_failedKey = new List<string>();
		}
		if (!_failedKey.Contains(key))
		{
			_failedKey.Add(key);
			Component[] componentsInChildren = base.transform.GetComponentsInChildren<Component>(includeInactive: true);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				Component component = componentsInChildren[i];
				if (component.name == key)
				{
					Push(key, component);
				}
			}
			if (_cacheTrans != null)
			{
				_cacheTrans.TryGetValue(key, out value);
				return value;
			}
		}
		return value;
	}

	private void Push(string key, Component target)
	{
		if (_cacheTrans == null)
		{
			_cacheTrans = new Dictionary<string, List<Component>>();
		}
		if (_cacheTrans.TryGetValue(key, out var value))
		{
			if (!value.Contains(target))
			{
				value.Add(target);
			}
		}
		else
		{
			value = ListPool<Component>.Get();
			value.Add(target);
			_cacheTrans.Add(key, value);
		}
	}
}
