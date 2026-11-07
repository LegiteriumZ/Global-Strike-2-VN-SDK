using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class HeroBladeSceneRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		int level = entity.sceneWeapon.Current.Level;
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(entity);
		SetSkinVisible(skins, "weaponeffect21", (level & 2) > 0);
		SetSkinVisible(skins, "weaponeffect22", (level & 8) > 0);
		SetSkinVisible(skins, "weaponeffect23", (level & 0x20) > 0);
		SetSkinVisible(skins, "weaponeffect24", (level & 0x80) > 0);
		SetSkinVisible(skins, "weaponeffect25", (level & 0x200) > 0);
		SetSkinVisible(skins, "weaponeffect26", (level & 0x800) > 0);
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(entity, Func);
	}

	private int GetEffect1Flag(SceneObjectEntity entity, string skin, string particle)
	{
		int level = entity.sceneWeapon.Current.Level;
		if (skin == "weapon_particle_effect")
		{
			if ((level & 0x2000) > 0)
			{
				return 1;
			}
			return 0;
		}
		if (skin == "weapon_particle_effect1")
		{
			if ((level & 0x8000) > 0)
			{
				return 1;
			}
			return 0;
		}
		return -1;
	}
}
