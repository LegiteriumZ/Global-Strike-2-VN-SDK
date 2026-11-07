using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class RiderDouGun : AbstractThirdWeaponEffectLogic
{
	private void UpdateParticle(PlayerEntity player, int raceType)
	{
		bool flag = false;
		if (player.hasTorseAnim && player.torseAnim.TorsoAnimInfo != null)
		{
			flag = player.torseAnim.TorsoAnimInfo.StateId == 40 || player.torseAnim.TorsoAnimInfo.StateId == 39 || player.torseAnim.TorsoAnimInfo.StateId == 46 || player.torseAnim.TorsoAnimInfo.StateId == 20;
		}
		SetParticleActiveBySkinName(player, "weapon_particle_fire_effect", !flag);
		SetParticleActiveBySkinName(player, "weapon_left_particle_fire_effect", !flag);
		SetParticleActiveBySkinName(player, "weapon_particle_fire_effect1", flag);
		SetParticleActiveBySkinName(player, "weapon_particle_effect1", flag);
		SetParticleActiveBySkinName(player, "weapon_particle_effect2", !flag);
		SetParticleActiveBySkinName(player, "weapon_left_particle_effect", !flag);
	}

	private void UpdateAnchor(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		bool flag = false;
		if (player.hasTorseAnim && player.torseAnim.TorsoAnimInfo != null)
		{
			flag = player.torseAnim.TorsoAnimInfo.StateId == 40 || player.torseAnim.TorsoAnimInfo.StateId == 39 || player.torseAnim.TorsoAnimInfo.StateId == 46 || player.torseAnim.TorsoAnimInfo.StateId == 20;
		}
		skins["weaponanchor"].enabled = !flag;
		skins["weaponanchor2"].enabled = !flag;
		skins["weaponanchor3"].enabled = flag;
	}

	public override void Update(PlayerEntity player, int raceType)
	{
		UpdateAnchor(player, raceType);
		UpdateParticle(player, raceType);
	}
}
