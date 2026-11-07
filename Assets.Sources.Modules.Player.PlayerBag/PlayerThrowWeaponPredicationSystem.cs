using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Free.Data;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class PlayerThrowWeaponPredicationSystem : IPredicateSystem
{
	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		PredictCmdOnWeapon(player, cmd);
	}

	private void PredictCmdOnWeapon(PlayerEntity player, IUserCmd cmd)
	{
		if (GameModelLocator.GetInstance().GameModel.RoomData == null || RuleUtilty.IsGeneralPve(GameModelLocator.GetInstance().GameModel.RoomData.RaceType) || RuleUtilty.IsOldPve(GameModelLocator.GetInstance().GameModel.RoomData.RaceType) || GameModelLocator.GetInstance().GameModel.RoomData.RaceType == 126)
		{
			return;
		}
		if (cmd.IsThrowWeaponOn && !cmd.IsSecondaryAttackOn && Contexts.sharedInstance.gameRule.currentRule.Rule.GetLockWeapon())
		{
			if (Contexts.sharedInstance.gameRule.currentRule.Rule.IsLockWeaponTips())
			{
				Contexts.sharedInstance.message.messageRemindData.SetMessage(ScriptLocalization.Get("CurrentCannotThrowWeapon"), 1000);
				NotifyManager.ForceInvoke(38);
			}
		}
		else if (cmd.IsThrowWeaponOn && !cmd.IsSecondaryAttackOn && player.CanChangeWeapon())
		{
			ThrowWeapon(player, cmd);
		}
	}

	private void ThrowWeapon(PlayerEntity player, IUserCmd cmd)
	{
		if (player.currentWeapon.Weapon != 1 && player.currentWeapon.Weapon != 2)
		{
			return;
		}
		for (int i = 1; i <= 3; i++)
		{
			if (i != player.currentWeapon.Weapon && WeaponUtility.GetWeaponAtSlot(player, player.basicInfo.Current.CurrentBagId, i, player.currentWeapon.Index) != null)
			{
				cmd.Weapon = i;
				break;
			}
		}
	}
}
