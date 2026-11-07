using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Player;
using Assets.Sources.Components.Player.Anims;
using Assets.Sources.Framework;
using Assets.Sources.Info.WeaponAnim;
using Assets.Sources.Utils.PlayerAnim;
using SSJJAnim.AnimState;
using SSJJAnim.WeaponAnim;
using SSJJUserCmd;
using share.constant;

namespace Assets.Sources.Modules.Player.Anim.FirstPerson;

public class PlayerViewPredictionSystem : IPredicateSystem
{
	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		if (PlayerCareerUtil.IsTPS(myPlayer.GetCareer()))
		{
			return;
		}
		ViewAnimComponent viewAnim = myPlayer.viewAnim;
		CurrentWeaponComponent currentWeapon = myPlayer.currentWeapon;
		viewAnim.RightCurrentTime += (int)((float)cmd.FrameInterval * viewAnim.RightSpeed);
		viewAnim.LeftCurrentTime += (int)((float)cmd.FrameInterval * viewAnim.LeftSpeed);
		if (viewAnim.RemainTime > 0)
		{
			viewAnim.RemainTime -= (int)((float)cmd.FrameInterval * viewAnim.RightSpeed);
			if (viewAnim.RemainTime < 0)
			{
				viewAnim.RemainTime = 0;
			}
		}
		if (viewAnim.RemainTime == 0)
		{
			Sequencing(myPlayer, viewAnim, currentWeapon);
		}
		if (viewAnim.LeftRemainTime > 0)
		{
			viewAnim.LeftRemainTime -= (int)((float)cmd.FrameInterval * viewAnim.LeftSpeed);
			if (viewAnim.LeftRemainTime < 0)
			{
				viewAnim.LeftRemainTime = 0;
			}
		}
		if (viewAnim.LeftRemainTime == 0)
		{
			SequencingLeft(myPlayer, viewAnim, currentWeapon);
		}
	}

	private void Sequencing(PlayerEntity myPlayer, ViewAnimComponent anim, CurrentWeaponComponent weapon)
	{
		if (weapon == null || weapon.WeaponInfo == null)
		{
			return;
		}
		IWeaponAnimInfo weaponAnimInfo = WeaponAnimInfoFactory.Instance.GetWeaponAnimInfo(weapon.WeaponInfo);
		if (weaponAnimInfo != null && anim.ViewAnimInfo != null)
		{
			int stateId = anim.ViewAnimInfo.StateId;
			anim.ViewAnimInfo = anim.ViewAnimInfo.NextState(weaponAnimInfo.ViewGetNextAnim(anim.ViewAnimInfo.StateId));
			if (stateId == anim.ViewAnimInfo.StateId)
			{
				anim.RightSpeed = 1f;
				anim.RemainTime = weaponAnimInfo.GetViewAnimDuration(anim.ViewAnimInfo.StateId);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(myPlayer, anim.ViewAnimInfo.StateId);
			}
			if (anim.ViewAnimInfo.StateId == 39 && anim.RemainTime == 0)
			{
				PlayerAnimationUtility.SetViewAnimation(myPlayer, 13);
			}
		}
	}

	private void SequencingLeft(PlayerEntity myEntity, ViewAnimComponent anim, CurrentWeaponComponent weapon)
	{
		if (weapon == null || weapon.WeaponInfo == null)
		{
			return;
		}
		IWeaponAnimInfo weaponAnimInfo = WeaponAnimInfoFactory.Instance.GetWeaponAnimInfo(weapon.WeaponInfo);
		if (weaponAnimInfo != null && anim.ViewAnimInfo != null && anim.LeftViewAnimInfo != null)
		{
			int stateId = anim.LeftViewAnimInfo.StateId;
			anim.LeftViewAnimInfo = anim.LeftViewAnimInfo.NextState(weaponAnimInfo.ViewGetNextAnim(anim.ViewAnimInfo.StateId));
			if (anim.LeftViewAnimInfo.StateId == stateId)
			{
				anim.LeftRemainTime = weaponAnimInfo.GetViewAnimDuration(anim.LeftViewAnimInfo.StateId);
			}
			else
			{
				PlayerAnimationUtility.SetLeftViewAnimation(myEntity, anim.LeftViewAnimInfo.StateId);
			}
		}
	}

	private void PredictWalkAnim(ViewAnimComponent anim, PlayerEntity player)
	{
		IViewAnimStateInfo viewAnimInfo = anim.ViewAnimInfo;
		IViewAnimStateInfo leftViewAnimInfo = anim.LeftViewAnimInfo;
		ILegAnimStateInfo legsAnimInfo = player.legAnim.LegsAnimInfo;
		if (legsAnimInfo != null)
		{
			if (viewAnimInfo != null)
			{
				PredictAnimInfo(viewAnimInfo, legsAnimInfo, player);
			}
			if (leftViewAnimInfo != null)
			{
				PredictAnimInfo(leftViewAnimInfo, legsAnimInfo, player);
			}
		}
	}

	private void PredictAnimInfo(IViewAnimStateInfo viewAnimInfo, ILegAnimStateInfo legAnimInfo, PlayerEntity player)
	{
		if (viewAnimInfo == null)
		{
			return;
		}
		int stateId;
		if (viewAnimInfo.StateId == 13 || viewAnimInfo.StateId == 14)
		{
			stateId = legAnimInfo.StateId;
			if ((uint)(stateId - 7) <= 1u)
			{
				if (viewAnimInfo.StateId != 13)
				{
					PlayerAnimationUtility.SetViewAnimation(player, 13);
				}
			}
			else if (viewAnimInfo.StateId != 14)
			{
				PlayerAnimationUtility.SetViewAnimation(player, 14);
			}
		}
		if (viewAnimInfo.StateId != 39 && viewAnimInfo.StateId != 48)
		{
			return;
		}
		stateId = legAnimInfo.StateId;
		if ((uint)(stateId - 7) <= 1u)
		{
			if (viewAnimInfo.StateId != 39)
			{
				PlayerAnimationUtility.SetViewAnimation(player, 39);
			}
		}
		else if (AnimStateInfoFactory.Instance.CheckHasViewAnimId(48))
		{
			if (viewAnimInfo.StateId != 48)
			{
				PlayerAnimationUtility.SetViewAnimation(player, 48);
			}
		}
		else if (viewAnimInfo.StateId != 39)
		{
			PlayerAnimationUtility.SetViewAnimation(player, 39);
		}
	}
}
