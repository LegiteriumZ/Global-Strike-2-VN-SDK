using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class M249RocketPredicationSystem : AbstractAttackPredicationSystem
{
	private class M249RocketLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public M249RocketLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(FireUtility.LeftFireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(SetQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		private static int SetQkhhAfterFire(ref CommonWeaponArg arg)
		{
			if (arg.Player.hasFirstPersonUnityObjects && !arg.Player.fov.IsZoom() && !arg.Cmd.PredicatedOnce)
			{
				arg.Player.firstPersonUnityObjects.RightFires[0].Fire(arg.CurrentWeapon.special.SpecialMode);
			}
			return 0;
		}
	}

	private class M249RocketRightAction : IRightCmdAction, ICmdAction
	{
		public M249RocketRightAction(Contexts contexts)
		{
		}

		bool ICmdAction.Action(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > (float)arg.ClientTime || arg.CurrentWeapon.power.Power < 200)
			{
				return false;
			}
			arg.CurrentWeapon.special.SpecialMode = true;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + 1399;
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + 1399;
			return true;
		}
	}

	private class M249RocketFrameAction : IFrameCmdAction, ICmdAction
	{
		private int _rocketNum = 6;

		public M249RocketFrameAction(Contexts contexts)
		{
		}

		bool ICmdAction.Action(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > (float)arg.ClientTime)
				{
					if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer - (float)arg.ClientTime < (float)(_rocketNum * 200))
					{
						PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
						PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
						FireUtility.PlaySecFireSound(ref arg);
						FireUtility.RightFireQkhhAfterFire(ref arg);
						_rocketNum--;
					}
				}
				else
				{
					arg.CurrentWeapon.special.SpecialMode = false;
					_rocketNum = 6;
				}
			}
			return false;
		}
	}

	public M249RocketPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new M249RocketLeftAction(contexts));
		RightActions.Add(new M249RocketRightAction(contexts));
		FrameActions.Add(new M249RocketFrameAction(contexts));
	}
}
