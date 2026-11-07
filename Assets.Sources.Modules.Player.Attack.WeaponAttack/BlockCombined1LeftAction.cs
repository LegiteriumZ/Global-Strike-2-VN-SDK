using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BlockCombined1LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public BlockCombined1LeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (((uint)arg.Player.GetCurrentWeaponEffectLevel() & (true ? 1u : 0u)) != 0)
		{
			if (WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime))
			{
				FireUtility.FireNextAttack(ref arg);
				FireUtility.PlayFireSound(ref arg);
			}
			return false;
		}
		return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
	}
}
