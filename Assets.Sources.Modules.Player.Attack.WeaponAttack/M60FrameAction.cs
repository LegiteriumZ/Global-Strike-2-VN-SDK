using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class M60FrameAction : IFrameCmdAction, ICmdAction
{
	public bool Action(ref CommonWeaponArg arg)
	{
		calViewHeight(arg.Player, arg.CurrentWeapon);
		calOverload(arg.Player, arg.CurrentWeapon);
		return true;
	}

	private void calOverload(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (currentWeapon.special.Level > 0 && currentWeapon.attack.NextSecondaryAttackTimer < (float)player.clientTime.ClientTime)
		{
			int num = (int)(((float)player.clientTime.ClientTime - currentWeapon.attack.NextSecondaryAttackTimer) / (float)M60PredicationSystem.BACK_LEVEL_TIME) + 1;
			if (num == 0)
			{
				num = 1;
			}
			currentWeapon.special.Level -= num;
			currentWeapon.attack.NextSecondaryAttackTimer = player.clientTime.ClientTime + M60PredicationSystem.BACK_LEVEL_TIME;
			if (currentWeapon.special.Level < 0)
			{
				currentWeapon.special.Level = 0;
			}
		}
	}

	private void calViewHeight(PlayerEntity player, WeaponEntity currentWeapon)
	{
		int stateId = player.viewAnim.ViewAnimInfo.StateId;
		if (stateId == 36 || stateId == 37)
		{
			int num = ViewHeight.GetNormalViewHeight(player.GetCareer()) - PlayerConf.CreepHeight;
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, stateId);
			float num2 = (currentWeapon.attack.NextAttackTimer - (float)player.clientTime.ClientTime) / (float)viewAnimDuration;
			if (num2 > 1f || num2 < 0f)
			{
				num2 = 0f;
			}
			if (stateId == 37)
			{
				player.move.ViewHeightBase = (float)PlayerConf.CreepHeight + (float)num * (1f - num2);
			}
			else
			{
				player.move.ViewHeightBase = (float)PlayerConf.CreepHeight + (float)num * num2;
			}
		}
	}
}
