using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class BloodM1887 : AbstractViewWeaponEffectLogic
{
	private bool _special;

	private float _frameTime = 2.4f;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (!string.IsNullOrEmpty(player.currentWeapon.SkinName))
		{
			return;
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			particle.Value.SetInsActive(currentWeapon.special.SpecialMode & !_special);
		}
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponeffect4"].gameObject.SetObjectActive(currentWeapon.special.SpecialMode & !_special);
		skins["weaponeffect2"].gameObject.SetObjectActive(!currentWeapon.special.SpecialMode);
		if (currentWeapon.special.SpecialMode & !_special)
		{
			_frameTime -= Time.deltaTime;
			if (_frameTime < 0f)
			{
				_special = true;
			}
		}
	}
}
