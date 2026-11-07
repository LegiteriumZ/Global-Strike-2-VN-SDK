using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Utils;
using NetData;
using SSJJBase.Constant;
using SSJJMath;
using SSJJPhysics;
using UnityEngine;

namespace Assets.Sources.Info.Camera.CameraLogic;

public class FreeSpecialLogic : DefaultCameraLogic
{
	public override int Priority()
	{
		return 45;
	}

	public override float Yaw()
	{
		return Contexts.worldCamera.sceneCameraInfo.ConstYaw;
	}

	public override float Pitch()
	{
		return Contexts.worldCamera.sceneCameraInfo.ConstPitch;
	}

	public override Vector3 Position()
	{
		return Contexts.worldCamera.sceneCameraInfo.Position;
	}

	public override PlayerCameraModeEnum CameraMode()
	{
		return PlayerCameraModeEnum.Third;
	}

	public override bool IsActive()
	{
		if (Contexts.battleRoom.roomData.Data != null)
		{
			return Contexts.battleRoom.roomData.Data.RaceType == 17003;
		}
		return false;
	}

	public override void ReActive()
	{
	}

	public override void Update()
	{
		TimeComponent time = Contexts.time.time;
		WorldCameraContext worldCamera = Contexts.worldCamera;
		worldCamera.sceneCameraInfo.PlayerCameraNotMove = Contexts.sharedInstance.player.myPlayerEntity.GetPlayerInfo().ThirdModeNoViewChange;
		if (worldCamera.hasScenemapPosition && worldCamera.hasPosGroupChange && worldCamera.scenemapPosition.MapPositionData != null && worldCamera.posGroupChange.PosGroupChangeParam != null && worldCamera.posGroupChange.PosGroupChangeParam.Group != 0 && Contexts.sharedInstance.player.myPlayerEntity != null)
		{
			PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
			float f = -20f;
			Vector3 vector = CalPos(worldCamera.scenemapPosition.MapDict, worldCamera.posGroupChange.PosGroupChangeParam.Group, myPlayerEntity, time.FrameInterval, Mathf.Abs(f));
			Vector3 vector2 = AngleUtility.Vector3DAngles(GetPos(worldCamera.scenemapPosition.MapDict, worldCamera.posGroupChange.PosGroupChangeParam.Group, 57) - vector);
			worldCamera.sceneCameraInfo.Position = vector;
			worldCamera.sceneCameraInfo.ConstYaw = vector2.y;
			worldCamera.sceneCameraInfo.ConstPitch = 0f - vector2.x;
		}
	}

	private Vector3 CalPos(Dictionary<string, List<Vector3DData>> dict, int group, PlayerEntity player, int frameTime, float ang)
	{
		Vector3 compenstatePos = player.GetCompenstatePos(player.fpos.Change.GetPosIndex());
		Vector3 pos = GetPos(dict, group, 56);
		Vector3 pos2 = GetPos(dict, group, 1);
		Vector3 vector = pos - pos2;
		Vector3 rhs = compenstatePos - pos2;
		float num = Vector3.Dot(vector, rhs) / vector.magnitude;
		Vector3 position = Contexts.sharedInstance.worldCamera.cameraTransform.position;
		Vector3 rhs2 = position - pos2;
		float num2 = Vector3.Dot(vector, rhs2) / vector.magnitude;
		vector.Normalize();
		Vector3 vector2 = default(Vector3);
		Vector3 start = default(Vector3);
		Vector3 end = default(Vector3);
		Vector3 min = new Vector3(-1f, -1f, -1f);
		Vector3 max = new Vector3(1f, 1f, 1f);
		if (num - num2 > 1050f)
		{
			Vector3 vector3 = (num - num2) / 1.1f * vector;
			Vector3 vector4 = (float)frameTime / 1000f * vector3;
			vector2 = position + vector4;
			start.x = pos.x;
			start.y = pos.y;
			start.z = pos.z;
			end.x = vector2.x;
			end.y = vector2.y;
			end.z = vector2.z;
			TraceResult traceResult = PyEngineUtility.OverLapTraceToWorld(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, start, min, max, end);
			vector2.x = traceResult.EndPos[0];
			vector2.y = traceResult.EndPos[1];
			vector2.z = traceResult.EndPos[2];
			return vector2;
		}
		float num3 = num - 1000f;
		Vector3 vector5 = default(Vector3);
		vector5.x = pos2.x + num3 * vector.x;
		vector5.y = pos2.y + num3 * vector.y;
		vector5.z = pos2.z + num3 * vector.z;
		start.x = pos2.x;
		start.y = pos2.y;
		start.z = pos2.z;
		end.x = vector5.x;
		end.y = vector5.y;
		end.z = vector5.z;
		TraceResult traceResult2 = PyEngineUtility.OverLapTraceToWorld(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, start, min, max, end);
		vector2.x = traceResult2.EndPos[0];
		vector2.y = traceResult2.EndPos[1];
		vector2.z = traceResult2.EndPos[2];
		Vector3 vector6 = new Vector3(vector2.x, vector2.y, vector2.z);
		start = vector6;
		end = vector6;
		end.z = end.z + ViewHeightUtility.GetViewHeight(player) + 250f;
		traceResult2 = PyEngineUtility.OverLapTraceToWorld(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, start, min, max, end);
		vector6.x = traceResult2.EndPos[0];
		vector6.y = traceResult2.EndPos[1];
		vector6.z = traceResult2.EndPos[2];
		return vector6;
	}

	private Vector3 GetPos(Dictionary<string, List<Vector3DData>> dict, int gp, int idx)
	{
		Vector3 result = default(Vector3);
		int num = gp * 100 + idx;
		string key = "map_" + num;
		Vector3DData vector3DData = dict[key][0];
		result.x = vector3DData.X;
		result.y = vector3DData.Y;
		result.z = vector3DData.Z;
		return result;
	}
}
