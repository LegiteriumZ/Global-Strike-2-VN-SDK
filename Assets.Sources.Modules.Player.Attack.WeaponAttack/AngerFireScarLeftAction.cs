using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AngerFireScarLeftAction : AbstractKnifeFireAction, ILeftCmdAction, ICmdAction
{
	public AngerFireScarLeftAction(Contexts contexts)
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
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + 1000);
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + 1100);
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		if (WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 31);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		bool result = false;
		if (WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime))
		{
			result = true;
		}
		else if ((70 == arg.Player.viewAnim.ViewAnimInfo.StateId || 30 == arg.Player.viewAnim.ViewAnimInfo.StateId) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) - arg.Player.viewAnim.RemainTime < 50)
		{
			result = true;
		}
		return result;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		KnifeFire(ref arg, arg.Cmd.Seq, 180f, FireUtility.PlayFire3Sound);
		return 0;
	}
}
