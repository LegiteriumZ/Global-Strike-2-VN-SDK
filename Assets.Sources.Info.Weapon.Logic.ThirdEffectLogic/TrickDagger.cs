using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using share.constant;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class TrickDagger : AbstractThirdWeaponEffectLogic
{
	private static string WEAPON_EFFECT1 = "daoshentexiao_2";

	public override void Update(PlayerEntity player, int raceType)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Equals(WEAPON_EFFECT1))
			{
				if (player.HasStatus(PlayerInfoStatusConstant.TRICK_STAGE_5.ID))
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
