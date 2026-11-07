using Assets.Sources.Utils.PlayerAnim;
using weapon.predicateSystem.implementSeparately;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class AnimUtil : IAnimUtil
{
	public static IAnimUtil Instance = new AnimUtil();

	public void ForceViewAnim(IPlayerPropertiesAdapter player, int anim)
	{
		PlayerAnimationUtility.SetViewAnimation(player as PlayerEntity, anim);
	}

	public void ForceRightViewAnim(IPlayerPropertiesAdapter player, int anim)
	{
		PlayerAnimationUtility.SetViewAnimation(player as PlayerEntity, anim);
	}

	public void ForceLeftViewAnim(IPlayerPropertiesAdapter player, int anim)
	{
		PlayerAnimationUtility.SetLeftViewAnimation(player as PlayerEntity, anim);
	}

	public void ForceTorsoAnim(IPlayerPropertiesAdapter player, int anim)
	{
		PlayerAnimationUtility.SetTorseAnimation(player as PlayerEntity, anim);
	}

	public void ForceLegAnim(IPlayerPropertiesAdapter player, int anim)
	{
		PlayerAnimationUtility.SetLegsAnimation(player as PlayerEntity, anim);
	}

	public int GetViewAnimDuration(IPlayerPropertiesAdapter player, int viewAnimId)
	{
		return PlayerAnimationUtility.GetViewAnimDuration((player as PlayerEntity).currentWeapon.WeaponInfo, viewAnimId);
	}

	public int GetTorsoAnimDuration(IPlayerPropertiesAdapter player, int legAnimId)
	{
		return 0;
	}

	public int GetLegAnimDuration(IPlayerPropertiesAdapter player, int legAnimId)
	{
		return PlayerAnimationUtility.GetLegAnimDuration(player as PlayerEntity, legAnimId);
	}
}
