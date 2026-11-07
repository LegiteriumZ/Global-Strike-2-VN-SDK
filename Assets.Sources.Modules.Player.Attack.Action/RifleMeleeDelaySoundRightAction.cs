using Assets.Sources.Info.Weapon;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class RifleMeleeDelaySoundRightAction : RifleMeleeRightAction
{
	public RifleMeleeDelaySoundRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo rifleMeleeWeaponInfo)
		{
			float shotDistance = rifleMeleeWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			int delayAttackStabTime = rifleMeleeWeaponInfo.DelayAttackStabTime;
			KnifeFireWithSureDelayTime(ref arg, arg.Cmd.Seq, shotDistance, delayAttackStabTime, FireUtility.PlaySecFireSound);
		}
		return 0;
	}
}
