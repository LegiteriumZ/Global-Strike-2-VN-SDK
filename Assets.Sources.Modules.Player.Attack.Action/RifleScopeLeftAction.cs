using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class RifleScopeLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public RifleScopeLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(RifleScopeSetNextAttack);
		AddFire(OnFire);
		AddFire(LeftFireSetAnim);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	protected virtual int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		return FireUtility.LeftFireSetAnim(ref arg);
	}

	public int RifleScopeSetNextAttack(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info is IRifleScppeWeaponInfo)
		{
			if (arg.Player.fov.IsZoom())
			{
				arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + (arg.CurrentWeapon.basicInfo.Info as IRifleScppeWeaponInfo).FovAttackInterval);
			}
			else
			{
				arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval);
			}
		}
		return 0;
	}
}
