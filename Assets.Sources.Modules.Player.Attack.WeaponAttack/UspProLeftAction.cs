using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class UspProLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public UspProLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(M4a1ProLeftAction.LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(M4a1ProLeftAction.PlayFireSound);
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		if (!arg.Cmd.PredicatedOnce)
		{
			GunFire(ref arg, arg.Cmd.Seq, shotDistance);
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (base.CanFire(ref arg))
		{
			return arg.CurrentWeapon.attack.ShotsFired < 1;
		}
		return false;
	}
}
