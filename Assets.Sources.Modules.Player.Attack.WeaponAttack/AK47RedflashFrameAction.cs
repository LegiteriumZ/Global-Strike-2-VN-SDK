using Assets.Sources.Constant;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AK47RedflashFrameAction : IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public AK47RedflashFrameAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		int raceType = _contexts.battleRoom.roomData.Data.RaceType;
		if (RuleUtilty.IsBioMode(raceType))
		{
			BioModeSecondaryLogic(ref arg);
		}
		else if (!RuleUtilty.IsBlade(raceType))
		{
			NoBioModeSecondaryLogic(ref arg);
		}
		return true;
	}

	private void NoBioModeSecondaryLogic(ref CommonWeaponArg arg)
	{
		if ((float)arg.ClientTime > arg.CurrentWeapon.attack.NextSecondaryAttackTimer && arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo)
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + 1000;
			arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		}
	}

	private void BioModeSecondaryLogic(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsSecondaryAttackOn)
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer += arg.Cmd.FrameInterval;
			arg.CurrentWeapon.power.Power2 = 1;
		}
		else
		{
			CheckSecondaryAttack(ref arg);
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = 0f;
			arg.CurrentWeapon.power.Power2 = 0;
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 65);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 13);
			}
		}
		if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > 500f && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 64);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 63);
		}
	}

	private void CheckSecondaryAttack(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.attack.NextSecondaryAttackTimer < 1f) && !(arg.CurrentWeapon.attack.NextSecondaryAttackTimer > 500f) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 20) && arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo knifeWeaponInfo)
		{
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + knifeWeaponInfo.StabSlashTime;
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
		}
	}
}
