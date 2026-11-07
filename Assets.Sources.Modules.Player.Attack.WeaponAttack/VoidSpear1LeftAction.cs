using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class VoidSpear1LeftAction : KnifeLeftAction
{
	public VoidSpear1LeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
		float num = ((arg.CurrentWeapon.clip.CarryClip2 >= 0) ? 1.2f : 1f);
		arg.Player.viewAnim.RightSpeed = num;
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.SlashSlashTime / num);
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.SlashStabTime / num);
		return 0;
	}

	protected override int SetOtherFireAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info.HasOtherFire && !arg.CurrentWeapon.hasDelayAttack)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				if (arg.Player.viewAnim.Equals(237))
				{
					if (PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 237) - arg.Player.viewAnim.RemainTime < 50)
					{
						arg.CurrentWeapon.basicInfo.Data.Kill = 2;
						return 0;
					}
				}
				else if (arg.Player.viewAnim.Equals(235) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 235) - arg.Player.viewAnim.RemainTime < 50)
				{
					arg.CurrentWeapon.basicInfo.Data.Kill = 1;
					return 0;
				}
			}
			else if (arg.Player.viewAnim.Equals(30) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 30) - arg.Player.viewAnim.RemainTime < 50)
			{
				arg.CurrentWeapon.basicInfo.Data.Kill = 1;
				return 0;
			}
		}
		return -1;
	}

	protected override int ResetMode(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.basicInfo.Data.Kill = 0;
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		WeaponUtility.SetDelayAttackSlashTime(ref arg, 200);
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 2)
			{
				WeaponUtility.SetDelayAttackSlashTime(ref arg, 600);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 238);
			}
			else if (arg.CurrentWeapon.basicInfo.Data.Kill == 1)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 236);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 234);
			}
		}
		else
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 1)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 31);
			}
		}
		return 0;
	}
}
