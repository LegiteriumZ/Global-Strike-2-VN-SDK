using System;
using System.Collections.Generic;
using SSJJBase.Logger;
using SSJJUniRx;

namespace Assets.Libs.NotifyLib.Simplify;

public static class SimpleNotify
{
	private static LoggerAdapter _logger = new LoggerAdapter(typeof(SimpleNotify));

	private static Dictionary<int, ISimpleNotifyInfo> _reactiveDic = new Dictionary<int, ISimpleNotifyInfo>();

	private static int _idCount;

	public static int Add<T>(Func<int, T> getFunc, Action<T, int> setFunc, int index = 0)
	{
		NotifyInfo<T> notifyInfo = new NotifyInfo<T>
		{
			Id = ++_idCount,
			Reactive = new SimpleReactive<T>(),
			GetFunc = getFunc,
			SetFunc = setFunc,
			Index = index
		};
		_reactiveDic.Add(notifyInfo.Id, notifyInfo);
		notifyInfo.Disposeable = notifyInfo.Reactive.Subscribe(delegate(T v)
		{
			setFunc(v, index);
		});
		return notifyInfo.Id;
	}

	public static int AddClear<T>(Func<int, T> clearFunc = null)
	{
		NotifyInfo<T> notifyInfo = new NotifyInfo<T>
		{
			Id = ++_idCount,
			ClearFunc = clearFunc
		};
		_reactiveDic.Add(notifyInfo.Id, notifyInfo);
		return notifyInfo.Id;
	}

	public static void Dispose(int id)
	{
		if (_reactiveDic.TryGetValue(id, out var value))
		{
			value.Dispose();
			_reactiveDic.Remove(id);
		}
	}

	public static void Update()
	{
		foreach (KeyValuePair<int, ISimpleNotifyInfo> item in _reactiveDic)
		{
			try
			{
				item.Value.Update();
			}
			catch (Exception message)
			{
				_logger.LogError(message);
			}
		}
	}

	public static void Clear()
	{
		foreach (KeyValuePair<int, ISimpleNotifyInfo> item in _reactiveDic)
		{
			try
			{
				if (item.Value != null)
				{
					item.Value.Clear();
				}
			}
			catch (Exception message)
			{
				_logger.LogError(message);
			}
		}
	}

	internal static bool TryGetNotify(int key, out ISimpleNotifyInfo notify)
	{
		return _reactiveDic.TryGetValue(key, out notify);
	}
}
