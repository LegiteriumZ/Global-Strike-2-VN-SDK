using System.Collections.Generic;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class SimpleUIUpdater : MonoBehaviourSingleton<SimpleUIUpdater>
{
	private readonly Dictionary<string, IUIUpdater> _updaterDic = new Dictionary<string, IUIUpdater>();

	private readonly Dictionary<string, SimpleFreeUI> _simpleFreeDic = new Dictionary<string, SimpleFreeUI>();

	private readonly List<IUIUpdater> _updaters = new List<IUIUpdater>();

	private float _updateFrameDiff;

	private readonly List<IUIUpdater> _updatersLst = new List<IUIUpdater>(100);

	public Dictionary<string, SimpleFreeUI> SimpleFreeDic => _simpleFreeDic;

	public void AddUpdaterDic(IUIUpdater updater, string key)
	{
		if (updater != null)
		{
			if (_updaterDic.ContainsKey(key))
			{
				_updaterDic[key] = updater;
			}
			else
			{
				_updaterDic.Add(key, updater);
			}
		}
	}

	public void AddSimpleDic(SimpleFreeUI freeUi, string key)
	{
		if (!(freeUi == null))
		{
			if (_simpleFreeDic.ContainsKey(key))
			{
				_simpleFreeDic[key] = freeUi;
			}
			else
			{
				_simpleFreeDic.Add(key, freeUi);
			}
		}
	}

	public void AddList(IUIUpdater updater)
	{
		_updaters.Add(updater);
	}

	public void RemoveUpdaterDic(IUIUpdater updater, string key)
	{
		if (!string.IsNullOrEmpty(key) && _updaterDic.ContainsKey(key) && _updaterDic[key] == updater)
		{
			_updaterDic.Remove(key);
		}
	}

	public void RemoveSimpleDic(SimpleFreeUI freeUi, string key)
	{
		if (!string.IsNullOrEmpty(key) && _simpleFreeDic.ContainsKey(key) && _simpleFreeDic[key] == freeUi)
		{
			_simpleFreeDic.Remove(key);
		}
	}

	public void RemoveList(IUIUpdater updater)
	{
		_updaters.Remove(updater);
	}

	public void OnPlayback()
	{
		_updatersLst.Clear();
		foreach (KeyValuePair<string, IUIUpdater> item in _updaterDic)
		{
			_updatersLst.Add(item.Value);
		}
		foreach (IUIUpdater item2 in _updatersLst)
		{
			if (item2 != null && !item2.IsDisabled)
			{
				float num = Time.deltaTime * 1000f + _updateFrameDiff;
				int num2 = (int)num;
				_updateFrameDiff = num - (float)num2;
				item2.UIUpdate(num2);
			}
		}
		foreach (IUIUpdater updater in _updaters)
		{
			if (!updater.IsDisabled)
			{
				float num3 = Time.deltaTime * 1000f + _updateFrameDiff;
				int num4 = (int)num3;
				_updateFrameDiff = num3 - (float)num4;
				updater.UIUpdate(num4);
			}
		}
	}
}
