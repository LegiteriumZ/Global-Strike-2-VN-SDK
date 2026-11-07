using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class GhostTwinsSwitchAction : IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public GhostTwinsSwitchAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (!checkCanChangeMode())
		{
			return false;
		}
		if (arg.Cmd.IsShowGun && arg.CurrentWeapon.attack.NextAttackTimer < (float)arg.ClientTime)
		{
			int animId = (arg.CurrentWeapon.special.SpecialMode ? 37 : 36);
			arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
			PlayerAnimationUtility.SetViewAnimation(arg.Player, animId);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, animId);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		}
		return true;
	}

	private bool checkCanChangeMode()
	{
		int raceType = _contexts.battleRoom.roomData.Data.RaceType;
		int subRaceType = _contexts.battleRoom.roomData.Data.SubRaceType;
		if (9 == raceType || 10 == raceType)
		{
			return false;
		}
		if (4 == raceType)
		{
			if (42 == subRaceType)
			{
				return false;
			}
		}
		else if (5 == raceType)
		{
			if (53 == subRaceType)
			{
				return false;
			}
		}
		else if (36 == raceType)
		{
			return false;
		}
		return true;
	}
}
