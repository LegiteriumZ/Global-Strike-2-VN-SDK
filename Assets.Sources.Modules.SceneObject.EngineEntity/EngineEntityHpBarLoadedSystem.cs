using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Framework;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Modules.SceneObject.EngineEntity;

public class EngineEntityHpBarLoadedSystem : ReactiveSystem<SceneObjectEntity>, IPlaybackSystem
{
	public EngineEntityHpBarLoadedSystem(Contexts contexts)
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
		if (entity.hasEngineEntityHpBar && entity.hasUnityObjects)
		{
			return !entity.isDestroy;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
			entity.engineEntityHpBar.HpBarObj = gameObject;
			entity.engineEntityHpBar.HpBarTran = gameObject.transform;
			entity.engineEntityHpBar.HpBarSprite = gameObject.transform.Find("WorldSpace/HpBack/HpProgress").GetComponent<Image>();
			entity.engineEntityHpBar.SpriteList = gameObject.GetComponent<SpriteList>().Sprites;
			gameObject.SetActive(value: false);
		}
	}
}
