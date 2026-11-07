using System.Collections.Generic;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class FanaticalTempoFmg : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		List<IPaticlePrefabInstancecs> paticlesArrayByParticleName = GetPaticlesArrayByParticleName(player, "qangshen");
		if ((player.GetCurrentWeaponEffectLevel() & 1) > 0)
		{
			foreach (IPaticlePrefabInstancecs item in paticlesArrayByParticleName)
			{
				if (item.getGameObject().activeInHierarchy)
				{
					item.SetInsActive(flag: true);
					item.Restart();
				}
			}
			return;
		}
		foreach (IPaticlePrefabInstancecs item2 in paticlesArrayByParticleName)
		{
			item2.SetInsActive(flag: false);
		}
	}
}
