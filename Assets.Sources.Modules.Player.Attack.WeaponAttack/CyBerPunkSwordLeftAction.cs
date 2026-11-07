using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class CyBerPunkSwordLeftAction : KnifeLeftAction
{
	internal CyBerPunkSwordLeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		_ = arg.CurrentWeapon.basicInfo.Info;
		float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
		if (arg.CurrentWeapon.special.EffectLevel == 1)
		{
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFire3Sound);
		}
		else
		{
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound);
		}
		return 0;
	}
}
