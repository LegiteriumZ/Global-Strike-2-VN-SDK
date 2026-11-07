using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ShowGunGrenadePredicationSystem : AbstractAttackPredicationSystem
{
	private class ColaGrenadeFrameAction : IFrameCmdAction, ICmdAction
	{
		private readonly Contexts _contexts;

		public ColaGrenadeFrameAction(Contexts contexts)
		{
			_contexts = contexts;
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsShowGun && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 21) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 22) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 135) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 136) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 28))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
				return true;
			}
			return false;
		}
	}

	public ShowGunGrenadePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		FrameActions.Add(new ColaGrenadeFrameAction(contexts));
	}
}
