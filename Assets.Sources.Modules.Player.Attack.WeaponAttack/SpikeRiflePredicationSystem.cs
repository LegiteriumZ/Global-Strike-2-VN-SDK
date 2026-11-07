using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SpikeRiflePredicationSystem : AbstractAttackPredicationSystem
{
	internal class SpikeRifleLeftAction : RifleLeftAction
	{
		public SpikeRifleLeftAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 0)
			{
				return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
			}
			return false;
		}
	}

	internal class SpikeRifleMeleeRightAction : RifleMeleeRightAction
	{
		public SpikeRifleMeleeRightAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 0)
			{
				if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo)
				{
					return WeaponUtility.CanSecondaryAttack(ref arg);
				}
				return false;
			}
			return false;
		}
	}

	public SpikeRiflePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new SpikeRifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new SpikeRifleMeleeRightAction(contexts));
	}
}
