using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ShieldCannonRightAction : AbstractFireAction, IRightCmdAction, ICmdAction
{
	public ShieldCannonRightAction(Contexts contexts)
		: base(contexts)
	{
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(RightFireSetAnim);
		AddFire(FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.Power > 0)
		{
			return (float)arg.ClientTime > arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		}
		return false;
	}

	public int RightFireSetAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 28);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 28);
		return 0;
	}

	public int FireNextAttack(ref CommonWeaponArg arg)
	{
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 28);
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + viewAnimDuration);
		return 0;
	}
}
