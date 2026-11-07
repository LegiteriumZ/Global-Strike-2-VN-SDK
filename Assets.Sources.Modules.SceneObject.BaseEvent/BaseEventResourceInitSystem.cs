using System;
using System.Collections.Generic;
using Assets.Scripts.Effect.Level;
using Assets.Sources.Framework.System;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils;
using Entitas;
using SSJJMath;
using SSJJParticle;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.BaseEvent;

internal class BaseEventResourceInitSystem : ReactiveResourceInitSystem<SceneObjectEntity>
{
	public BaseEventResourceInitSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.BaseEventResource.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		if (entity.hasBaseEvent)
		{
			return entity.hasBaseEventResource;
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

	private void AddEffect(SceneObjectEntity entity)
	{
		if (!entity.baseEventResource.LoadResults.ContainsKey(0))
		{
			return;
		}
		GameObject gameObject = entity.baseEventResource.LoadResults[0].GameObject;
		LodUtility.AddInstanceLod(gameObject);
		ParticleEffectUtility.InitSceneParticle(gameObject, entity.baseEventResource.LoadResults[0].AssetInfo.AssetName);
		Vector3 position = VectorCoordConverter.SsjjToUnity(entity.position.Origin);
		gameObject.transform.localEulerAngles = YawPitchUtility.SsjjYawToUnityEularAngle(entity.orientation.Yaw) + YawPitchUtility.SsjjPitchToUnityEularAngle(entity.orientation.Pitch);
		gameObject.transform.position = position;
		if (entity.hasScale)
		{
			gameObject.transform.localScale = entity.scale.Scale;
		}
		else
		{
			gameObject.transform.localScale = Vector3.one;
		}
		EventEffectData eventEntityData = ParticleManager.Instance().GetEventEntityData(entity.baseEvent.Data.EventId);
		if (eventEntityData != null && eventEntityData.EffectTime > 0)
		{
			entity.AddLifeTime(DateTime.Now, eventEntityData.EffectTime);
			return;
		}
		float num = 0f;
		ParticleSystem[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleSystem>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			num = Mathf.Max(componentsInChildren[i].main.duration, num);
		}
		SSJJParticleSystem[] componentsInChildren2 = gameObject.GetComponentsInChildren<SSJJParticleSystem>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			num = Mathf.Max(componentsInChildren2[i].duration, num);
		}
		entity.AddLifeTime(DateTime.Now, (int)(num * 1000f));
	}
}
