using System.Collections.Generic;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class TrickDagger : AbstractViewWeaponEffectLogic
{
	private static string WEAPON_EFFECT1 = "daoshentexiao_2";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Equals(WEAPON_EFFECT1))
			{
				if ((currentWeapon.basicInfo.Data.EffectLevel & 4) > 0 && currentWeapon.power.Power2 == 5)
				{
					particle.Value.SetInsActive(flag: true);
				}
				else
				{
					particle.Value.SetInsActive(flag: false);
				}
			}
			else
			{
				particle.Value.SetInsActive(flag: true);
			}
		}
	}
}
