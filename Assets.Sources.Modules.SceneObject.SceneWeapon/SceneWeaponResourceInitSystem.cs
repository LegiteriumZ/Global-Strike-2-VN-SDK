using System.Collections.Generic;
using Assets.Sources.Framework.System;
using Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon;

internal class SceneWeaponResourceInitSystem : ReactiveResourceInitSystem<SceneObjectEntity>
{
	public SceneWeaponResourceInitSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.UnityObjects.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		return entity.hasSceneWeapon;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			SceneWeaponRenderFactory.Instance.GetRenderInfo(entity.sceneWeapon.Current.WeaponName, entity.sceneWeapon.Current.WeaponType).Init(entity);
		}
	}
}
