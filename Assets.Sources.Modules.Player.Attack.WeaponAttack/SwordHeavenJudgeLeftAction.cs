using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SwordHeavenJudgeLeftAction : KnifeLeftAction
{
	public SwordHeavenJudgeLeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode || (arg.CurrentWeapon.special.EffectLevel & 1) > 0)
		{
			return false;
		}
		return base.CanFire(ref arg);
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		_ = arg.CurrentWeapon.basicInfo.Info;
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		arg.Player.viewAnim.RightSpeed = ((arg.CurrentWeapon.power.Power2 != 0) ? 1.2f : 1f);
		if (!arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			int num = 0;
			if (arg.CurrentWeapon.basicInfo.Data.NextSkillTimer == 2)
			{
				WeaponUtility.SetDelayAttackSlashTime(ref arg, 300);
				num = 172;
			}
			else if (arg.CurrentWeapon.basicInfo.Data.NextSkillTimer == 1)
			{
				WeaponUtility.SetDelayAttackSlashTime(ref arg, 400);
				num = 170;
			}
			else
			{
				WeaponUtility.SetDelayAttackSlashTime(ref arg, 400);
				num = 31;
			}
			PlayerAnimationUtility.SetViewAnimation(arg.Player, num);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, num);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration + 200;
			arg.CurrentWeapon.basicInfo.Data.NextSkillTimer = 0L;
		}
		return 0;
	}

	protected override int SetOtherFireAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info.HasOtherFire && !arg.CurrentWeapon.hasDelayAttack)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 30) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 30) - arg.Player.viewAnim.RemainTime < 50)
			{
				arg.CurrentWeapon.basicInfo.Data.NextSkillTimer = 1L;
				return 0;
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 169) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 169) - arg.Player.viewAnim.RemainTime < 50)
			{
				arg.CurrentWeapon.basicInfo.Data.NextSkillTimer = 2L;
				return 0;
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 171) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 171) - arg.Player.viewAnim.RemainTime < 50)
			{
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + 350;
				return -1;
			}
		}
		return -1;
	}
}
