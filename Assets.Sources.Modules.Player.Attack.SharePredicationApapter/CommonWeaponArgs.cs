using weapon.predicateSystem.implementSeparately;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class CommonWeaponArgs : ICommonWeaponArgs
{
	public WeaponPropertiesAdapter WeaponPropertiesAdapter;

	public CmdPropertiesAdapter CmdPropertiesAdapter;

	public IPlayerPropertiesAdapter PlayerPropertiesAdapter;

	public IContextInfo ContextInfo;

	public ISharedUtils SharedUtils;

	public IWeaponPropertiesAdapter GetCurrentWeapon()
	{
		return WeaponPropertiesAdapter;
	}

	public ICmdPropertiesAdapter GetCurrentCmd()
	{
		return CmdPropertiesAdapter;
	}

	public IPlayerPropertiesAdapter GetPlayer()
	{
		return PlayerPropertiesAdapter;
	}

	public IContextInfo GetContext()
	{
		return ContextInfo;
	}

	public ISharedUtils GetUtils()
	{
		return SharedUtils;
	}
}
