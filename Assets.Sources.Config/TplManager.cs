using System.Collections.Generic;

namespace Assets.Sources.Config;

public class TplManager
{
	private static TplManager _instance = new TplManager();

	private Dictionary<string, TplWeaponResource> _weaponResourceDict;

	public GameBootConfig GameBootConfig;

	public static TplManager Instance => _instance;

	public TplWeaponResource GetWeaponResourceInfoByName(string weaponName)
	{
		if (_weaponResourceDict == null)
		{
			_weaponResourceDict = new Dictionary<string, TplWeaponResource>();
			foreach (KeyValuePair<int, TplWeaponResource> item in TplWeaponResourceLoader.LoadWeaponResourceInfoMap())
			{
				_weaponResourceDict.Add(item.Value.CodeName, item.Value);
			}
		}
		_weaponResourceDict.TryGetValue(weaponName, out var value);
		return value;
	}

	public GameBootConfig GetBootConfig()
	{
		return GameBootConfig ?? (GameBootConfig = BootConfigLoader.LoadBootConfig());
	}
}
