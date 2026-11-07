using System.Collections.Generic;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class DefaultSceneWeaponRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		if (entity.hasEffectDict && entity.effectDict.LogicAsset != null)
		{
			return;
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(entity))
		{
			particle.Value.SetInsActive(particle.Value.getVisibleState() == 0);
		}
	}
}
