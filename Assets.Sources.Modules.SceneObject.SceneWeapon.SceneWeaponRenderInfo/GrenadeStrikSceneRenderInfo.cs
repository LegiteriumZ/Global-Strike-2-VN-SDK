using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class GrenadeStrikSceneRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		base.UpdatePaticle(entity);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(entity);
		int num = (entity.hasSceneWeapon ? entity.sceneWeapon.Current.Level : 0);
		SetSkinVisible(skins, "weaponeffect21", (num & 2) > 0);
		SetSkinVisible(skins, "weaponeffect22", (num & 8) > 0);
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(entity, Func);
	}

	private int GetEffect1Flag(SceneObjectEntity entity, string skin, string particle)
	{
		int num = (entity.hasSceneWeapon ? entity.sceneWeapon.Current.Level : 0);
		if ((num & 2) > 0 && (num & 8) > 0)
		{
			if (particle == "qiangxi_wuqi_quanzhuang")
			{
				return 1;
			}
			return 0;
		}
		if ((num & 8) > 0)
		{
			if (particle == "qiangxi_wuqi_shanguang")
			{
				return 1;
			}
			return 0;
		}
		if ((num & 2) > 0)
		{
			if (particle == "qiangxi_wuqi_yanshi")
			{
				return 1;
			}
			return 0;
		}
		if (particle == "qiangxi_wuqi")
		{
			return 1;
		}
		return 0;
	}
}
