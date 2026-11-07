using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Utils.PlayerAnim;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class BowBurnMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int Speed;

	internal int SpecialSpeed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (PlayerAnimationUtility.IsViewAnimEqual(player, 25) || PlayerAnimationUtility.IsViewAnimEqual(player, 24) || PlayerAnimationUtility.IsViewAnimEqual(player, 104))
		{
			return SpecialSpeed;
		}
		return Speed;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		SpecialSpeed = restlts[0];
		Speed = restlts[1];
	}
}
