using System;
using System.Collections;
using System.Collections.Generic;
using SSJJBase.Logger;
using UnityEngine;

namespace NotifyEvent;

public class NotifyManager
{
	private struct WeakKey : IEquatable<WeakKey>
	{
		public readonly WeakReference WeakRef;

		public WeakKey(WeakReference refData)
		{
			WeakRef = refData;
		}

		public bool Equals(WeakKey other)
		{
			if (WeakRef.IsAlive != other.WeakRef.IsAlive)
			{
				return false;
			}
			if (WeakRef.Target != other.WeakRef.Target)
			{
				return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			if (WeakRef != null && WeakRef.IsAlive)
			{
				return WeakRef.Target.GetHashCode();
			}
			return 0;
		}
	}

	internal class Pool<TValue> : INotifyPool where TValue : class, new()
	{
		private readonly Stack<TValue> _queue = new Stack<TValue>();

		private readonly Type _poolType = typeof(TValue);

		public T Get<T>() where T : class, new()
		{
			if (typeof(T) == _poolType)
			{
				T val = null;
				if (_queue.Count > 0)
				{
					return _queue.Pop() as T;
				}
				return new T();
			}
			return null;
		}

		public void Clear()
		{
			_queue.Clear();
		}

		public int Count()
		{
			return _queue.Count;
		}

		public void Add<T>(T val) where T : class
		{
			if (typeof(T) == _poolType)
			{
				if (val is IList)
				{
					(val as IList).Clear();
				}
				else if (val is IDictionary)
				{
					(val as IDictionary).Clear();
				}
				_queue.Push(val as TValue);
			}
		}
	}

	private static LoggerAdapter _logger = new LoggerAdapter(typeof(NotifyManager));

	internal const bool Log = false;

	private static int _counter = 0;

	private static readonly Dictionary<WeakKey, List<int>> WeakDict = new Dictionary<WeakKey, List<int>>();

	private static readonly Dictionary<int, INotify> ValueDict = new Dictionary<int, INotify>();

	private static readonly List<WeakKey> RemoveList = new List<WeakKey>();

	private static readonly Dictionary<Type, INotifyPool> PoolDict = new Dictionary<Type, INotifyPool>();

	private static readonly List<int> ReinvokeList = new List<int>();

	private static int _frameCount;

	public static bool TryGetNotify(int key, out INotify notify)
	{
		return ValueDict.TryGetValue(key, out notify);
	}

	internal static T RequireFromPool<T>() where T : class, new()
	{
		if (!PoolDict.TryGetValue(typeof(T), out var value))
		{
			value = new Pool<T>();
			PoolDict.Add(typeof(T), value);
		}
		return value.Get<T>();
	}

	internal static void PushToPool<T>(T val) where T : class, new()
	{
		if (PoolDict.TryGetValue(typeof(T), out var value))
		{
			value.Add(val);
			return;
		}
		value = new Pool<T>();
		value.Add(val);
		PoolDict.Add(typeof(T), value);
	}

	public static void Clear()
	{
		WeakDict.Clear();
		foreach (KeyValuePair<int, INotify> item in ValueDict)
		{
			item.Value?.Release();
		}
		ValueDict.Clear();
		PoolDict.Clear();
		RemoveList.Clear();
		ReinvokeList.Clear();
	}

	public static void Remove(GameObject gameObject)
	{
		if (WeakDict == null)
		{
			return;
		}
		foreach (KeyValuePair<WeakKey, List<int>> item in WeakDict)
		{
			WeakReference weakRef = item.Key.WeakRef;
			if (weakRef != null && weakRef.IsAlive && (!weakRef.IsAlive || !weakRef.Target.Equals(gameObject)))
			{
				continue;
			}
			List<int> value = item.Value;
			foreach (int item2 in value)
			{
				ValueDict.Remove(item2);
			}
			RemoveList.Add(item.Key);
			PushToPool(value);
		}
		if (RemoveList.Count > 0)
		{
			for (int i = 0; i < RemoveList.Count; i++)
			{
				WeakDict.Remove(RemoveList[i]);
			}
			RemoveList.Clear();
		}
	}

	public static void RemoveUnused()
	{
		if (WeakDict == null)
		{
			return;
		}
		foreach (KeyValuePair<WeakKey, List<int>> item in WeakDict)
		{
			WeakReference weakRef = item.Key.WeakRef;
			if (weakRef != null && weakRef.IsAlive)
			{
				continue;
			}
			List<int> value = item.Value;
			foreach (int item2 in value)
			{
				ValueDict.Remove(item2);
			}
			RemoveList.Add(item.Key);
			PushToPool(value);
		}
		if (RemoveList.Count > 0)
		{
			for (int i = 0; i < RemoveList.Count; i++)
			{
				WeakDict.Remove(RemoveList[i]);
			}
			RemoveList.Clear();
		}
	}

	public static void TryRemoveEvent<T>(int id, Action<T, T> eventFunc)
	{
		if (ValueDict.TryGetValue(id, out var value) && value is IValueNotify)
		{
			(value as IValueNotify).RemoveEvent(null, eventFunc);
		}
	}

	public static void ForceInvoke(int eventid)
	{
		try
		{
			if (ValueDict.TryGetValue(eventid, out var value))
			{
				value.ForceInvoke();
			}
			else
			{
				ReinvokeList.Add(eventid);
			}
		}
		catch (Exception args)
		{
			_logger.ErrorFormat("NotifyManager.ForceInvoke error : {0}", args);
		}
	}

	public static void ForceInvokeGroupEvent(int eventid, int subEventId = -1)
	{
		try
		{
			if (ValueDict.TryGetValue(eventid, out var value))
			{
				value.ForceInvoke(subEventId);
			}
			else
			{
				ReinvokeList.Add(eventid);
			}
		}
		catch (Exception args)
		{
			_logger.ErrorFormat("NotifyManager.ForceInvoke error : {0}", args);
		}
	}

	public static void Reinvoke()
	{
		if (ReinvokeList.Count == 0)
		{
			return;
		}
		foreach (int reinvoke in ReinvokeList)
		{
			try
			{
				if (ValueDict.TryGetValue(reinvoke, out var value))
				{
					value.ForceInvoke();
				}
			}
			catch (Exception args)
			{
				_logger.ErrorFormat("NotifyManager.ForceInvoke error : {0}", args);
			}
		}
		ReinvokeList.Clear();
	}

	internal static INotify GetNotifyVal(int id)
	{
		if (ValueDict.TryGetValue(id, out var value))
		{
			return value;
		}
		return null;
	}

	public static int MakeTempNotify<T>(Func<T> getFunc, Action<T, T> eventFunc, GameObject binder = null, bool initinvoke = false, bool isFrameSeparation = false) where T : struct
	{
		int num = --_counter;
		if (binder != null)
		{
			WeakKey key = new WeakKey(new WeakReference(binder));
			if (WeakDict.TryGetValue(key, out var value))
			{
				value.Add(num);
			}
			else
			{
				List<int> list = RequireFromPool<List<int>>();
				list.Add(num);
				WeakDict.Add(key, list);
			}
		}
		return MakeNotify(num, getFunc, eventFunc, initinvoke, isFrameSeparation);
	}

	public static int MakeTempNotifyClass<T>(Func<T> getFunc, Action<T, T> eventFunc, GameObject binder = null, bool initinvoke = false, bool isFrameSeparation = false) where T : class
	{
		int num = --_counter;
		if (binder != null)
		{
			WeakKey key = new WeakKey(new WeakReference(binder));
			if (WeakDict.TryGetValue(key, out var value))
			{
				value.Add(num);
			}
			else
			{
				List<int> list = RequireFromPool<List<int>>();
				list.Add(num);
				WeakDict.Add(key, list);
			}
		}
		return MakeNotifyClass(num, getFunc, eventFunc, initinvoke, isFrameSeparation);
	}

	public static int MakeNotify<T>(int id, Func<T> getFunc, Action<T, T> eventFunc, bool initinvoke = false, bool isFrameSeparation = false) where T : struct
	{
		if (!ValueDict.TryGetValue(id, out var value))
		{
			NotifyValue<T> notifyValue = RequireFromPool<NotifyValue<T>>();
			notifyValue.Bind(getFunc, eventFunc, isFrameSeparation);
			value = notifyValue;
			ValueDict.Add(id, value);
			if (initinvoke)
			{
				notifyValue.ForceInvoke();
			}
		}
		else
		{
			if (value is IValueNotify)
			{
				(value as IValueNotify).AddEvent(getFunc, eventFunc);
			}
			if (initinvoke)
			{
				value.ForceInvoke();
			}
		}
		return id;
	}

	public static int MakeNotifyClass<T>(int id, Func<T> getFunc, Action<T, T> eventFunc, bool initinvoke = false, bool isFrameSeparation = false) where T : class
	{
		if (!ValueDict.TryGetValue(id, out var value))
		{
			NotifyClassValue<T> notifyClassValue = RequireFromPool<NotifyClassValue<T>>();
			notifyClassValue.Bind(getFunc, eventFunc, isFrameSeparation);
			value = notifyClassValue;
			ValueDict.Add(id, value);
			if (initinvoke)
			{
				notifyClassValue.ForceInvoke();
			}
		}
		else
		{
			if (value is IValueNotify)
			{
				(value as IValueNotify).AddEvent(getFunc, eventFunc);
			}
			if (initinvoke && eventFunc != null)
			{
				T arg = null;
				if (getFunc != null)
				{
					arg = getFunc();
				}
				eventFunc(null, arg);
			}
		}
		return id;
	}

	public static IListNotify MakeNotifyList<T>(int id, Func<List<T>> getfunc, bool initinvoke = false) where T : class
	{
		if (!ValueDict.TryGetValue(id, out var value))
		{
			NotifyList<T> notifyList = new NotifyList<T>();
			notifyList.Bind(getfunc);
			notifyList.Id = id;
			value = notifyList;
			ValueDict.Add(id, value);
			if (initinvoke)
			{
				value.ForceInvoke();
			}
		}
		return value as IListNotify;
	}

	public static IListNotify MakeTempNotifyList<T>(Func<List<T>> getfunc, int id = -1, GameObject Binder = null, bool initinvoke = false) where T : class
	{
		int num = ((id != -1) ? id : (--_counter));
		if (Binder != null)
		{
			WeakKey key = new WeakKey(new WeakReference(Binder));
			if (WeakDict.TryGetValue(key, out var value))
			{
				value.Add(num);
			}
			else
			{
				WeakDict.Add(key, new List<int> { num });
			}
		}
		return MakeNotifyList(num, getfunc, initinvoke);
	}

	public static void Step()
	{
		if (ValueDict == null)
		{
			return;
		}
		_frameCount++;
		int nowFrame = _frameCount % 10;
		foreach (KeyValuePair<int, INotify> item in ValueDict)
		{
			try
			{
				if (!item.Value.Suspend)
				{
					item.Value.TryNotify(nowFrame);
				}
			}
			catch (Exception message)
			{
				_logger.Error(message);
			}
		}
	}
}
