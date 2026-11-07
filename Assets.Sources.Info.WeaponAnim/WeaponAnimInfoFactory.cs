using System.Collections;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Weapon;
using SSJJAnim.WeaponAnim;
using SSJJAsset.AssetManager;
using SSJJBase.Cache;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Info.WeaponAnim;

public class WeaponAnimInfoFactory
{
	public static WeaponAnimInfoFactory Instance = new WeaponAnimInfoFactory();

	private readonly ObjectCache<string, IWeaponAnimInfo> _weaponInfoCache = new ObjectCache<string, IWeaponAnimInfo>(null);

	private readonly Dictionary<string, bool> _isLoadingRequested = new Dictionary<string, bool>();

	public IWeaponAnimInfo GetWeaponAnimInfo(IEntitsWeaponInfo weaponInfo)
	{
		IWeaponAnimInfo orNull = _weaponInfoCache.GetOrNull(weaponInfo.Name);
		if (orNull == null)
		{
			BaseAsyncManager.Instance.StartCoRoutine(LoadWeaponAnimInfo(weaponInfo));
		}
		return orNull;
	}

	public bool Exists(IEntitsWeaponInfo weaponInfo)
	{
		return _weaponInfoCache.GetOrNull(weaponInfo.Name) != null;
	}

	public void Add(IEntitsWeaponInfo weaponInfo, IWeaponAnimInfo animInfo)
	{
		_weaponInfoCache.Add(weaponInfo.Name, animInfo);
	}

	public IEnumerator LoadWeaponAnimInfo(IEntitsWeaponInfo weaponInfo)
	{
		if (!_isLoadingRequested.ContainsKey(weaponInfo.Name))
		{
			_isLoadingRequested[weaponInfo.Name] = true;
			AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
			yield return loader.LoadAsync(weaponInfo.AnimConfigBundleName, weaponInfo.ViewAnimConfigAssetName);
			TextAsset result = loader.Result;
			if (result != null)
			{
				string text = result.text;
				LoadWeaponAnimInfo(weaponInfo, text);
			}
		}
		else
		{
			yield return null;
		}
	}

	public void LoadWeaponAnimInfo(IEntitsWeaponInfo weaponInfo, string data)
	{
		IWeaponAnimInfo value = WeaponAnimationData.CreateViewAnimationArray(weaponInfo, data);
		_weaponInfoCache.Add(weaponInfo.Name, value);
	}
}
