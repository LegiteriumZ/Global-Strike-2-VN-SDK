using Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

namespace Assets.Sources.Utils;

public class WeaponPredicationUtility
{
	public static CommonWeaponArgs CommonWeaponArgs;

	public static void Init()
	{
		CommonWeaponArgs = new CommonWeaponArgs
		{
			CmdPropertiesAdapter = new CmdPropertiesAdapter(),
			WeaponPropertiesAdapter = new WeaponPropertiesAdapter(),
			PlayerPropertiesAdapter = new PlayerEntity(),
			ContextInfo = ContextInfo.Instance,
			SharedUtils = SharedUtils.Instance
		};
	}
}
