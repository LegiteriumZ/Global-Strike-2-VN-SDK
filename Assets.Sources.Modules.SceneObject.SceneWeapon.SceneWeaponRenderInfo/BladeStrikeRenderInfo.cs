using System.Collections.Generic;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class BladeStrikeRenderInfo : AbstractSceneWeaponInfo
{
	private bool b_showdaoren;

	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(entity))
		{
			if (particle.Key.PatricleName.ToString().IndexOf("daohun") >= 0)
			{
				if ((entity.sceneWeapon.Current.Level & 0x200) > 0)
				{
					particle.Value.SetInsActive(flag: true);
				}
				if ((entity.sceneWeapon.Current.Level & 0x20) > 0)
				{
					b_showdaoren = true;
				}
			}
			if (particle.Key.PatricleName.ToString().IndexOf("daoren02") >= 0 && b_showdaoren)
			{
				particle.Value.SetInsActive(flag: true);
			}
			if (particle.Key.PatricleName.ToString().IndexOf("daoren01") >= 0 && !b_showdaoren)
			{
				particle.Value.SetInsActive(flag: true);
			}
		}
	}
}
