using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class Ak47UniqueMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int normal;

	internal int special;

	private readonly int G18_MOVE_FLAG = 512;

	private readonly int AK47_MOVE_FLAG = 2;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (isMoveSpeedActive(currentWeapon))
		{
			return special;
		}
		return normal;
	}

	private bool isMoveSpeedActive(WeaponEntity currentWeapon)
	{
		if ((currentWeapon.special.EffectLevel & G18_MOVE_FLAG) <= 0)
		{
			return (currentWeapon.special.EffectLevel & AK47_MOVE_FLAG) > 0;
		}
		return true;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		normal = restlts[0];
		special = restlts[1];
	}
}
