using System;
using Assets.Sources.Components.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using math;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class MikadukiSwordFrameAction : IFrameCmdAction, ICmdAction
{
	private static int[] config = new int[5] { 200, 300, 400, 50, -25 };

	public MikadukiSwordFrameAction(Contexts contexts)
	{
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		int index = 2;
		if (!(arg.CurrentWeapon.GetComponent(index) is AttachComponent { Data: not null } attachComponent) || !(attachComponent.Data is MikadukiSwordBaseAttach))
		{
			return false;
		}
		MikadukiSwordBaseAttach mikadukiSwordBaseAttach = attachComponent.Data as MikadukiSwordBaseAttach;
		config[3] = mikadukiSwordBaseAttach.pardon;
		config[4] = mikadukiSwordBaseAttach.offset;
		if (!arg.CurrentWeapon.special.SpecialMode)
		{
			resetParm(arg.CurrentWeapon);
			WeaponUtility.SetDelayAttackSlashTime(ref arg, 300);
		}
		else
		{
			WeaponUtility.SetDelayAttackSlashTime(ref arg, 100);
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 13) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 14))
		{
			arg.CurrentWeapon.special.SpecialMode = false;
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 69) && arg.Player.viewAnim.RemainTime < 450 && arg.Player.viewAnim.RemainTime > 400)
		{
			enterSpecialStep(ref arg);
		}
		if (arg.Cmd.IsShowGun)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17) && !arg.CurrentWeapon.special.SpecialMode)
			{
				arg.CurrentWeapon.special.SpecialMode = true;
				NormalToSpecialModel(ref arg);
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 69) && arg.Player.viewAnim.RemainTime < 400 && arg.Player.viewAnim.RemainTime > 0)
			{
				sucess(ref arg);
			}
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 70) && arg.Player.viewAnim.RemainTime < 70)
		{
			SpecialToNormalModel(ref arg);
			arg.CurrentWeapon.special.SpecialMode = false;
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 70))
		{
			resetParm(arg.CurrentWeapon);
		}
		return true;
	}

	private void sucess(ref CommonWeaponArg arg)
	{
		if (Math.Abs(arg.ClientTime - arg.CurrentWeapon.special.Level + config[4]) > config[3] && !getDoublePctMustSucceed(arg.CurrentWeapon))
		{
			resetParm(arg.CurrentWeapon);
			return;
		}
		resetParm(arg.CurrentWeapon);
		if (!getDoublePctMustSucceed(arg.CurrentWeapon) || !arg.Cmd.IsAttackOn || !arg.Cmd.IsShowGun)
		{
			shouDao(ref arg);
		}
	}

	private void enterSpecialStep(ref CommonWeaponArg arg)
	{
		if (config == null)
		{
			resetParm(arg.CurrentWeapon);
			return;
		}
		arg.CurrentWeapon.special.Level = arg.ClientTime + UniformRandom.RandomInt(arg.Cmd.Seq, config[0], config[1]);
		arg.CurrentWeapon.power.Power2 = arg.ClientTime;
		arg.CurrentWeapon.power.MaxPower2 = arg.ClientTime + config[2];
	}

	private void resetParm(WeaponEntity currentWeapon)
	{
		currentWeapon.power.Power2 = 0;
		currentWeapon.power.MaxPower2 = 0;
		currentWeapon.special.Level = 0;
	}

	private static void shouDao(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 46);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 46);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
	}

	private static void NormalToSpecialModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
	}

	private static void SpecialToNormalModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
	}

	public static bool getDoublePctMustSucceed(WeaponEntity currentWeapon)
	{
		return (currentWeapon.special.EffectLevel & int.MinValue) != 0;
	}

	public static int GetWolfClawDoublePct(WeaponEntity currentWeapon)
	{
		if (currentWeapon.special.Level > currentWeapon.power.Power2 && currentWeapon.special.Level < currentWeapon.power.MaxPower2)
		{
			return (currentWeapon.special.Level - currentWeapon.power.Power2) * 1000 / (currentWeapon.power.MaxPower2 - currentWeapon.power.Power2);
		}
		return 0;
	}

	public static int GetWolfClawDoublePctNow(WeaponEntity currentWeapon, int clientTime)
	{
		if (clientTime > currentWeapon.power.Power2 && clientTime < currentWeapon.power.MaxPower2)
		{
			return (clientTime - currentWeapon.power.Power2) * 1000 / (currentWeapon.power.MaxPower2 - currentWeapon.power.Power2);
		}
		return 0;
	}
}
