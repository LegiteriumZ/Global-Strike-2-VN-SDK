using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class HanSwordKnifeRightAction : KnifeRightAction
{
	public static int SKILL_FA_GUANG = 0;

	public static int SKILL_NORMAL_EFFECT = 1;

	public static int SKILL_EFFECT = 2;

	public HanSwordKnifeRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (isCanSuperAttack(ref arg))
		{
			SuperAttack(ref arg);
		}
		else
		{
			base.Action(ref arg);
		}
		return true;
	}

	public static bool IsSpecialEffectByShifNumber(WeaponEntity currentWeapon, int shifNumber)
	{
		return (currentWeapon.basicInfo.Data.EffectLevel & (1 << shifNumber)) > 0;
	}

	private bool isCanSuperAttack(ref CommonWeaponArg arg)
	{
		if (!IsSpecialEffectByShifNumber(arg.CurrentWeapon, SKILL_FA_GUANG))
		{
			return false;
		}
		if (!arg.Cmd.IsAttackOn && !arg.Cmd.IsSecondaryAttackOn)
		{
			return false;
		}
		if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer <= (float)arg.ClientTime && arg.CurrentWeapon.attack.NextAttackTimer <= (float)arg.ClientTime)
		{
			return true;
		}
		return false;
	}

	private void SuperAttack(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 199);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 199);
		int num = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = num;
		arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		OnFireInDelayTime(ref arg, 420);
	}

	protected override int HitPlayer(ref HitPlayerArgs arg)
	{
		if (IsSpecialEffectByShifNumber(arg.currentWeapon, SKILL_FA_GUANG))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.player, 200);
		}
		return base.HitPlayer(ref arg);
	}
}
