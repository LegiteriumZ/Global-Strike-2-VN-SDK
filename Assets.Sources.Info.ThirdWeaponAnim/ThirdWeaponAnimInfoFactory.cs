using SSJJBase.Cache;

namespace Assets.Sources.Info.ThirdWeaponAnim;

public class ThirdWeaponAnimInfoFactory
{
	public static ThirdWeaponAnimInfoFactory Instance = new ThirdWeaponAnimInfoFactory();

	private readonly ObjectCache<string, IThirdWeaponAnimInfo> _cache = new ObjectCache<string, IThirdWeaponAnimInfo>(null);

	public IThirdWeaponAnimInfo GetThirdWeaponAnimInfo(string weaponName)
	{
		return _cache.GetOrNull(weaponName);
	}

	public void AddCareerAnimInfo(string weaponName, IThirdWeaponAnimInfo info)
	{
		if (_cache.GetOrNull(weaponName) == null)
		{
			_cache.Add(weaponName, info);
		}
	}
}
