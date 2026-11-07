using System.Collections.Generic;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class MentalBursterSceneWeaponRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(entity))
		{
			if (particle.Key.PatricleName.Equals("qiangshen_0") || particle.Key.PatricleName.Equals("qiangshen_1"))
			{
				particle.Value.SetInsActive(flag: true);
			}
			else
			{
				particle.Value.SetInsActive(flag: false);
			}
		}
	}
}
