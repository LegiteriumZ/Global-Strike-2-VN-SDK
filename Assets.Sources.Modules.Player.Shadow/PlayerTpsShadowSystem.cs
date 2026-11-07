using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Entitas;
using SSJJMath;
using SSJJPhysics;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Shadow;

public class PlayerTpsShadowSystem : IRenderSystem
{
	private readonly float[] _mins = new float[3] { -45f, -45f, 0f };

	private readonly float[] _maxs = new float[3] { 45f, 45f, 1f };

	private readonly IGroup<PlayerEntity> _group;

	private readonly Vector3 _defaultPosDiff = new Vector3(0f, 0f, 0f);

	private readonly Vector3 _defaultScale = new Vector3(1f, 1f, 1f);

	public PlayerTpsShadowSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.AcgShadow));
	}

	public void OnRender()
	{
		foreach (PlayerEntity item in _group)
		{
			GameObject acgShadow = item.acgShadow.AcgShadow;
			if (acgShadow != null)
			{
				Vector3 compenstatePos = item.GetCompenstatePos(item.fpos.Change.GetPosIndex());
				Vector3 endPos = compenstatePos - new Vector3(0f, 0f, 1000f);
				TraceResult ret = default(TraceResult);
				TraceResult traceResult = PyEngineUtility.WorldTrace(compenstatePos, endPos, _mins, _maxs, item.GetPyEntity(), ref ret);
				Vector3 inv = VectorTypeConverter.FloatArray2UnityVector(traceResult.EndPos);
				Vector3 inv2 = VectorTypeConverter.FloatArray2UnityVector(traceResult.Plane.normal);
				acgShadow.transform.position = VectorCoordConverter.SsjjToUnity(inv);
				acgShadow.transform.up = VectorCoordConverter.SsjjToUnity(inv2);
				acgShadow.transform.position += _defaultPosDiff;
				acgShadow.transform.localScale = _defaultScale;
				acgShadow.SetActive(!item.IsDead());
			}
		}
	}
}
