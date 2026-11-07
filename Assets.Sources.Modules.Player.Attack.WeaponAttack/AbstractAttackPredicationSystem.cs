using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using JetBrains.Annotations;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class AbstractAttackPredicationSystem : IPredicateSystem
{
	[CanBeNull]
	protected readonly List<IFrameCmdAction> FrameActions;

	[CanBeNull]
	protected readonly List<IIdleCmdAction> IdleActions;

	[CanBeNull]
	protected readonly List<ILeftCmdAction> LeftActions;

	[CanBeNull]
	protected readonly List<IRightCmdAction> RightActions;

	[CanBeNull]
	protected readonly WeaponContext WeaponContext;

	public const float ShotDistanceRate = 1.5f;

	public AbstractAttackPredicationSystem(Contexts contexts)
	{
		WeaponContext = contexts.weapon;
		IdleActions = new List<IIdleCmdAction>();
		LeftActions = new List<ILeftCmdAction>();
		RightActions = new List<IRightCmdAction>();
		FrameActions = new List<IFrameCmdAction>();
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		WeaponEntity currentWeaponEntity = WeaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		int clientTime = player.clientTime.ClientTime;
		if (cmd.IsAttackOn)
		{
			foreach (ILeftCmdAction leftAction in LeftActions)
			{
				CommonWeaponArg arg = new CommonWeaponArg
				{
					Player = player,
					Cmd = cmd,
					CurrentWeapon = currentWeaponEntity,
					ClientTime = clientTime,
					Contexts = Contexts.sharedInstance
				};
				if (!leftAction.Action(ref arg))
				{
					break;
				}
			}
		}
		if (cmd.IsSecondaryAttackOn)
		{
			foreach (IRightCmdAction rightAction in RightActions)
			{
				CommonWeaponArg arg2 = new CommonWeaponArg
				{
					Player = player,
					Cmd = cmd,
					CurrentWeapon = currentWeaponEntity,
					ClientTime = clientTime,
					Contexts = Contexts.sharedInstance
				};
				if (!rightAction.Action(ref arg2))
				{
					break;
				}
			}
		}
		if (!cmd.IsAttackOn && !cmd.IsSecondaryAttackOn)
		{
			foreach (IIdleCmdAction idleAction in IdleActions)
			{
				CommonWeaponArg arg3 = new CommonWeaponArg
				{
					Player = player,
					Cmd = cmd,
					CurrentWeapon = currentWeaponEntity,
					ClientTime = clientTime,
					Contexts = Contexts.sharedInstance
				};
				if (!idleAction.Action(ref arg3))
				{
					break;
				}
			}
		}
		foreach (IFrameCmdAction frameAction in FrameActions)
		{
			CommonWeaponArg arg4 = new CommonWeaponArg
			{
				Player = player,
				Cmd = cmd,
				CurrentWeapon = currentWeaponEntity,
				ClientTime = clientTime,
				Contexts = Contexts.sharedInstance
			};
			if (!frameAction.Action(ref arg4))
			{
				break;
			}
		}
	}
}
