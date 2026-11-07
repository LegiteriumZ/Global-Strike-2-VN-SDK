using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RifleMeleeSpecialPredicationSystem : AbstractAttackPredicationSystem
{
	internal class RifleMeleeSpecailRightAction : RifleMeleeRightAction
	{
		public RifleMeleeSpecailRightAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.hasSpecial && arg.CurrentWeapon.special.SpecialMode)
			{
				return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
			}
			return false;
		}
	}

	public RifleMeleeSpecialPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new RifleMeleeSpecailRightAction(contexts));
	}
}
