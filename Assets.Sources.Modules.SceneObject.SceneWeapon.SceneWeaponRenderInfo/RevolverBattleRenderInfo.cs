using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class RevolverBattleRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(entity))
		{
			if (!WeaponUtility.IsParticleFireEffect(particle.Key.PatricleName) && particle.Key.PatricleName.ToString().IndexOf("dancang") >= 0)
			{
				particle.Value.SetInsActive(flag: false);
			}
		}
	}
}
