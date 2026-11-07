using System.Collections;
using System.Collections.Generic;
using Assets.Libs.SJAnimation.Parser;
using Assets.Libs.UiEditor.RunTime;
using Assets.Libs.UiEditor.RunTime.RunTimeLogic.RunTimeNode;
using Entitas.Utils;
using SSJJAnim.Parser;
using SSJJAsset.Asset;
using SSJJAsset.AssetLoader.Xml;
using SSJJAsset.AssetManager;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using SSJJRunTimeDataSample;
using SSJJUIEditor.ParticleEditor;
using SSJJUIEditor.UI;
using UnityEngine;

namespace Assets.Sources.Utils.AssetManager;

public class AssetPool : SingletonInstance<AssetPool>, IAssetPool
{
	private readonly Dictionary<AssetInfo, bool> _failedTasks = new Dictionary<AssetInfo, bool>();

	private readonly Dictionary<AssetInfo, bool> _pendingTasks = new Dictionary<AssetInfo, bool>();

	private readonly Dictionary<AssetInfo, object> _poolDict = new Dictionary<AssetInfo, object>();

	public Dictionary<AssetInfo, bool> GetFailedTasks()
	{
		return _failedTasks;
	}

	public Dictionary<AssetInfo, bool> GetPendingTasks()
	{
		return _pendingTasks;
	}

	public Dictionary<AssetInfo, object> GetPoolObjs()
	{
		return _poolDict;
	}

	public bool IsLoadFailed(AssetInfo assetInfo)
	{
		if (_failedTasks.ContainsKey(assetInfo))
		{
			return _failedTasks[assetInfo];
		}
		return false;
	}

	public void Add(string bundleName, string assetName, object obj)
	{
		AssetInfo assetInfo = new AssetInfo(bundleName, assetName);
		Add(assetInfo, obj);
	}

	public void Add(AssetInfo assetInfo, object obj)
	{
		if (!_poolDict.ContainsKey(assetInfo))
		{
			_poolDict[assetInfo] = obj;
		}
	}

	public void Remove(AssetInfo assetInfo)
	{
		if (_poolDict.ContainsKey(assetInfo))
		{
			_poolDict.Remove(assetInfo);
		}
		if (_pendingTasks.ContainsKey(assetInfo))
		{
			_pendingTasks.Remove(assetInfo);
		}
	}

	public void LoadAndAdd(AssetInfo assetInfo, ICoRoutineManager coRoutineManager)
	{
		if (!_poolDict.ContainsKey(assetInfo) && !_pendingTasks.ContainsKey(assetInfo))
		{
			coRoutineManager.StartCoRoutine(Load(assetInfo));
		}
	}

	public void LoadAndAdd(AssetInfo[] assetInfos, ICoRoutineManager coRoutineManager)
	{
		for (int i = 0; i < assetInfos.Length; i++)
		{
			LoadAndAdd(assetInfos[i], coRoutineManager);
		}
	}

	public object GetOrNull(AssetInfo assetInfo)
	{
		_poolDict.TryGetValue(assetInfo, out var value);
		return value;
	}

	public object GetOrNull(string bundleName, string assetName)
	{
		return GetOrNull(new AssetInfo(bundleName, assetName));
	}

	public void LoadAndAdd(string bundleName, string assetName, ICoRoutineManager coRoutineManager)
	{
		AssetInfo assetInfo = new AssetInfo(bundleName, assetName);
		LoadAndAdd(assetInfo, coRoutineManager);
	}

	public IEnumerator WaitForAsset(AssetInfo assetInfo)
	{
		while (!IsAssetLoadFinish(assetInfo))
		{
			yield return null;
		}
	}

	public bool IsAssetLoadFinish(AssetInfo assetInfo)
	{
		if (GetOrNull(assetInfo) == null)
		{
			return _failedTasks.ContainsKey(assetInfo);
		}
		return true;
	}

	public IEnumerator LoadAndAdd(AssetInfo[] assetInfos)
	{
		for (int i = 0; i < assetInfos.Length; i++)
		{
			yield return Load(assetInfos[0]);
		}
	}

	private IEnumerator Load(AssetInfo assetInfo)
	{
		if (SingletonInstance<DataSampleContexts>.Instance.AddToPoolRequestAction != null)
		{
			SingletonInstance<DataSampleContexts>.Instance.AddToPoolRequestAction(assetInfo);
		}
		if (assetInfo.AssetType == typeof(GameObject))
		{
			yield return Load<GameObject>(assetInfo);
		}
		else if (assetInfo.AssetType == typeof(Sprite))
		{
			yield return Load<Sprite>(assetInfo);
		}
		else if (assetInfo.AssetType == typeof(Texture2D))
		{
			yield return Load<Texture2D>(assetInfo);
		}
		else if (assetInfo.AssetType == typeof(TextAsset))
		{
			yield return Load<TextAsset>(assetInfo);
		}
		else if (assetInfo.AssetType == typeof(Material))
		{
			yield return Load<Material>(assetInfo);
		}
		else if (assetInfo.AssetType == typeof(Mesh))
		{
			yield return Load<Mesh>(assetInfo);
		}
		else if (assetInfo.AssetType == typeof(SJAnimationAsset))
		{
			yield return LoadSjAnimationAsset(assetInfo);
		}
		else if (assetInfo.AssetType != null && assetInfo.AssetType.ImplementsInterface<IXmlAsset>())
		{
			yield return LoadXmlAsset(assetInfo);
		}
		else if (assetInfo.AssetType == typeof(UiEditorLogicAsset))
		{
			yield return LoadUiEditorLogicAsset(assetInfo);
		}
		else if (assetInfo.AssetType == typeof(UiEditorLayoutAsset))
		{
			yield return LoadUiEditorLayoutAsset(assetInfo);
		}
		else if (assetInfo.AssetType == typeof(ParticleEditorLogicAsset))
		{
			yield return LoadParticleEditorLogicAsset(assetInfo);
		}
		else
		{
			yield return Load<Object>(assetInfo);
		}
	}

	private IEnumerator LoadXmlAsset(AssetInfo assetInfo)
	{
		_pendingTasks[assetInfo] = true;
		XmlAssetAsyncLoader loader = new XmlAssetAsyncLoader(assetInfo.AssetType);
		yield return loader.LoadAsync(assetInfo);
		if (loader.Result != null)
		{
			Add(assetInfo, loader.Result);
		}
		else
		{
			_failedTasks[assetInfo] = true;
		}
		_pendingTasks[assetInfo] = false;
	}

	private IEnumerator Load<T>(AssetInfo assetInfo) where T : Object
	{
		_pendingTasks[assetInfo] = true;
		AssetAsyncLoader<T> loader = new AssetAsyncLoader<T>();
		yield return loader.LoadAsync(assetInfo);
		if (loader.Result != null)
		{
			Add(assetInfo, loader.Result);
		}
		else
		{
			_failedTasks[assetInfo] = true;
		}
		_pendingTasks[assetInfo] = false;
	}

	private IEnumerator LoadUiEditorLayoutAsset(AssetInfo assetInfo)
	{
		_pendingTasks[assetInfo] = true;
		UiEditorLayoutParser parser = new UiEditorLayoutParser();
		yield return parser.LoadAsync(assetInfo, Contexts.sharedInstance.battleRoom.gameObjectPool.Pool, RunTimeBindingManager.Instance, TextStyleManager.Instance);
		if (parser.Result != null)
		{
			Add(assetInfo, parser.Result);
		}
		else
		{
			_failedTasks[assetInfo] = true;
		}
		_pendingTasks[assetInfo] = false;
	}

	private IEnumerator LoadParticleEditorLogicAsset(AssetInfo assetInfo)
	{
		_pendingTasks[assetInfo] = true;
		ParticleEditorLogicParser parser = new ParticleEditorLogicParser();
		yield return parser.LoadAsync(assetInfo, SingletonInstance<RunTimeDataArithmeticFunc>.Instance, BattleSingletonInstance<DataProviderManager>.Instance);
		if (parser.Result != null)
		{
			Add(assetInfo, parser.Result);
		}
		else
		{
			_failedTasks[assetInfo] = true;
		}
		_pendingTasks[assetInfo] = false;
	}

	private IEnumerator LoadUiEditorLogicAsset(AssetInfo assetInfo)
	{
		_pendingTasks[assetInfo] = true;
		UiEditorLogicParser parser = new UiEditorLogicParser();
		yield return parser.LoadAsync(assetInfo);
		if (parser.Result != null)
		{
			Add(assetInfo, parser.Result);
		}
		else
		{
			_failedTasks[assetInfo] = true;
		}
		_pendingTasks[assetInfo] = false;
	}

	private IEnumerator LoadSjAnimationAsset(AssetInfo assetInfo)
	{
		_pendingTasks[assetInfo] = true;
		SJAnimationLoader loader = new SJAnimationLoader();
		yield return loader.LoadAsync(assetInfo);
		if (loader.Result != null)
		{
			Add(assetInfo, loader.Result);
		}
		else
		{
			_failedTasks[assetInfo] = true;
		}
		_pendingTasks[assetInfo] = false;
	}
}
