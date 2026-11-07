using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class MP5Ice : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		if (player != null)
		{
			if (player.hasTorseAnim && player.torseAnim.TorsoAnimInfo != null)
			{
				SetParticleActiveParticleName(player, "qiangkouhuohua", player.torseAnim.TorsoAnimInfo.StateId == 15);
			}
			Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
			if (skins != null)
			{
				skins["weapon_particle_fire_effect1"].enabled = false;
			}
		}
	}
}
