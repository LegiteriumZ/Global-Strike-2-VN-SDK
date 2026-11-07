using System.Collections.Generic;
using Assets.Sources.Framework.System;
using Assets.Sources.Particle.Config;
using Assets.Sources.XmlAsset;
using Entitas;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject;

public class EffectConfigLoadedSystem : ReactiveResourceInitSystem<SceneObjectEntity>
{
	public EffectConfigLoadedSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.EffectConfig.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		return entity.hasEffectConfig;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			string name = entity.iTweenMove.Data.BaseMoveEntity.Name;
			if (entity.effectConfig.LoadResults == null || entity.effectConfig.LoadResults.Count == 0)
			{
				entity.AddLoadUnityObjects(new LoadRequests(new AssetInfo($"sceneobject/{name}", $"Assets/Res/Assets/sceneObject/{name}/model.prefab", typeof(GameObject))), entity.entityId.Value);
				continue;
			}
			SceneObjectEffectConfig config = ((SceneObjectEffectXmlAsset)entity.effectConfig.LoadResults[0].Object).Config;
			if (config == null)
			{
				entity.AddLoadUnityObjects(new LoadRequests(new AssetInfo($"sceneobject/{name}", $"Assets/Res/Assets/sceneObject/{name}/model.prefab", typeof(GameObject))), entity.entityId.Value);
				continue;
			}
			string text = config.EffectName.Replace(".uf3d", "");
			AssetInfo info = new AssetInfo($"sceneobject/{name}", $"Assets/Res/Assets/sceneObject/{name}/effect/{text}/Prefab/{text}.prefab", typeof(GameObject));
			entity.AddLoadUnityObjects(new LoadRequests(info), entity.entityId.Value);
		}
	}
}
