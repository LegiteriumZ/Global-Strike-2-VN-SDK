using System.Collections.Generic;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class WolfClaw : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			particle.Value.SetInsActive(player.GetCurrentWeaponEffectLevel() > 0);
		}
	}
}
