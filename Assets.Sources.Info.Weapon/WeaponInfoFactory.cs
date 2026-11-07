using System.Collections.Generic;
using Assets.Sources.CsvLoader;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using SSJJAnim.Weapon;
using SSJJBase.Cache;
using SSJJBase.Logger;
using SSJJBase.Manager;

namespace Assets.Sources.Info.Weapon;

public class WeaponInfoFactory
{
	private class WeaponInfoCacheCacheFactory : ICacheObjectFactory<string, IWeaponInfo>
	{
		public IWeaponInfo CreateObject(string name)
		{
			this.LogErrorFormat("WeaponInfo not exist in csv file {0}", name);
			return new RifleWeaponInfo("ak47", "Rifle", "Rifle", isSharedPredication: false);
		}
	}

	public static WeaponInfoFactory Instance = new WeaponInfoFactory();

	private readonly ObjectCache<string, IWeaponInfo> _weaponInfoCache = new ObjectCache<string, IWeaponInfo>(new WeaponInfoCacheCacheFactory());

	public IWeaponInfo GetWeaponInfo(string name)
	{
		IWeaponInfo weaponInfo = _weaponInfoCache.GetOrNull(name);
		if (weaponInfo == null)
		{
			weaponInfo = BattleSingletonInstance<WeaponInfoCache>.Instance.LoadWeaponData(name);
		}
		return weaponInfo;
	}

	public void Add(IWeaponInfo weaponInfo)
	{
		_weaponInfoCache.Add(weaponInfo.Name, weaponInfo);
	}

	public Dictionary<string, IWeaponInfo>.ValueCollection GetAllWeaponInfos()
	{
		BattleSingletonInstance<WeaponInfoCache>.Instance.LoadAllWeapon();
		return _weaponInfoCache.Values();
	}
}
