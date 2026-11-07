using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AngerFireScarRightAction : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
{
	public AngerFireScarRightAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(SetAttackAnim);
		AddFire(SetNextAttack);
		AddFire(OnFire);
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId);
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + viewAnimDuration);
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + viewAnimDuration);
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return WeaponUtility.CanSecondaryAttack(ref arg);
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		KnifeFire(ref arg, arg.Cmd.Seq, 160f, null);
		FireUtility.PlaySecFireSound(ref arg);
		return 0;
	}
}
