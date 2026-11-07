using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ArcElectricShotgunFrameAction : AbstractFrameAction
{
	private const int InitailAttackInterval = 320;

	public ArcElectricShotgunFrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsShowGun)
		{
			if ((arg.CurrentWeapon.special.EffectLevel & 1) > 0)
			{
				if (canChangeAnim(ref arg))
				{
					if (!arg.CurrentWeapon.special.SpecialMode)
					{
						arg.CurrentWeapon.basicInfo.Data.Kill = 0;
						arg.CurrentWeapon.power.RpgMaxPower = 0;
						arg.CurrentWeapon.basicInfo.Data.WeaponFlag = 0;
						if (arg.CurrentWeapon.basicInfo.Info.AttackInterval != 320)
						{
							arg.CurrentWeapon.basicInfo.Info.AttackInterval = 320;
						}
						normalToSpecialModel(ref arg);
					}
					else
					{
						specialToNormalModel(ref arg);
					}
				}
			}
			else if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
			}
		}
		if (arg.Cmd.IsAttackOn && !arg.CurrentWeapon.special.SpecialMode && canChangeAnim(ref arg) && (arg.CurrentWeapon.clip.CarryClip > 0 || arg.CurrentWeapon.clip.Clip > 0))
		{
			arg.CurrentWeapon.basicInfo.Data.Kill += arg.Cmd.FrameInterval;
			if (arg.CurrentWeapon.basicInfo.Data.Kill >= 300 + arg.CurrentWeapon.power.RpgMaxPower * 300 && arg.CurrentWeapon.power.RpgMaxPower < 5)
			{
				arg.CurrentWeapon.power.RpgMaxPower++;
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = (int)((double)arg.CurrentWeapon.basicInfo.Info.AttackInterval - 16.0);
			}
		}
		else
		{
			arg.CurrentWeapon.basicInfo.Data.Kill = 0;
			arg.CurrentWeapon.power.RpgMaxPower = 0;
			if (arg.CurrentWeapon.basicInfo.Info.AttackInterval != 320)
			{
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = 320;
			}
		}
		setEndFireAnim(ref arg);
		return true;
	}

	private bool canChangeAnim(ref CommonWeaponArg arg)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 16) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 20))
		{
			return !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 72);
		}
		return false;
	}

	private void normalToSpecialModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.special.SpecialMode = true;
	}

	private void specialToNormalModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.special.SpecialMode = false;
	}

	private void setEndFireAnim(ref CommonWeaponArg arg)
	{
		if (!arg.Cmd.IsAttackOn && arg.CurrentWeapon.special.SpecialMode && PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 148))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 150);
		}
	}
}
