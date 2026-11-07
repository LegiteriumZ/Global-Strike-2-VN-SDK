using Assets.Sources.Modules.Player.HitBox;
using SSJJBase.Logger;
using SSJJMath;
using SSJJPhysics;
using SSJJPhysicsExtensions;
using SSJJSceneLoader;
using UnityEngine;
using physics;
using physics.data;
using physics.engine.business;
using physics.entity;
using physics.impl;
using physics.trace;
using share;

namespace Assets.Sources.Utils;

internal static class PyEngineUtility
{
	private static LoggerAdapter _logger = new LoggerAdapter(typeof(PyEngineUtility));

	private static readonly float[] Mins = new float[3];

	private static readonly float[] Maxs = new float[3];

	private static readonly float[] StartF3 = new float[3];

	private static readonly float[] EndF3 = new float[3];

	private static readonly Vector3D Start = new Vector3D();

	private static readonly Vector3D End = new Vector3D();

	public static void InitPyEngine(Contexts contexts, byte[] mapData, int engineId, BspClipMap bspClipMap)
	{
		_logger.Info("Init PyEngine " + engineId);
		if (engineId == 1)
		{
			BspEngine bspEngine = new BspEngine();
			BspClipMapEx map = new BspClipMapEx(bspClipMap, bspEngine);
			SSJJBspTrace bspTrace = new SSJJBspTrace(map);
			bspEngine.Init(map, bspTrace);
			float[] array = new float[3];
			float[] array2 = new float[3];
			bspEngine.GetSceneBound(array, array2);
			contexts.battleRoom.SetPyEngine(bspEngine, new Vector3(array[0], array[1], array[2]), new Vector3(array2[0], array2[1], array2[2]));
		}
		else
		{
			WeEngine weEngine = new WeEngine(new WeEngineExHandler(contexts));
			IPyClipMap clipMap = new DefaultPyClipMap();
			weEngine.Init(clipMap, mapData);
			float[] array3 = new float[3];
			float[] array4 = new float[3];
			weEngine.GetSceneBound(array3, array4);
			contexts.battleRoom.SetPyEngine(weEngine, new Vector3(array3[0], array3[1], array3[2]), new Vector3(array4[0], array4[1], array4[2]));
		}
	}

	public static TraceResult GetBoxTrace(IPyEngine engine, Vector3 rayStart, Vector3 rayEnd, int mask)
	{
		Trace trace = TraceObjectPool.AllocateTrace();
		Start.x = rayStart.x;
		Start.y = rayStart.y;
		Start.z = rayStart.z;
		End.x = rayEnd.x;
		End.y = rayEnd.y;
		End.z = rayEnd.z;
		VectorUtils.Vector3DToFloat3(Start, StartF3);
		VectorUtils.Vector3DToFloat3(End, EndF3);
		engine.GetWorld().BulletTrace(trace, StartF3, EndF3, Mins, Maxs, mask, traceWorld: true);
		TraceResult result = default(TraceResult);
		result.CopyFrom(trace);
		TraceObjectPool.ReturnTrace(trace);
		return result;
	}

	private static void Vector3ToFloat3(ref Vector3 vec, float[] fs)
	{
		fs[0] = vec.x;
		fs[1] = vec.y;
		fs[2] = vec.z;
	}

	public static TraceResult OverLapTraceToWorld(IPyEngine pyEngine, Vector3 start, Vector3 min, Vector3 max, Vector3 end)
	{
		Trace trace = TraceObjectPool.AllocateTrace();
		Vector3ToFloat3(ref start, StartF3);
		Vector3ToFloat3(ref end, EndF3);
		Vector3ToFloat3(ref min, Mins);
		Vector3ToFloat3(ref max, Maxs);
		pyEngine.GetWorld().WorldTrace(trace, StartF3, EndF3, Mins, Maxs, 1, null, 1);
		TraceResult result = default(TraceResult);
		result.CopyFrom(trace);
		TraceObjectPool.ReturnTrace(trace);
		return result;
	}

	public static void BulletTraceToWorld(IPyEngine pyEngine, Trace results, float[] startF3, float[] endF3, float[] mins, float[] maxs)
	{
		int contentmask = 100663299;
		pyEngine.GetWorld().BulletTrace(results, startF3, mins, maxs, endF3, contentmask, traceWorld: true);
	}

	public static void BulletTrace(IPyEngine pyEngine, Trace results, IPyEntity player, float[] startF3, float[] endF3, float[] mins, float[] maxs)
	{
		int contentmask = 100663299;
		pyEngine.GetWorld().Trace(results, startF3, mins, maxs, endF3, contentmask, player, player, 0);
	}

	public static float GetTraceSize(bool isPointTrace, Vector3D mins, Vector3D maxs)
	{
		if (isPointTrace)
		{
			return 0f;
		}
		double num = maxs.x - mins.x;
		double num2 = maxs.y - mins.y;
		double num3 = maxs.z - mins.z;
		if (num < num2)
		{
			num = num2;
		}
		if (num < num3)
		{
			num = num3;
		}
		return (float)num;
	}

	public static void BulletTraceToPlayers(IPyEngine pyEngine, Trace result, float[] start, float[] end, float[] mins, float[] maxs, PlayerContext players, Vector3D shotDir)
	{
		foreach (PlayerEntity player in players)
		{
			if (player.hasHitBox && !player.isMyPlayer)
			{
				float[] pos = new float[3]
				{
					player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).x,
					player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).y,
					player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).z
				};
				double scale = player.headScale.Scale;
				HitPreliminaryGeo hitPreliminaryGeo = player.hitBox.HitPreliminaryGeo;
				if (hitPreliminaryGeo == null || !pyEngine.GetWorld().BulletPreliminaryTrace(start, end, mins, maxs, pos, scale, hitPreliminaryGeo))
				{
					player.hitBox.HitBoxBrushDirty = true;
					PlayerHitBoxBrushUtility.UpdatePlayerAllHitBoxBrush(player);
					pyEngine.GetEntityManager().UpdateEntityHitBrush(2, player.move.PyPlayerMove.GetEntity(), player.hitBox.HitBoxBrush);
					pyEngine.GetTrace().ClipMoveToPlayerHitBoxes(result, start, end, mins, maxs, player.move.PyPlayerMove.GetEntity(), player.hitBox.HitBoxBrush);
				}
			}
		}
	}

	public static Vector3 TraceCamreaEndPos(Vector3 position, Vector3 moveOffset, ref TraceResult ret, float halfSize = 10f, int contentMask = 33619977)
	{
		float[] array = TraceObjectPool.AllocateFloat3();
		float[] array2 = TraceObjectPool.AllocateFloat3();
		array[0] = 0f - halfSize;
		array[1] = 0f - halfSize;
		array[2] = 0f - halfSize;
		array2[0] = halfSize;
		array2[1] = halfSize;
		array2[2] = halfSize;
		Vector3 endPos = position + moveOffset;
		Vector3 result = VectorTypeConverter.FloatArray2UnityVector(WorldTrace(position, endPos, array, array2, null, ref ret, contentMask).EndPos);
		TraceObjectPool.ReturnFloat3(array);
		TraceObjectPool.ReturnFloat3(array2);
		return result;
	}

	public static TraceResult WorldTrace(Vector3 position, Vector3 endPos, float[] mins, float[] maxs, IPyEntity excludeEntity, ref TraceResult ret, int contentMask = 33619977)
	{
		if (!Contexts.sharedInstance.battleRoom.hasPyEngine)
		{
			return ret;
		}
		Trace trace = TraceObjectPool.AllocateTrace();
		float[] array = TraceObjectPool.AllocateFloat3();
		float[] array2 = TraceObjectPool.AllocateFloat3();
		try
		{
			array[0] = position.x;
			array[1] = position.y;
			array[2] = position.z;
			array2[0] = endPos.x;
			array2[1] = endPos.y;
			array2[2] = endPos.z;
			Contexts.sharedInstance.battleRoom.pyEngine.PyEngine.GetWorld().Trace(trace, array, mins, maxs, array2, contentMask, excludeEntity, null, 0);
			ret.CopyFrom(trace);
		}
		finally
		{
			TraceObjectPool.ReturnTrace(trace);
			TraceObjectPool.ReturnFloat3(array);
			TraceObjectPool.ReturnFloat3(array2);
		}
		return ret;
	}
}
