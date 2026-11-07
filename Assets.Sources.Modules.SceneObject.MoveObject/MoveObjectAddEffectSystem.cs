using System.Collections.Generic;
using Assets.Scripts.Effect.Level;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.MoveObject;

public class MoveObjectAddEffectSystem : ReactiveSystem<SceneObjectEntity>, IPlaybackSystem
{
	public MoveObjectAddEffectSystem(Contexts contexts)
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
		if (entity.hasMoveObject && entity.hasUnityObjects && !entity.isDestroy)
		{
			return !entity.hasMoveObjectAddEffect;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			ParticleEffectUtility.InitSceneParticle(entity.unityObjects.LoadResults[0].GameObject, entity.unityObjects.LoadResults[0].AssetInfo.AssetName);
			entity.AddMoveObjectAddEffect(newIsAddEffect: true);
		}
	}
}
