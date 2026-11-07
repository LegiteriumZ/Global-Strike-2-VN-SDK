using Assets.Sources.Constant;
using Assets.Sources.Utils.PlayerAnim;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class BlackLightCrossBowReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	private int RpgFlag = -1;

	private int ReloadStep;

	private int ReloadStepTime;

	public BlackLightCrossBowReloadPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void SetReloadAnim(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (currentWeapon == null)
		{
			return;
		}
		if (RpgFlag == -1)
		{
			RpgFlag = (RuleUtilty.IsRpg(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType) ? 1 : 0);
			if (RpgFlag == 0)
			{
				PlayerAnimationUtility.SetViewAnimation(player, 36);
				int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 36);
				currentWeapon.attack.NextSecondaryAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
				currentWeapon.attack.NextAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
			}
		}
		if (RpgFlag == 0)
		{
			if (ReloadStep == 1 && player.clientTime.ClientTime > ReloadStepTime)
			{
				ReloadStep = 2;
				ReloadStepTime = player.clientTime.ClientTime + PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 17);
				PlayerAnimationUtility.SetTorseAnimation(player, 17);
			}
			if (ReloadStep == 2 && player.clientTime.ClientTime > ReloadStepTime)
			{
				ReloadStep = 0;
				PlayerAnimationUtility.SetTorseAnimation(player, 36);
			}
		}
	}
}
