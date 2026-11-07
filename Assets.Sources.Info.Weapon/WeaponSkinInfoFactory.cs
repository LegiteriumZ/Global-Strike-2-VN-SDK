using System.Collections.Generic;
using SSJJBase.Cache;
using SSJJBase.Logger;
using SSJJBase.Manager;

namespace Assets.Sources.Info.Weapon;

public class WeaponSkinInfoFactory : BattleSingletonInstance<WeaponSkinInfoFactory>
{
	private class WeaponSkinInfoCacheFactory : ICacheObjectFactory<string, WeaponSkinInfo>
	{
		public WeaponSkinInfo CreateObject(string name)
		{
			this.LogErrorFormat("WeaponInfo not exist in csv file {0}", name);
			return null;
		}
	}

	private readonly ObjectCache<string, WeaponSkinInfo> _weaponInfoCache = new ObjectCache<string, WeaponSkinInfo>(new WeaponSkinInfoCacheFactory());

	public WeaponSkinInfo GetSkinInfo(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		return _weaponInfoCache.GetOrNull(name);
	}

	public void Add(WeaponSkinInfo skinInfo)
	{
		_weaponInfoCache.Add(skinInfo.Name, skinInfo);
	}

	public Dictionary<string, WeaponSkinInfo>.ValueCollection GetAllWeaponSkinInfos()
	{
		return _weaponInfoCache.Values();
	}

	public override void Clear()
	{
		_weaponInfoCache.Clear();
	}
}
