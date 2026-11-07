using System;
using System.Collections.Generic;
using Assets.Scripts.Effect.Level;
using Assets.Sources.Framework.System;
using Assets.Sources.Info.Res;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Entitas;
using NetData;
using SSJJBase.Manager;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.GrenadeExplosion;

public class GrenadeExplosionResourceInitSystem : ReactiveResourceInitSystem<SceneObjectEntity>
{
	public GrenadeExplosionResourceInitSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
	}

	private void AddEffect(SceneObjectEntity entity)
	{
		if (!entity.unityObjects.LoadResults.ContainsKey(0))
		{
			return;
		}
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		Vector3 position = VectorCoordConverter.SsjjToUnity(entity.position.Origin);
		Vector3 toDirection = VectorCoordConverter.SsjjToUnity(entity.normal.Normal);
		gameObject.transform.position = position;
		gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
		if (entity.hasScale)
		{
			gameObject.transform.localScale = entity.scale.Scale;
		}
		else
		{
			gameObject.transform.localScale = Vector3.one;
		}
		GrenadeExplosionEventEntityData data = entity.grenadeExplosion.Data;
		EventEffectData eventEntityData = ParticleManager.Instance().GetEventEntityData(data.BaseEventEntity.EventId);
		ExplosionConfig explosionConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetExplosionConfig(data.BaseEventEntity.EventId, data.ResTypeID);
		int newLifeTime = 3000;
		if (explosionConfig != null)
		{
			newLifeTime = explosionConfig.EffectTime;
		}
		else if (eventEntityData != null)
		{
			if (eventEntityData.EffectTime != 0)
			{
				UpdateEventEffectData(gameObject, eventEntityData);
			}
			if (eventEntityData.EffectTime > 0)
			{
				newLifeTime = eventEntityData.EffectTime;
			}
		}
		entity.AddLifeTime(DateTime.Now, newLifeTime);
		ParticleEffectUtility.InitSceneParticle(gameObject, entity.unityObjects.LoadResults[0].AssetInfo.AssetName);
	}

	private static void UpdateEventEffectData(GameObject obj, EventEffectData particle)
	{
		int num = 0;
		ParticleSystem[] componentsInChildren = obj.GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem particleSystem in componentsInChildren)
		{
			if (particleSystem.main.loop)
			{
				num = -1;
				break;
			}
			int num2 = (int)(particleSystem.main.duration * 1000f);
			num = ((num > num2) ? num : num2);
		}
		particle.EffectTime = num;
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.UnityObjects.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		if (entity.hasGrenadeExplosion)
		{
			return entity.hasUnityObjects;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			AddEffect(entity);
		}
	}
}
