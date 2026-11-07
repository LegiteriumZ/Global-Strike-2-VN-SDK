using System;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GatlingFrameAction : IFrameCmdAction, ICmdAction
{
	private static readonly int Startunreadytime = 2000;

	public GatlingFrameAction(Contexts contexts)
	{
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.hasAttach && arg.CurrentWeapon.attach.Data is GatlingAttach)
		{
			GatlingAttach gatlingAttach = arg.CurrentWeapon.attach.Data as GatlingAttach;
			if (arg.CurrentWeapon.reload.IsStartReload)
			{
				gatlingAttach.Init();
			}
			else
			{
				switch (gatlingAttach.State)
				{
				case GatlingState.Idle:
					IdelState(arg.Player, arg.Cmd, arg.CurrentWeapon, arg.ClientTime, gatlingAttach);
					break;
				case GatlingState.StartReady:
					StartReadyState(arg.Player, arg.ClientTime, gatlingAttach);
					break;
				case GatlingState.Ready:
					ReadyState(arg.Player, arg.Cmd, arg.CurrentWeapon, arg.ClientTime, gatlingAttach);
					break;
				case GatlingState.StartUnReady:
					StartUnReadyState(arg.Player, arg.Cmd, arg.ClientTime, gatlingAttach);
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}
		return true;
	}

	private static void IdelState(PlayerEntity player, IUserCmd cmd, WeaponEntity currentWeapon, int clientTime, GatlingAttach attach)
	{
		if (cmd.IsAttackOn || currentWeapon.special.SpecialMode)
		{
			attach.EnterState(GatlingState.StartReady);
			attach.StateEndTime = clientTime + PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 25);
			PlayerAnimationUtility.SetViewAnimation(player, 25);
		}
	}

	private static void StartReadyState(PlayerEntity player, int clientTime, GatlingAttach attach)
	{
		if (clientTime >= attach.StateEndTime)
		{
			attach.EnterState(GatlingState.Ready);
			PlayerAnimationUtility.SetViewAnimation(player, 24);
		}
	}

	private static void StartUnReadyState(PlayerEntity player, IUserCmd cmd, int clientTime, GatlingAttach attach)
	{
		if (player.viewAnim.ViewAnimInfo.StateId == 15 && player.viewAnim.RemainTime - cmd.FrameInterval <= 0)
		{
			PlayerAnimationUtility.SetViewAnimation(player, 24);
		}
		if (clientTime >= attach.StateEndTime)
		{
			attach.EnterState(GatlingState.Idle);
			PlayerAnimationUtility.SetViewAnimation(player, 13);
			PlayerAnimationUtility.SetTorseAnimation(player, 13);
		}
	}

	private static void ReadyState(PlayerEntity player, IUserCmd cmd, WeaponEntity currentWeapon, int clientTime, GatlingAttach attach)
	{
		if (player.viewAnim.ViewAnimInfo.StateId == 15 && player.viewAnim.RemainTime - cmd.FrameInterval <= 0)
		{
			PlayerAnimationUtility.SetViewAnimation(player, 24);
		}
		if (cmd.IsAttackOn)
		{
			attach.UnReadyTime = 0;
		}
		else if (attach.UnReadyTime == 0)
		{
			attach.UnReadyTime = clientTime + Startunreadytime;
		}
		else if (clientTime > attach.UnReadyTime && !currentWeapon.special.SpecialMode)
		{
			attach.EnterState(GatlingState.StartUnReady);
			attach.StateEndTime = clientTime + PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 26);
			PlayerAnimationUtility.SetViewAnimation(player, 26);
		}
	}
}
