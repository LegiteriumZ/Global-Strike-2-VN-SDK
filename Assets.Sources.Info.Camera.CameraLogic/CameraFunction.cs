using Assets.Sources.Components.Camera;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Camera;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Free.Data;
using Assets.Sources.Utils;
using SSJJMath;
using SSJJPhysics;
using UnityEngine;
using physics.trace;
using share;

namespace Assets.Sources.Info.Camera.CameraLogic;

public static class CameraFunction
{
	private const int TotalTime = 100;

	public static Vector3 SetSkillCameraViewOrg(this ICameraLogic cameraLogic, float roll, float yaw, float pitch, PlayerEntity player)
	{
		Contexts sharedInstance = Contexts.sharedInstance;
		Vector3D vector3D = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D2 = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D3 = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D4 = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D5 = TraceObjectPool.AllocateVector3D();
		vector3D2.x = 0f - pitch;
		vector3D2.y = yaw;
		vector3D2.z = roll;
		vector3D.x = 0.0;
		vector3D.y = 0.0;
		vector3D.z = 0.0;
		vector3D3.x = 0.0;
		vector3D3.y = 0.0;
		vector3D3.z = 0.0;
		AngleUtility.AnglesToVectors2(vector3D2, vector3D4, vector3D3, vector3D5);
		vector3D3 = vector3D.Subtract(vector3D3);
		TimeComponent time = sharedInstance.time.time;
		CameraDataComponent cameraData = sharedInstance.worldCamera.cameraData;
		if (cameraData.RenderTime + 200 < time.RenderTime)
		{
			cameraData.EffectTime = 0;
		}
		cameraData.RenderTime = time.RenderTime;
		cameraData.EffectTime = Mathf.Min(100, cameraData.EffectTime + time.FrameInterval);
		float num = (float)cameraData.EffectTime / 100f;
		num *= num;
		if (num > 0.5f)
		{
			num = 0.5f - num;
		}
		vector3D4.ScaleBy(10f * (0f - num));
		vector3D3.ScaleBy(20f * num);
		Vector3 result = player.GetCompenstatePos(player.fpos.Change.GetPosIndex()) + new Vector3(0f, 0f, cameraLogic.ViewHeight(player));
		result.x += (float)vector3D4.x + (float)vector3D3.x;
		result.y += (float)vector3D4.y + (float)vector3D3.y;
		result.z += (float)vector3D4.z + (float)vector3D3.z;
		TraceObjectPool.ReturnVector3D(vector3D);
		TraceObjectPool.ReturnVector3D(vector3D2);
		TraceObjectPool.ReturnVector3D(vector3D3);
		TraceObjectPool.ReturnVector3D(vector3D4);
		TraceObjectPool.ReturnVector3D(vector3D5);
		return result;
	}

	private static Vector3 MoveOffset(float yaw, float pitch, float distance)
	{
		return AngleUtility.AnglesToVector(yaw, pitch) * -1f * distance;
	}

	public static Vector3 GetCalculateCameraEndPos(this ICameraLogic cameraLogic, Vector3 position, float yaw, float pitch, float distance = 300f, float halfsize = 10f)
	{
		TraceResult ret = default(TraceResult);
		PyEngineUtility.TraceCamreaEndPos(position, MoveOffset(yaw, pitch, distance), ref ret, halfsize, cameraLogic.ContentMask());
		return new Vector3(ret.EndPos[0], ret.EndPos[1], ret.EndPos[2]);
	}

	public static Vector3 GetCalculateCameraEndPosP3HeroRemote(this ICameraLogic cameraLogic, Vector3 position, float yaw, float pitch, float distance = 300f, float halfsize = 10f)
	{
		TraceResult ret = default(TraceResult);
		PyEngineUtility.TraceCamreaEndPos(position, MoveOffset(yaw, pitch, distance), ref ret, halfsize, cameraLogic.ContentMask());
		if (ret.Fraction < 1f)
		{
			float num = Mathf.Max(ret.Fraction, 0.4f);
			position.z -= 40f * num;
			PyEngineUtility.TraceCamreaEndPos(position, MoveOffset(yaw, pitch, distance), ref ret, halfsize, cameraLogic.ContentMask());
		}
		return new Vector3(ret.EndPos[0], ret.EndPos[1], ret.EndPos[2]);
	}

	public static float GetCurrentCmdYaw(this ICameraLogic cameraLogic)
	{
		return (float)Contexts.sharedInstance.userCommand.commands.LastCameraYaw() / 100f;
	}

	public static float GetCurrentCmdPitch(this ICameraLogic cameraLogic)
	{
		return (float)Contexts.sharedInstance.userCommand.commands.LastCameraPitch() / 100f;
	}

	public static bool GetCurrentCmdSecondAttack(this ICameraLogic cameraLogic)
	{
		return Contexts.sharedInstance.userCommand.commands.LastIsSecondAttack();
	}

	public static float GetPlayerYaw(this ICameraLogic cameraLogic, PlayerEntity player)
	{
		BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
		if (battleRoom.roomData.IsObserver || (cameraLogic.IsSpecialThirdObserver(battleRoom) && !battleRoom.gameStateEntity.isObserverFirstMode))
		{
			return cameraLogic.GetCurrentCmdYaw();
		}
		if (player.hasMove && player.move.ActThirdMove)
		{
			return cameraLogic.GetCurrentCmdYaw();
		}
		if (!player.IsDead())
		{
			return player.GetViewYaw() + player.punchSmooth.TempPunchYaw + GameModelLocator.GetInstance().GameModel.ShakeAngleOffect.x;
		}
		return 0f;
	}

	public static float GetPlayerPitch(this ICameraLogic cameraLogic, PlayerEntity player)
	{
		BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
		if (battleRoom.roomData.IsObserver || (cameraLogic.IsSpecialThirdObserver(battleRoom) && !battleRoom.gameStateEntity.isObserverFirstMode))
		{
			return cameraLogic.GetCurrentCmdPitch();
		}
		if (!player.IsDead())
		{
			return player.GetViewPitch() + player.punchSmooth.TempPunchPitch + GameModelLocator.GetInstance().GameModel.ShakeAngleOffect.y;
		}
		return 0f;
	}

	public static bool IsSpecialThirdObserver(this ICameraLogic cameraLogic, BattleRoomContext battleroom)
	{
		Contexts sharedInstance = Contexts.sharedInstance;
		if (sharedInstance.snapshot.hasSnapshots)
		{
			ISnapshot latestSnapshot = sharedInstance.snapshot.snapshots.LatestSnapshot;
			if (latestSnapshot != null && latestSnapshot.Observer > 0 && RuleUtilty.AllowThirdObserveMode(battleroom))
			{
				return true;
			}
		}
		return false;
	}

	public static Vector3 MoveToTargetPos(this ICameraLogic cameraLogic, Vector3 position, Vector3 lastPosition)
	{
		TimeComponent time = Contexts.sharedInstance.time.time;
		float num = Vector3.Distance(lastPosition, position);
		if (num <= 100f)
		{
			return position;
		}
		double num2 = (double)num / 0.1;
		Vector3 normalized = (lastPosition - position).normalized;
		return position + normalized * ((float)time.FrameInterval / 1000f * (float)num2);
	}
}
