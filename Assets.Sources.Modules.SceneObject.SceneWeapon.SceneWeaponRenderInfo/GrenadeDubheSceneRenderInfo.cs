using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class GrenadeDubheSceneRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		base.UpdatePaticle(entity);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(entity);
		bool flag = ((entity.hasSceneWeapon ? entity.sceneWeapon.Current.Level : 0) & 4) > 0;
		SetSkinVisible(skins, "weaponanchor", !flag);
	}
}
