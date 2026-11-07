using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Rail;
using Assets.Sources.Framework.System;
using Assets.Sources.Modules.Player.Attack.Utils;
using Entitas;
using SSJJMath;
using UnityEngine;
using share;

namespace Assets.Sources.Modules.SceneObject.BulletRail;

public class BulletRailResourceInitSystem : ReactiveResourceInitSystem<SceneObjectEntity>
{
	private PlayerContext _playerContext;

	private Vector3D weaponRailStart = new Vector3D();

	public BulletRailResourceInitSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
		_playerContext = contexts.player;
	}

	private void AddEffect(SceneObjectEntity entity)
	{
		BulletRailParamData data = default(BulletRailParamData);
		data.Start = VectorCoordConverter.SsjjToUnity(entity.bulletRail.StartPosition);
		data.End = VectorCoordConverter.SsjjToUnity(entity.bulletRail.EndPosition);
		if (entity.bulletRail != null && _playerContext.cameraOwnerEntity != null && entity.bulletRail.OwnerId == _playerContext.cameraOwnerEntity.entityId.Value)
		{
			data.IsView = true;
			data.Velocity = 30f;
			data.RailLength = 200f;
			data.StartOffsetBase = 5f;
			data.StartOffsetRandom = 700f;
			data.RailWidth = 20f;
			weaponRailStart.SetTo(0.0, 0.0, 0.0);
			if (HitUtility.GetWeaponRailStartPoint(_playerContext.cameraOwnerEntity, Contexts.sharedInstance, weaponRailStart, entity.bulletRail.IsForceLeftParticleRail))
			{
				entity.bulletRail.StartPosition = new Vector3((float)weaponRailStart.x, (float)weaponRailStart.y, (float)weaponRailStart.z);
				data.Start = entity.bulletRail.StartPosition;
			}
		}
		else
		{
			data.Velocity = 20f;
			data.RailLength = 1000f;
			data.StartOffsetBase = 1000f;
			if (entity.bulletRail != null && entity.bulletRail.EventId == 22)
			{
				data.StartOffsetBase = 100f;
			}
			data.StartOffsetRandom = 0f;
			data.RailWidth = 40f;
		}
		BaseRailEffect componentInChildren = entity.unityObjects.LoadResults[0].GameObject.GetComponentInChildren<BaseRailEffect>();
		if (componentInChildren != null)
		{
			componentInChildren.SetRailData(ref data);
			entity.ReplaceBulletRef(componentInChildren);
			entity.AddLifeTime(DateTime.Now, 3000);
		}
		else
		{
			entity.AddLifeTime(DateTime.Now, 0);
		}
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.UnityObjects.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		return entity.hasBulletRail;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			AddEffect(entity);
		}
	}
}
