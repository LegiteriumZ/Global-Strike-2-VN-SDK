using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class P28CannonLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public P28CannonLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(SetNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.DebugAfterFire);
	}

	private int SetNextAttack(ref CommonWeaponArg arg)
	{
		FireUtility.RifleFireIncShotsFired(ref arg);
		FireUtility.PlayFireSound(ref arg);
		FireUtility.FireNextAttack(ref arg);
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.ShotsFired >= 1)
		{
			return false;
		}
		return base.CanFire(ref arg);
	}
}
