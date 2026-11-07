using Assets.Sources.Constant;
using Assets.Sources.Free.Data;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PhotonDeformationPredicationSystem : AbstractAttackPredicationSystem
{
	internal class PhotonDeformationRightAction : IRightCmdAction, ICmdAction
	{
		public PhotonDeformationRightAction(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (CheckGameRule(GameModelLocator.GetInstance().GameModel.RoomData.RaceType) && CanChangeAnim(arg.Player))
			{
				if (arg.CurrentWeapon.power.Power < arg.CurrentWeapon.power.RpgMaxPower)
				{
					return false;
				}
				NormalToSpecialModel(ref arg);
			}
			return true;
		}

		private void NormalToSpecialModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 36);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.special.SpecialMode = true;
		}
	}

	public PhotonDeformationPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new RifleLeftAction(contexts));
		RightActions.Add(new PhotonDeformationRightAction(contexts));
	}

	public static bool CheckGameRule(int raceType)
	{
		return RuleUtilty.IsGeneralPve(raceType);
	}

	public static bool CanChangeAnim(PlayerEntity player)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(player, 17) && !PlayerAnimationUtility.IsViewAnimEqual(player, 44))
		{
			return !PlayerAnimationUtility.IsViewAnimEqual(player, 117);
		}
		return false;
	}
}
