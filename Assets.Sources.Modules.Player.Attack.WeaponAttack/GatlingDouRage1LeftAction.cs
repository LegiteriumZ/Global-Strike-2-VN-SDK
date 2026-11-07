using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GatlingDouRage1LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	private readonly int[] addAttackSpeed = new int[2] { 50, 75 };

	public GatlingDouRage1LeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireNextAttackInterval);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private int FireNextAttackInterval(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.Kill == 1 || arg.CurrentWeapon.basicInfo.Data.Kill == 2)
		{
			if (arg.CurrentWeapon.basicInfo.Info.AttackInterval == 75)
			{
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = (int)((double)arg.CurrentWeapon.basicInfo.Info.AttackInterval / (1.0 + (double)addAttackSpeed[arg.CurrentWeapon.basicInfo.Data.Kill - 1] * 0.01));
			}
		}
		else if (arg.CurrentWeapon.basicInfo.Info.AttackInterval != 75)
		{
			arg.CurrentWeapon.basicInfo.Info.AttackInterval = 75;
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.hasAttach && arg.CurrentWeapon.attach.Data is GatlingAttach)
		{
			if (base.CanFire(ref arg))
			{
				return (arg.CurrentWeapon.attach.Data as GatlingAttach).State.Equals(GatlingState.Ready);
			}
			return false;
		}
		return false;
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
}
