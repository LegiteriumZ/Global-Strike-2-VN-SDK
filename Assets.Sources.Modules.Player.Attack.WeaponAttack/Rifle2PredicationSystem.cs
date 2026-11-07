using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class Rifle2PredicationSystem : AbstractAttackPredicationSystem
{
	private class Rifle2FrameAction : AbstractFrameAction
	{
		public Rifle2FrameAction(Contexts contexts)
			: base(contexts)
		{
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (base.Action(ref arg) && arg.Cmd.IsShowGun && !arg.Player.viewAnim.Equals(44))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
			}
			return true;
		}
	}

	public Rifle2PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new RifleLeftAction(contexts));
		FrameActions.Add(new Rifle2FrameAction(contexts));
	}
}
