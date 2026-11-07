using System.Collections.Generic;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class DartsRedflash : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		GetSkins(player)["weaponanchor3"].enabled = currentWeapon.special.EffectLevel != 4;
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Equals("11180-wuqi00"))
			{
				particle.Value.SetInsActive((player.GetCurrentWeaponEffectLevel() & 1) > 0);
			}
			if (particle.Key.PatricleName.Equals("11180-shouzhang"))
			{
				particle.Value.SetInsActive((player.GetCurrentWeaponEffectLevel() & 4) > 0);
			}
			if (particle.Key.PatricleName.Equals("11180-wuqi01"))
			{
				particle.Value.SetInsActive((player.GetCurrentWeaponEffectLevel() & 2) > 0);
			}
		}
	}
}
