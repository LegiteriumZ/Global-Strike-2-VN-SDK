using Assets.Sources.Info.CareerAnim;
using Assets.Sources.Utils.Weapon;
using weapon.predicateSystem.implementSeparately;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class SharedUtils : ISharedUtils
{
	public static ISharedUtils Instance = new SharedUtils();

	public string GetModeWeaponAttribute(ICommonWeaponArgs args, string attributeName, string defaultValue)
	{
		HeroWeaponConfig weaponConfig = CareerData.GetWeaponConfig(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType, args.GetCurrentWeapon().GetWeaponName());
		if (weaponConfig != null)
		{
			return weaponConfig.Values[attributeName];
		}
		return defaultValue;
	}

	public IWeaponUtil GetWeaponUtil()
	{
		return WeaponUtil.Instance;
	}

	public ILogger GetLogger()
	{
		return Logger.Instance;
	}

	public IAnimUtil GetAnimUtil()
	{
		return AnimUtil.Instance;
	}

	public IFunctionUtil GetFunctionUtil()
	{
		return FunctionUtil.Instance;
	}
}
