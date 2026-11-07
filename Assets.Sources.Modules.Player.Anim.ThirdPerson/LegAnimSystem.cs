using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Framework.System;
using Assets.Sources.Utils.PlayerAnim;
using Entitas;
using SSJJBase.Logger;
using SSJJMath;
using share.constant;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class LegAnimSystem : FrameExecuteSystem, IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _players;

	private bool _isCanFrame;

	public LegAnimSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.LegAnim).NoneOf(PlayerMatcher.ThirdPersonGPUAnim));
		int raceType = contexts.battleRoom.roomData.Data.RaceType;
		_isCanFrame = !RuleUtilty.IsGroupModel(raceType) && !RuleUtilty.IsExplode(raceType);
	}

	public void OnRender()
	{
		foreach (PlayerEntity player in _players)
		{
			if (_isCanFrame || !isJump(player))
			{
				int torsoAnimId = PlayerAnimationUtility.GetTorsoAnimId(player);
				int legAnimId = PlayerAnimationUtility.GetLegAnimId(player);
				if (!PlayerAnimationUtility.CheckIsWarpAnimSystem(player, legAnimId, torsoAnimId) && !PlayerAnimationUtility.CheckIsTPSAnimSystem(player))
				{
					SetPlayerLegsAnim(player);
				}
			}
		}
	}

	public void OnPlayback()
	{
		if (Frame(1) || !_isCanFrame)
		{
			OnRender();
		}
	}

	private void SetPlayerLegsAnim(PlayerEntity entity)
	{
		if (!entity.hasThirdPersonUnityObjects)
		{
			return;
		}
		ISjAnimatior animator = entity.thirdPersonUnityObjects.Animator;
		ILegAnimStateInfo legsAnimInfo = entity.legAnim.LegsAnimInfo;
		if (legsAnimInfo == null)
		{
			return;
		}
		float animSpeed = legsAnimInfo.GetAnimSpeed(entity.move.Velocity2D);
		int num = entity.legAnim.ScaledEclipsedTime;
		if (entity.IsMustAnimSync())
		{
			num = entity.torseAnim.EclipsedTime;
		}
		string legsThirdAnimationType = entity.currentWeapon.WeaponInfo.LegsThirdAnimationType;
		string legAnimName = AnimationConstantUtility.GetLegAnimName(animator.GetAnimations(), legsAnimInfo.StateId, legsThirdAnimationType);
		bool isReverse = false;
		if (legAnimName == "runb")
		{
			isReverse = entity.thirdPersonUnityObjects.RunReverse;
			animator.SetParameter("Reverse", 1f);
		}
		else if (legAnimName == "walkb")
		{
			isReverse = entity.thirdPersonUnityObjects.WalkReverse;
			animator.SetParameter("Reverse", 1f);
		}
		else
		{
			animator.SetParameter("Reverse", 0f);
		}
		if (entity.hasOrientation && !entity.move.keepFly)
		{
			animator.SetParameter("ViewYaw", entity.orientation.Yaw);
			if (entity.hasMove)
			{
				animator.SetParameter("MoveDir", YawPitchUtility.GetMovedirAdjustment(entity.orientation.Yaw, entity.orientation.MoveYaw, entity.move.AnimPosition));
			}
			else
			{
				animator.SetParameter("MoveDir", YawPitchUtility.GetMovedirAdjustment(entity.orientation.Yaw, entity.orientation.MoveYaw, animPostion: false));
			}
		}
		else
		{
			animator.SetParameter("MoveDir", 0f);
		}
		bool visiable = !entity.hasVisiable || entity.visiable.IsVisiable || entity.visiable.IsNear;
		if (string.IsNullOrEmpty(legAnimName))
		{
			this.LogErrorFormat("not found leg animation :{0}", legsAnimInfo.StateId);
			return;
		}
		CheckSetAnimPos(entity, legsAnimInfo, entity.currentWeapon.WeaponInfo, entity.basicInfo.CareerInfo);
		float transitionTime = 0.1f;
		if (legsAnimInfo.StateId == 603 || legsAnimInfo.StateId == 605 || legsAnimInfo.StateId == 607 || legsAnimInfo.StateId == 609 || legsAnimInfo.StateId == 611 || legsAnimInfo.StateId == 613 || legsAnimInfo.StateId == 615 || legsAnimInfo.StateId == 617)
		{
			transitionTime = 0f;
		}
		animator.PlayAtFixedTime(0, legAnimName, (float)num / 1000f, animSpeed, legsAnimInfo.IsLoop, isReverse, transitionTime, visiable);
	}

	private void CheckSetAnimPos(PlayerEntity entity, ILegAnimStateInfo stateInfo, IEntitsWeaponInfo info, ICareerInfo careerInfo)
	{
		if (entity.hasMove && entity.isCameraOwner)
		{
			entity.move.AnimPosition = stateInfo.GetAnimPosition(info, careerInfo);
		}
	}
}
