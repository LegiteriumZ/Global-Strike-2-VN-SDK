using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils;
using NetData;
using NotifyEvent;
using SSJJMath;
using SSJJPhysics;
using config;
using physics.trace;
using share;

namespace Assets.Sources.Modules.GameRule.Pve;

public class PlayerUltrasonicUpdateSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private SnapshotContext _snapshotContext;

	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private TimeComponent _timeComponent;

	public PlayerUltrasonicUpdateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
		_gameRuleContext = contexts.gameRule;
		_timeComponent = contexts.time.time;
	}

	public void OnPlayback()
	{
		if (!_snapshotContext.hasSnapshots || !_playerContext.isCameraOwner)
		{
			return;
		}
		bool eventUltrasonic = false;
		foreach (KeyValuePair<int, Pve3EventEntityData> item in _snapshotContext.snapshots.LatestSnapshot.Pve3EventEntityDataDict)
		{
			Pve3EventEntityData value = item.Value;
			if (value.BaseEventEntity.EventId == 61 && CheckUltrasonicHit(value))
			{
				eventUltrasonic = true;
				_gameRuleContext.pveState.UltrasonicTime = 5000;
				NotifyManager.ForceInvoke(54);
				break;
			}
		}
		_gameRuleContext.pveState.EventUltrasonic = eventUltrasonic;
		_gameRuleContext.pveState.UltrasonicTime -= _timeComponent.FrameInterval;
	}

	public bool NeedStart(Contexts contexts)
	{
		int raceType = _battleRoomContext.roomData.Data.RaceType;
		if (!_gameRuleContext.currentRule.Rule.IsPve() && raceType != 28)
		{
			return RuleUtilty.IsMultipleRpg(raceType);
		}
		return true;
	}

	private bool CheckUltrasonicHit(Pve3EventEntityData data)
	{
		Vector3D vector3D = new Vector3D(UiIEventCondition.Get_cameraOwnerData_Position().x, UiIEventCondition.Get_cameraOwnerData_Position().y, UiIEventCondition.Get_cameraOwnerData_Position().z);
		float cameraOwnerData_ViewHeight = UiIEventCondition.Get_cameraOwnerData_ViewHeight();
		Vector3D vector3D2 = new Vector3D(vector3D.x, vector3D.y, vector3D.z + (double)cameraOwnerData_ViewHeight);
		Vector3D a = new Vector3D(data.BaseEventEntity.X, data.BaseEventEntity.Y, data.BaseEventEntity.Z);
		Trace trace = new Trace();
		TraceResult traceResult = default(TraceResult);
		float[] array = new float[3];
		float[] array2 = new float[3];
		float[] mins = new float[3];
		float[] maxs = new float[3];
		VectorUtils.Vector3DToFloat3(vector3D2, array);
		VectorUtils.Vector3DToFloat3(a, array2);
		PyEngineUtility.BulletTraceToWorld(_battleRoomContext.pyEngine.PyEngine, trace, array, array2, mins, maxs);
		traceResult.CopyFrom(trace);
		if (traceResult.Fraction == 1f || BspConstantUtil.NoImpact(_battleRoomContext.pyEngine.PyEngine.GetWorld().GetDecalsId(), traceResult.SurfaceFlags))
		{
			vector3D2.z -= cameraOwnerData_ViewHeight;
			vector3D2 = a.Subtract(vector3D2);
			Vector3D cameraOwnerData_Viewaxi = UiIEventCondition.Get_cameraOwnerData_Viewaxi();
			if (vector3D2.x * cameraOwnerData_Viewaxi.x + vector3D2.y * cameraOwnerData_Viewaxi.z + vector3D2.z * cameraOwnerData_Viewaxi.y > 0.0)
			{
				return true;
			}
		}
		return false;
	}
}
