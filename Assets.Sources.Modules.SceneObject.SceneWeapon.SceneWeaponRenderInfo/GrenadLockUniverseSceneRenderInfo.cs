using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class GrenadLockUniverseSceneRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		base.UpdatePaticle(entity);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(entity);
		int num = (entity.hasSceneWeapon ? entity.sceneWeapon.Current.Level : 0);
		SetSkinVisible(skins, "weaponeffect21", (num & 4) > 0);
	}
}
