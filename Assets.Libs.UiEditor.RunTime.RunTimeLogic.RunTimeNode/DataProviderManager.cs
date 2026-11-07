using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Sources.Components.Time;
using SSJJAsset.Asset;
using SSJJBase.Manager;
using SSJJUIEditor.RunTime;
using UnityEngine;

namespace Assets.Libs.UiEditor.RunTime.RunTimeLogic.RunTimeNode;

public class DataProviderManager : BattleSingletonInstance<DataProviderManager>, IDataProviderManager
{
	public Dictionary<string, MethodInfo> Methods = new Dictionary<string, MethodInfo>();

	public ContextDataProvider contextDataProvider = new ContextDataProvider();

	public UiDataProvider uiDataProvider = new UiDataProvider();

	public PlayerDataProvider playerDataProvider = new PlayerDataProvider();

	public WeaponDataProvider weaponDataProvider = new WeaponDataProvider();

	public List<IModeExtraDataProvider> ModeProviders = new List<IModeExtraDataProvider>();

	public List<IWeaponExtraDefineProvider> WeaponExtraDefineProviders = new List<IWeaponExtraDefineProvider>();

	private TimeComponent _time;

	private int _frameCount;

	private string CurrentWeaponName = "";

	private AssetInfo _info;

	private GameObject _bindGameObject;

	public override void Clear()
	{
		ModeProviders.Clear();
		WeaponExtraDefineProviders.Clear();
	}

	public void OnFrame()
	{
		if (Time.frameCount == _frameCount)
		{
			return;
		}
		_frameCount = Time.frameCount;
		contextDataProvider.OnFrame(_time);
		playerDataProvider.OnFrame(_time);
		weaponDataProvider.OnFrame(_time);
		uiDataProvider.OnFrame(_time);
		foreach (IModeExtraDataProvider modeProvider in ModeProviders)
		{
			modeProvider.OnFrame(_time);
		}
		foreach (IWeaponExtraDefineProvider weaponExtraDefineProvider in WeaponExtraDefineProviders)
		{
			weaponExtraDefineProvider.OnFrame(_time);
		}
	}

	public void SetPlayerEntity(PlayerEntity player)
	{
		if (player != null)
		{
			CurrentWeaponName = player.GetCurrentWeaponName();
		}
		else
		{
			CurrentWeaponName = "";
		}
		playerDataProvider.SetPlayerEntity(player);
	}

	public void SetSceneObjectEntity(SceneObjectEntity scene)
	{
		playerDataProvider.SetSceneObjectEntity(scene);
	}

	public void Init(Contexts contexts)
	{
		_time = contexts.time.time;
		Type[] types = Assembly.GetExecutingAssembly().GetTypes();
		foreach (Type type in types)
		{
			SetModelProvider(type, contexts);
			SetWeaponDefinProvider(type, contexts);
			if (!ImplementsInterface<IDataProvider>(type))
			{
				continue;
			}
			MethodInfo[] methods = type.GetMethods();
			foreach (MethodInfo methodInfo in methods)
			{
				if (!Methods.ContainsKey(methodInfo.Name))
				{
					Methods.Add(methodInfo.Name, methodInfo);
				}
			}
		}
		playerDataProvider.Init(contexts);
		weaponDataProvider.Init(contexts);
		contextDataProvider.Init(contexts);
	}

	public void SetWeaponDefinProvider(Type type, Contexts contexts)
	{
		if (type.IsClass && !type.IsAbstract && ImplementsInterface<IWeaponExtraDefineProvider>(type))
		{
			IWeaponExtraDefineProvider weaponExtraDefineProvider = Activator.CreateInstance(type) as IWeaponExtraDefineProvider;
			weaponExtraDefineProvider.Init(contexts);
			WeaponExtraDefineProviders.Add(weaponExtraDefineProvider);
		}
	}

	public void SetModelProvider(Type type, Contexts contexts)
	{
		if (type.IsClass && !type.IsAbstract && ImplementsInterface<IModeExtraDataProvider>(type))
		{
			IModeExtraDataProvider modeExtraDataProvider = Activator.CreateInstance(type) as IModeExtraDataProvider;
			modeExtraDataProvider.Init(contexts);
			ModeProviders.Add(modeExtraDataProvider);
		}
	}

	public MethodInfo GetMethod(string methodName)
	{
		MethodInfo value = null;
		Methods.TryGetValue(methodName, out value);
		return value;
	}

	public bool ImplementsInterface<T>(Type type)
	{
		if (!type.IsInterface)
		{
			return type.GetInterfaces().Contains(typeof(T));
		}
		return false;
	}

	public void SetInitAssetInfo(AssetInfo info, GameObject bindGameObject)
	{
		_info = info;
		_bindGameObject = bindGameObject;
	}

	public AssetInfo GetAssetInfo()
	{
		return _info;
	}

	public string GetWeaponName()
	{
		if (!string.IsNullOrEmpty(CurrentWeaponName))
		{
			return CurrentWeaponName;
		}
		string info = _info.BundleName.Info;
		if (info.StartsWith("weapon/"))
		{
			return info.Replace("weapon/", "");
		}
		return "null";
	}

	public string GetBindingName()
	{
		return _bindGameObject.name;
	}

	public bool hasWeaponExtraDefineProvider(string weaponName)
	{
		for (int i = 0; i < WeaponExtraDefineProviders.Count; i++)
		{
			if (WeaponExtraDefineProviders[i].KeyInfo.Equals(weaponName, StringComparison.CurrentCultureIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}
}
