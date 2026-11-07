using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class BladeShield_gMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (player.viewAnim.Equals(64) || player.viewAnim.Equals(63))
		{
			return 539;
		}
		return 635;
	}

	public void Parse(string param)
	{
	}
}
