using System.Collections.Generic;
using Assets.Scripts.Effect.Level;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.LinkObject;

public class LinkObjectAddEffectSystem : ReactiveSystem<SceneObjectEntity>, IPlaybackSystem
{
	public LinkObjectAddEffectSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
		Activate();
	}

	public void OnPlayback()
	{
		Execute();
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.UnityObjects.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		if (entity.hasLinkObject && entity.hasUnityObjects && !entity.isDestroy)
		{
			return !entity.hasLinkObjectAddEffect;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			entity.AddLinkObjectAddEffect(newIsAddEffect: true);
			ParticleEffectUtility.InitSceneParticle(entity.unityObjects.LoadResults[0].GameObject, entity.unityObjects.LoadResults[0].AssetInfo.AssetName);
			if (entity.hasExtend1Resource)
			{
				ParticleEffectUtility.InitSceneParticle(entity.extend1Resource.LoadResults[0].GameObject, entity.extend1Resource.LoadResults[0].AssetInfo.AssetName);
			}
			if (entity.hasExtend2Resource)
			{
				ParticleEffectUtility.InitSceneParticle(entity.extend2Resource.LoadResults[0].GameObject, entity.extend2Resource.LoadResults[0].AssetInfo.AssetName);
			}
		}
	}
}
