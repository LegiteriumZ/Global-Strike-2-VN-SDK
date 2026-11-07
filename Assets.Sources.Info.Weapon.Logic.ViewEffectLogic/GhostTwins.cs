using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class GhostTwins : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		int effectLevel = currentWeapon.special.EffectLevel;
		SetParticleActiveParticleName(player, "juqi", effectLevel > 0 && effectLevel < 10);
		SetParticleActiveParticleName(player, "juqi_putong", effectLevel > 9);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SSJJObjectExtensions.SetObjectActive(isactive: (currentWeapon.special.Level & 2) != 0, gameobject: skins["rightweaponeffect2"].gameObject);
	}
}
