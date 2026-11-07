using Assets.Sources.Components.Interface;
using Assets.Sources.Utils;
using SSJJMath;
using SSJJPhysics;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerShadowRender : AbstractPlayerEffectRender
{
	private readonly float[] _mins = new float[3] { -45f, -45f, 0f };

	private readonly float[] _maxs = new float[3] { 45f, 45f, 1f };

	private Vector3 _offset;

	private Vector3 _scale;

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return _offset;
	}

	public override Vector3 GetScale(PlayerEntity targetPlayer, SceneObjectEntity effectEntity, IBattleRoom battleRoom)
	{
		return _scale;
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		Vector3 compenstatePos = targetPlayer.GetCompenstatePos(targetPlayer.fpos.Change.GetPosIndex());
		Vector3 endPos = compenstatePos - new Vector3(0f, 0f, 1000f);
		TraceResult ret = default(TraceResult);
		TraceResult traceResult = PyEngineUtility.WorldTrace(compenstatePos, endPos, _mins, _maxs, targetPlayer.GetPyEntity(), ref ret);
		Vector3 vector = VectorTypeConverter.FloatArray2UnityVector(traceResult.EndPos);
		Vector3 inv = VectorTypeConverter.FloatArray2UnityVector(traceResult.Plane.normal);
		_offset = vector - compenstatePos;
		EffectObject.transform.up = VectorCoordConverter.SsjjToUnity(inv);
		_scale = Vector3.one * (1f - traceResult.Fraction);
	}
}
