using Assets.Sources.Framework;
using NetData;
using SSJJMath;
using SSJJUserCmd;
using UnityEngine;
using math;
using share;
using share.constant;

namespace Assets.Sources.Modules.Player.Orientation;

public class PlayerOrientationPredicationSystem : IPredicateSystem
{
	private SnapshotContext _snapshotContext;

	private WorldCameraContext _worldCameraConteaxt;

	private Vector4 _moveAngles;

	public PlayerOrientationPredicationSystem(Contexts contexts)
	{
		_worldCameraConteaxt = contexts.worldCamera;
		_snapshotContext = contexts.snapshot;
	}

	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		if (!myPlayer.basicInfo.IsDead && myPlayer.hasOrientation && (!_worldCameraConteaxt.hasSceneCameraInfo || !_worldCameraConteaxt.sceneCameraInfo.PlayerCameraNotMove) && (!_snapshotContext.hasSnapshots || _snapshotContext.snapshots.NowSnapshot.ControlId == 0 || myPlayer.entityId.Value == _snapshotContext.snapshots.NowSnapshot.ControlId))
		{
			PlayerInfoData playerInfoData = Contexts.sharedInstance.battleRoom.playerInfo.GetPlayerInfoData(myPlayer.basicInfo.Cid);
			if (playerInfoData != null && !playerInfoData.ThirdModeNoViewChange)
			{
				myPlayer.orientation.Yaw = (float)cmd.CameraYaw / 100f;
			}
			myPlayer.orientation.Pitch = (float)cmd.CameraPitch / 100f;
			if (myPlayer.HasStatus(PlayerInfoStatusConstant.ON_AIR_JUMP.ID))
			{
				Vector3D vector3D = AngleUtils.VectorToAngles(new Vector3D
				{
					x = myPlayer.move.Velocity.x,
					y = myPlayer.move.Velocity.y,
					z = myPlayer.move.Velocity.z
				});
				myPlayer.orientation.Yaw = (float)vector3D.x;
				myPlayer.orientation.Pitch = (float)vector3D.y;
			}
			PredictCmdOnCamera(myPlayer, cmd);
		}
	}

	private void PredictCmdOnCamera(PlayerEntity player, IUserCmd cmd)
	{
		bool playerStateType = player.state.GetPlayerStateType(268435456);
		if (player.HasStatus(PlayerInfoStatusConstant.ON_AIR_JUMP.ID) || (player.move.ActThirdMove && playerStateType) || player.move.keepFly)
		{
			return;
		}
		if (player.state.GetPlayerStateType(1073741824))
		{
			player.orientation.MoveYaw = 0f;
		}
		bool flag = !player.move.ActThirdMove || cmd.IsMove;
		if (flag && player.move.AnimPosition && !player.basicInfo.CareerInfo.Name.Equals("mechfar2"))
		{
			_moveAngles.x = player.orientation.MoveYaw;
			player.orientation.ActThirdMoveInterYaw = player.orientation.MoveYaw;
			return;
		}
		float finalMoveYaw = _moveAngles.x;
		CaculateFinalMoveYaw(player, flag, cmd, player.move.AnimPosition, ref finalMoveYaw);
		if (!player.move.AnimPosition && (cmd.IsLeft || cmd.IsRight || cmd.IsForward || cmd.IsBackward))
		{
			finalMoveYaw = YawPitchUtility.MakeAngleInRange(finalMoveYaw);
			_moveAngles.x = (player.orientation.MoveYaw = finalMoveYaw);
			_moveAngles.w = 1f;
		}
		else if (player.GetVelocity() < 0.1f)
		{
			_moveAngles.w = 0f;
		}
		if (player.move.ActThirdMove)
		{
			float num = ((player.orientation.MoveYaw < 0f) ? (player.orientation.MoveYaw + 360f) : player.orientation.MoveYaw);
			float num2 = ((player.orientation.ActThirdMoveInterYaw < 0f) ? (player.orientation.ActThirdMoveInterYaw + 360f) : player.orientation.ActThirdMoveInterYaw);
			float num3 = num - num2;
			if (num3 > 180f)
			{
				num3 -= 360f;
			}
			else if (num3 < -180f)
			{
				num3 += 360f;
			}
			if (player.move.keepFly)
			{
				num3 = 0f;
			}
			player.orientation.ActThirdMoveInterYaw += num3 * 0.3f * (float)cmd.FrameInterval / 17f;
			player.orientation.ActThirdMoveInterYaw = YawPitchUtility.MakeAngleInRange(player.orientation.ActThirdMoveInterYaw);
		}
	}

	private void CaculateFinalMoveYaw(PlayerEntity player, bool moveStatus, IUserCmd cmd, bool animationPos, ref float finalMoveYaw)
	{
		bool isForward = cmd.IsForward;
		bool flag = cmd.IsLeft;
		bool flag2 = cmd.IsRight;
		bool flag3 = cmd.IsBackward;
		if (player.move.keepFly)
		{
			flag = false;
			flag2 = false;
			flag3 = false;
		}
		if (!moveStatus || animationPos)
		{
			return;
		}
		if (isForward)
		{
			if (flag)
			{
				finalMoveYaw = (float)cmd.CameraYaw / 100f + 45f;
			}
			else if (flag2)
			{
				finalMoveYaw = (float)cmd.CameraYaw / 100f - 45f;
			}
			else
			{
				finalMoveYaw = (float)cmd.CameraYaw / 100f;
			}
		}
		else if (flag3)
		{
			if (flag)
			{
				finalMoveYaw = (float)cmd.CameraYaw / 100f + 135f;
			}
			else if (flag2)
			{
				finalMoveYaw = (float)cmd.CameraYaw / 100f - 135f;
			}
			else
			{
				finalMoveYaw = (float)cmd.CameraYaw / 100f + 180f;
			}
		}
		else if (flag)
		{
			finalMoveYaw = (float)cmd.CameraYaw / 100f + 90f;
		}
		else if (flag2)
		{
			finalMoveYaw = (float)cmd.CameraYaw / 100f - 90f;
		}
	}
}
