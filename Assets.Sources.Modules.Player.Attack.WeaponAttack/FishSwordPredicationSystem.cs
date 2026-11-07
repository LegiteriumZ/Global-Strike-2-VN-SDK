using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class FishSwordPredicationSystem : AbstractAttackPredicationSystem
{
	internal class FishSwordLeftAction : KnifeLeftAction
	{
		public FishSwordLeftAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override int GetDelayTime(ref CommonWeaponArg arg)
		{
			if (arg.Player.viewAnim.Equals(31))
			{
				return GetDelayAttackSlashTime(ref arg);
			}
			if (arg.Player.viewAnim.Equals(20) || arg.Player.viewAnim.Equals(28))
			{
				return GetDelayAttackStabTime(ref arg);
			}
			if (arg.Player.viewAnim.Equals(29))
			{
				if (GetDelayAttackSlashTime2(ref arg) > 0)
				{
					return GetDelayAttackSlashTime2(ref arg);
				}
				return GetDelayAttackSlashTime(ref arg);
			}
			return 0;
		}
	}

	internal class FishSwordRightActions : KnifeRightAction
	{
		public FishSwordRightActions(Contexts contexts)
			: base(contexts)
		{
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, (arg.CurrentWeapon.basicInfo.Data.Power != 0) ? 28 : 20);
			return 0;
		}

		protected override int GetDelayTime(ref CommonWeaponArg arg)
		{
			if (arg.Player.viewAnim.Equals(31))
			{
				return GetDelayAttackSlashTime(ref arg);
			}
			if (arg.Player.viewAnim.Equals(20) || arg.Player.viewAnim.Equals(28))
			{
				return GetDelayAttackStabTime(ref arg);
			}
			if (arg.Player.viewAnim.Equals(29))
			{
				if (GetDelayAttackSlashTime2(ref arg) > 0)
				{
					return GetDelayAttackSlashTime2(ref arg);
				}
				return GetDelayAttackSlashTime(ref arg);
			}
			return 0;
		}
	}

	public FishSwordPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new FishSwordLeftAction(contexts));
		RightActions.Add(new FishSwordRightActions(contexts));
	}
}
