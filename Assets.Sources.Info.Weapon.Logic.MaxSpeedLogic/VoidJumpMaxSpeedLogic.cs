using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

public class VoidJumpMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	public static readonly int HIDE1 = 32;

	public static readonly int HAS_ENEMY = 64;

	internal int NormalSpeed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (!isHasEnemy(currentWeapon))
		{
			return NormalSpeed;
		}
		return NormalSpeed + 30;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 1);
		NormalSpeed = restlts[0];
	}

	private bool isHide1(WeaponEntity currentWeapon)
	{
		return (currentWeapon.special.EffectLevel & HIDE1) > 0;
	}

	private bool isHasEnemy(WeaponEntity currentWeapon)
	{
		return (currentWeapon.special.EffectLevel & HAS_ENEMY) > 0;
	}
}
