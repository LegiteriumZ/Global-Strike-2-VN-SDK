using weapon.predicateSystem.implementSeparately;
using weapon.utils;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class Logger : ILogger
{
	public static ILogger Instance = new Logger();

	private IWeaponPropertiesAdapter _currentWeapon;

	public void Info(string data, params object[] logArgs)
	{
	}

	public string FormatString(object Xbject)
	{
		return "";
	}

	public string Vector3ToString(Vector3 vec)
	{
		return $"[x: {vec.x:f4}] [y: {vec.y:f4}] [z: {vec.z:f4}]";
	}

	public IWeaponPropertiesAdapter GetCurrentWeapon()
	{
		return _currentWeapon;
	}

	public void SetCurrentWeapon(IWeaponPropertiesAdapter weapon)
	{
		_currentWeapon = weapon;
	}
}
