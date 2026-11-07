using System;
using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Components.Player;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Utils.PlayerAnim;
using Entitas;
using SSJJMath;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.Player.Orientation;

public class OrientationAnimSystem : IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _players;

	private bool _isPve;

	public OrientationAnimSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.Orientation));
		_isPve = RuleUtilty.IsPve(contexts.battleRoom.roomData.Data.RaceType);
	}

	public void OnPlayback()
	{
		OnRender();
	}

	public static bool NotMoveAdjustAnim(PlayerEntity player)
	{
		if (player.legAnim.LegsAnimInfo == null)
		{
			return false;
		}
		int stateId = player.legAnim.LegsAnimInfo.StateId;
		if (PlayerCareerUtil.IsTPS(player.GetCareer()) && (stateId == 1 || stateId == 2001 || stateId == 5 || stateId == 340 || stateId == 6))
		{
			return true;
		}
		return AnimationConstantUtility.NotMoveAdjustAnim(stateId);
	}

	public bool AnimationNotMove(PlayerEntity player)
	{
		if (player.legAnim.LegsAnimInfo == null)
		{
			return false;
		}
		int stateId = player.legAnim.LegsAnimInfo.StateId;
		if (stateId == 74 || stateId == 75 || stateId == 76 || stateId == 213 || stateId == 219 || stateId == 225 || stateId == 214 || stateId == 220 || stateId == 226 || stateId == 215 || stateId == 221 || stateId == 227)
		{
			return true;
		}
		if (player.HasStatus(PlayerInfoStatusConstant.ON_SKATE_BOARD.ID))
		{
			return true;
		}
		if (player.move.keepFly)
		{
			return true;
		}
		return false;
	}

	public void OnRender()
	{
		foreach (PlayerEntity player in _players)
		{
			int torsoAnimId = PlayerAnimationUtility.GetTorsoAnimId(player);
			int legAnimId = PlayerAnimationUtility.GetLegAnimId(player);
			if (PlayerAnimationUtility.CheckIsWarpAnimSystem(player, legAnimId, torsoAnimId))
			{
				WarpUpdateOrientation(player);
			}
			else
			{
				CommonUpdateOrientation(player);
			}
		}
	}

	private void WarpUpdateOrientation(PlayerEntity playerEntity)
	{
		float num = YawPitchUtility.MakeAngleInRange(playerEntity.isCameraOwner ? playerEntity.orientation.Yaw : playerEntity.basicInfo.Current.ViewYaw);
		YawPitchUtility.MakeAngleInRange(playerEntity.isCameraOwner ? playerEntity.orientation.Pitch : playerEntity.basicInfo.Current.ViewPitch);
		YawPitchUtility.MakeAngleInRange(playerEntity.isCameraOwner ? playerEntity.orientation.MoveYaw : playerEntity.basicInfo.Current.MoveYaw);
		YawPitchUtility.MakeAngleInRange(playerEntity.isCameraOwner ? playerEntity.orientation.MovePitch : playerEntity.basicInfo.Current.MovePitch);
		YawPitchUtility.MakeAngleInRange(playerEntity.isCameraOwner ? playerEntity.orientation.MoveRoll : playerEntity.basicInfo.Current.MoveRoll);
		_ = playerEntity.move.Moving;
		Transform transform = playerEntity.thirdPersonUnityObjects.ThirdTran.RootContainer.transform;
		float num2 = num;
		int num3 = 0;
		if (playerEntity.HasStatus(PlayerInfoStatusConstant.THUNDER_LEGEND_IN_CONTROL.ID))
		{
			num2 -= 25f;
		}
		Quaternion quaternion = Quaternion.Euler(new Vector3(0f, 0f - num2, -num3));
		if (!playerEntity.hasVisiable || playerEntity.visiable.IsVisiable || playerEntity.visiable.IsNear)
		{
			transform.localRotation = (playerEntity.move.ActThirdMove ? Quaternion.Lerp(transform.localRotation, quaternion, 0.3f) : quaternion);
		}
	}

	private void CommonUpdateOrientation(PlayerEntity playerEntity)
	{
		float num = YawPitchUtility.MakeAngleInRange(playerEntity.isCameraOwner ? playerEntity.orientation.Yaw : playerEntity.basicInfo.Current.ViewYaw);
		float num2 = YawPitchUtility.MakeAngleInRange(playerEntity.isCameraOwner ? playerEntity.orientation.Pitch : playerEntity.basicInfo.Current.ViewPitch);
		float num3 = YawPitchUtility.MakeAngleInRange(playerEntity.isCameraOwner ? playerEntity.orientation.MoveYaw : playerEntity.basicInfo.Current.MoveYaw);
		float num4 = YawPitchUtility.MakeAngleInRange(playerEntity.isCameraOwner ? playerEntity.orientation.MovePitch : playerEntity.basicInfo.Current.MovePitch);
		float num5 = YawPitchUtility.MakeAngleInRange(playerEntity.isCameraOwner ? playerEntity.orientation.MoveRoll : playerEntity.basicInfo.Current.MoveRoll);
		bool flag = playerEntity.move.Moving;
		if (AnimationNotMove(playerEntity))
		{
			flag = false;
		}
		Transform transform = playerEntity.thirdPersonUnityObjects.ThirdTran.RootContainer.transform;
		float f = DiffAngle(num, num3);
		float num6 = num;
		bool flag2 = playerEntity.hasState && playerEntity.state.GetPlayerStateType(268435456);
		if (flag && !NotMoveAdjustAnim(playerEntity) && !playerEntity.move.AnimPosition && !flag2)
		{
			num6 = ((!(Mathf.Abs(f) - 90f > 0.1f)) ? num3 : YawPitchUtility.MakeAngleInRange(num3 + 180f));
		}
		else if (PlayerCareerUtil.IsTPS(playerEntity.GetCareer()) && (playerEntity.legAnim.LegsAnimInfo.StateId == 2000 || playerEntity.legAnim.LegsAnimInfo.StateId == 2003))
		{
			num6 = num3;
		}
		if (playerEntity.move.ActThirdMove)
		{
			num6 = playerEntity.orientation.ActThirdMoveInterYaw;
		}
		float num7 = 0f;
		if (playerEntity.hasLegAnim && playerEntity.legAnim.LegsAnimInfo != null && playerEntity.legAnim.LegsAnimInfo.StateId == 73)
		{
			num7 = ((YawPitchUtility.MakeAngleInRange(num3 - num) < 0f) ? (90f - num2) : (num2 - 90f));
			num6 = num;
		}
		if (playerEntity.HasStatus(PlayerInfoStatusConstant.THUNDER_LEGEND_IN_CONTROL.ID))
		{
			num6 -= 75f;
		}
		float viewYaw = DiffAngle(num6, num, withDir: true);
		UpdateTorso9DirAnmition(viewYaw, num2, playerEntity.thirdPersonUnityObjects.Animator, playerEntity.move, playerEntity.basicInfo.Current.IsBot);
		Quaternion localRotation = Quaternion.Euler(new Vector3(0f, 0f - num6, 0f - num7));
		if (playerEntity.HasStatus(PlayerInfoStatusConstant.ON_AIR_JUMP.ID) && !playerEntity.HasStatus(PlayerInfoStatusConstant.ON_SKATE_BOARD.ID))
		{
			localRotation = Quaternion.Euler(new Vector3(0f - num4, 0f - num3, 0f - num5));
		}
		if (!playerEntity.hasVisiable || playerEntity.visiable.IsVisiable || playerEntity.visiable.IsNear)
		{
			transform.localRotation = localRotation;
		}
	}

	private static float DiffAngle(float angle1, float angle2, bool withDir = false)
	{
		Vector2 vector = new Vector2(Mathf.Cos((float)Math.PI / 180f * angle1), Mathf.Sin((float)Math.PI / 180f * angle1));
		Vector2 vector2 = new Vector2(Mathf.Cos((float)Math.PI / 180f * angle2), Mathf.Sin((float)Math.PI / 180f * angle2));
		float num = Vector2.Angle(vector, vector2);
		if (withDir && Vector3.Cross(vector, vector2).z < 0f)
		{
			num = 360f - num;
		}
		return YawPitchUtility.MakeAngleInRange(num);
	}

	public void UpdateTorso9DirAnmition(float viewYaw, float viewPitch, ISjAnimatior animator, MoveComponent move, bool isBot)
	{
		if (animator == null)
		{
			return;
		}
		float value = YawPitchUtility.MakeAngleInRange(viewYaw) / 90f;
		float value2 = YawPitchUtility.MakeAngleInRange(viewPitch) / 45f;
		value = Mathf.Clamp(value, -1f, 1f);
		value2 = Mathf.Clamp(value2, -1f, 1f);
		if (!isBot)
		{
			if (Mathf.Abs(move.BeforeMoveYaw - value) > 0.25f)
			{
				move.ChangeFrameCount = 0;
			}
			move.BeforeMoveYaw = value;
			if (move.ChangeFrameCount++ < 2)
			{
				animator.SetParameter("MoveState", 1f);
			}
			else
			{
				animator.SetParameter("MoveState", 0f);
			}
		}
		animator.SetParameter("Yaw", value);
		animator.SetParameter("Pitch", value2);
	}
}
