using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Sources.Components.Time;
using Assets.Sources.Ui.DynamicLoader;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.UiFramework.Libs;

public class AbstractModel
{
	private static LoggerAdapter _logger = new LoggerAdapter(typeof(AbstractModel));

	private static IUiResourcesLoader _loader;

	private readonly HashSet<string> _loadedConfigs = new HashSet<string>();

	private int _waitingCount;

	protected GameObject Instance;

	protected TimeComponent _timeComponent;

	private static Dictionary<object, Dictionary<int, List<Action<int>>>> _updateHandler = new Dictionary<object, Dictionary<int, List<Action<int>>>>();

	private static List<UnityEngine.Object> _instantiateObjects = new List<UnityEngine.Object>();

	private static List<Action<UnityEngine.Object>> _instantiateActions = new List<Action<UnityEngine.Object>>();

	public static int InstantiateCount;

	public static int LoadCount;

	private static List<Action> _subscribeActions = new List<Action>();

	private static List<Action> _preSubscribeActions = new List<Action>();

	public static Vector2 BestScreenSize = new Vector2(1680f, 1050f);

	public static CanvasScaler.ScaleMode BestScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

	private Dictionary<string, string> _config = new Dictionary<string, string>();

	protected IUiResourcesLoader Loader => _loader;

	protected virtual UiAssetInfo ResourceRequest => new UiAssetInfo(ViewModel.ResourceBundleName, ViewModel.ResourceAssetName);

	protected virtual List<UiAssetInfo> ConfigRequests => null;

	protected virtual IUiViewModel ViewModel
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	protected void AddUpdateHandler(Action<int> handler, int index = -1)
	{
		if (!_updateHandler.ContainsKey(this))
		{
			_updateHandler.Add(this, new Dictionary<int, List<Action<int>>>());
		}
		Dictionary<int, List<Action<int>>> dictionary = _updateHandler[this];
		if (!dictionary.ContainsKey(index))
		{
			dictionary.Add(index, new List<Action<int>>());
		}
		if (!dictionary[index].Contains(handler))
		{
			dictionary[index].Add(handler);
		}
	}

	public static void InvokeUpdateHandler()
	{
		foreach (KeyValuePair<object, Dictionary<int, List<Action<int>>>> item in _updateHandler)
		{
			foreach (KeyValuePair<int, List<Action<int>>> item2 in item.Value)
			{
				foreach (Action<int> item3 in item2.Value)
				{
					try
					{
						item3(item2.Key);
					}
					catch (Exception args)
					{
						_logger.ErrorFormat("Invoke Single Update Error : {0}", args);
					}
				}
			}
		}
		_updateHandler.Clear();
	}

	public static void SetUiResourceLoader(IUiResourcesLoader loader)
	{
		_loader = loader;
	}

	public static IUiResourcesLoader GetUiResourceLoader()
	{
		return _loader;
	}

	public virtual void Initialize()
	{
		_timeComponent = Contexts.sharedInstance.time.time;
		CreateUi();
	}

	public virtual void CreateViewModel()
	{
	}

	public virtual void Destory()
	{
		ViewModel.Destory();
		OnGameobjectDestoryed();
	}

	protected virtual void DoSubscribe()
	{
	}

	protected virtual void DoPreSubscribe()
	{
	}

	protected virtual void OnGameobjectDestoryed()
	{
	}

	private void CreateUi()
	{
		BattleSingletonInstance<UiDynamicLoadManager>.Instance.Init(_loader);
		if (!string.IsNullOrEmpty(ViewModel.ResourceBundleName) && !string.IsNullOrEmpty(ViewModel.ResourceAssetName))
		{
			_loader.Load(ViewModel.ResourceBundleName, ViewModel.ResourceAssetName, AddInstantiateList, typeof(GameObject));
		}
		LoadConfig();
	}

	protected void LoadConfig()
	{
		if (ConfigRequests == null)
		{
			return;
		}
		ConfigRequests.ForEach(delegate(UiAssetInfo configRequest)
		{
			_waitingCount++;
			if (!string.IsNullOrEmpty(configRequest.BundleName) && !string.IsNullOrEmpty(configRequest.AssetName))
			{
				if (IsConfigExist(configRequest.BundleName, configRequest.AssetName))
				{
					GetConfigValue();
				}
				else
				{
					_loader.Load(configRequest.BundleName, configRequest.AssetName, ParseConfig);
					_loadedConfigs.Add(string.Concat(configRequest.BundleName, configRequest.AssetName));
				}
			}
		});
	}

	public IUiViewModel GetViewModel()
	{
		return ViewModel;
	}

	private bool IsConfigExist(string bundleName, string assetName)
	{
		return _loadedConfigs.Contains(bundleName + assetName);
	}

	private bool IsPrefab(GameObject go)
	{
		if (Application.isEditor && !Application.isPlaying)
		{
			throw new InvalidOperationException("MethodIsOnlyAllowedInPlayMode");
		}
		return go.scene.buildIndex < 0;
	}

	private void AddInstantiateList(UnityEngine.Object obj)
	{
		_instantiateObjects.Add(obj);
		_instantiateActions.Add(Instantiate);
	}

	public static void InvokeInstantiate()
	{
		if (_instantiateActions.Count > 0)
		{
			Action<UnityEngine.Object> action = _instantiateActions[0];
			UnityEngine.Object obj = _instantiateObjects[0];
			_instantiateActions.RemoveAt(0);
			_instantiateObjects.RemoveAt(0);
			InstantiateCount++;
			try
			{
				action(obj);
			}
			catch (Exception args)
			{
				_logger.ErrorFormat("Invoke Instantiate Error : {0}", args);
			}
		}
	}

	public static void InvokePreSubscribe()
	{
		foreach (Action preSubscribeAction in _preSubscribeActions)
		{
			try
			{
				preSubscribeAction();
			}
			catch (Exception args)
			{
				_logger.ErrorFormat("Invoke Pre Subscribe Error : {0}", args);
			}
		}
		_preSubscribeActions.Clear();
	}

	public static void InvokeSubscribe()
	{
		foreach (Action subscribeAction in _subscribeActions)
		{
			try
			{
				subscribeAction();
			}
			catch (Exception args)
			{
				_logger.ErrorFormat("Invoke Subscribe Error : {0}", args);
			}
		}
		_subscribeActions.Clear();
	}

	private void Instantiate(UnityEngine.Object obj)
	{
		GameObject gameObject = obj as GameObject;
		if (IsPrefab(gameObject))
		{
			gameObject = gameObject.CreateInstance();
		}
		ViewModel.CreateBinding(gameObject);
		RemoveEventSystem(gameObject);
		FitToScreen(gameObject);
		Instance = gameObject;
		OnGameobjectInitialized();
	}

	private List<Transform> GetAllTran(Transform transform)
	{
		List<Transform> list = new List<Transform>();
		GetAllTrans(transform, list);
		return list;
	}

	private void GetAllTrans(Transform transform, List<Transform> transforms)
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			transforms.Add(transform.GetChild(i));
			GetAllTrans(transform.GetChild(i), transforms);
		}
	}

	protected virtual CanvasScaler.ScaleMode GetScaleModel()
	{
		return BestScaleMode;
	}

	protected virtual void FitToScreen(GameObject instance)
	{
		Canvas component = instance.GetComponent<Canvas>();
		if (null != component)
		{
			CanvasScaler canvasScaler = component.GetComponent<CanvasScaler>();
			if (null == canvasScaler)
			{
				canvasScaler = component.gameObject.AddComponent<CanvasScaler>();
			}
			canvasScaler.uiScaleMode = GetScaleModel();
			canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
			canvasScaler.matchWidthOrHeight = 1f;
			canvasScaler.referenceResolution = BestScreenSize;
		}
	}

	private void RemoveEventSystem(GameObject instance)
	{
		EventSystem component = instance.GetComponent<EventSystem>();
		if (null != component)
		{
			UnityEngine.Object.Destroy(component);
		}
	}

	protected virtual void OnGameobjectInitialized()
	{
		_subscribeActions.Add(DoSubscribe);
		_preSubscribeActions.Add(DoPreSubscribe);
	}

	private void ParseConfig(UnityEngine.Object obj)
	{
		foreach (XElement item in from el in XElement.Parse(((TextAsset)obj).text).Elements()
			select (el))
		{
			foreach (XAttribute item2 in item.Attributes())
			{
				_config.ContainsKey(item2.Name.LocalName);
				_config[item2.Name.LocalName] = item2.Value;
			}
			_config.ContainsKey(item.Name.LocalName);
			_config[item.Name.LocalName] = item.Value;
		}
		_waitingCount--;
		if (_waitingCount < 1)
		{
			GetConfigValue();
		}
	}

	protected string GetValue(string key)
	{
		if (!_config.ContainsKey(key))
		{
			return null;
		}
		return _config[key];
	}

	protected virtual void GetConfigValue()
	{
		throw new NotImplementedException();
	}

	public void Visible(bool b)
	{
		ViewModel.Visible(b);
	}

	protected void SetWeaponImage(string weaponName, string uiname, Image img)
	{
		Loader.RetriveSprite($"weapon/{weaponName}", $"Assets/Res/Assets/weapon/{weaponName}/ui/{uiname}.png", img);
	}

	protected AssetInfo GetWeaponAssetInfo(string weaponName, string uiname)
	{
		return new AssetInfo($"weapon/{weaponName}", $"Assets/Res/Assets/weapon/{weaponName}/ui/{uiname}.png");
	}

	protected virtual void ConvertLargeNummber(long value, ref bool[] shows, out string wholeStr, out string decimalStr)
	{
		long num = 0L;
		long num2 = 0L;
		long num3 = 1000000000000L;
		long num4 = 10000000000000000L;
		bool flag = false;
		if (value >= num4 && shows.Length >= 6)
		{
			num = value / num4;
			num2 = value % num4;
			flag = ((num2 >= num4 / 10) ? true : false);
			shows[2] = false;
			shows[3] = false;
			shows[4] = false;
			shows[5] = true;
		}
		else if (value >= num3 && shows.Length >= 6)
		{
			num = value / num3;
			num2 = value % num3;
			flag = ((num2 >= num3 / 10) ? true : false);
			shows[2] = false;
			shows[3] = false;
			shows[4] = true;
			shows[5] = false;
		}
		else if (value >= 100000000)
		{
			num = value / 100000000;
			num2 = value % 100000000;
			flag = ((num2 >= 10000000) ? true : false);
			shows[2] = false;
			shows[3] = true;
		}
		else if (value >= 10000)
		{
			num = value / 10000;
			num2 = value % 10000;
			flag = ((num2 >= 1000) ? true : false);
			shows[2] = true;
			shows[3] = false;
		}
		else
		{
			num = value;
			shows[2] = false;
			shows[3] = false;
		}
		shows[0] = flag;
		shows[1] = flag;
		wholeStr = num.ToString();
		decimalStr = (flag ? num2.ToString().Substring(0, 1) : "");
	}

	protected virtual void LargeNumberPosition(bool usingDot, bool usingSuffix, string wholeStr, string decimalStr, out Vector3[] positions, Vector2 offset)
	{
		positions = new Vector3[0];
	}
}
