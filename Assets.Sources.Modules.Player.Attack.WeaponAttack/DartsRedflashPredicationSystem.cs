using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DartsRedflashPredicationSystem : AbstractAttackPredicationSystem
{
	internal class DartsRedflashFrameAction : IFrameCmdAction, ICmdAction
	{
		public DartsRedflashFrameAction(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (!arg.Cmd.IsShowGun)
			{
				return false;
			}
			switch (arg.CurrentWeapon.special.EffectLevel)
			{
			case 1:
				if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44))
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
				}
				break;
			case 2:
				if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 117))
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 117);
				}
				break;
			}
			return true;
		}
	}

	public DartsRedflashPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new DartsRedflashLeftAction(contexts));
		RightActions.Add(new DartsRedflashRightAction(contexts));
		FrameActions.Add(new DartsRedflashFrameAction(contexts));
	}
}
