using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class DataCubePredicationSystem : AbstractAttackPredicationSystem
{
	private class DataCubeFrameAction : IFrameCmdAction, ICmdAction
	{
		public DataCubeFrameAction(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsShowGun && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 117))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, arg.CurrentWeapon.basicInfo.Data.SpecialMode ? 117 : 44);
				return true;
			}
			return false;
		}
	}

	public DataCubePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		FrameActions.Add(new DataCubeFrameAction(contexts));
	}
}
