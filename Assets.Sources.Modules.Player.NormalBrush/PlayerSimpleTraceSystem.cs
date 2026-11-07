using Assets.Sources.Framework;
using Assets.Sources.Utils.Weapon;
using SSJJPhysics;
using UnityEngine;

namespace Assets.Sources.Modules.Player.NormalBrush;

public class PlayerSimpleTraceSystem : IPlaybackSystem
{
	private readonly PlayerContext _playerContext;

	private readonly WeaponContext _weaponContext;

	private readonly float[] _mins = new float[3];

	private readonly float[] _maxs = new float[3];

	public PlayerSimpleTraceSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_weaponContext = contexts.weapon;
	}

	public void OnPlayback()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (cameraOwnerEntity != null && currentWeaponEntity != null)
		{
			TraceResult traceResult = FireUtility.FireNormal(cameraOwnerEntity, currentWeaponEntity, 0, 8000f, _mins, _maxs);
			cameraOwnerEntity.normalTrace.EntityId = traceResult.EntityId;
			cameraOwnerEntity.normalTrace.CollisionPoint = new Vector3(traceResult.EndPos[0], traceResult.EndPos[1], traceResult.EndPos[2]);
			cameraOwnerEntity.normalTrace.BulletPreliminaryTargets.Clear();
			FireUtility.FirePreliminary(cameraOwnerEntity, currentWeaponEntity, 0, 8000f, _mins, _maxs, cameraOwnerEntity.normalTrace.BulletPreliminaryTargets);
		}
	}
}
