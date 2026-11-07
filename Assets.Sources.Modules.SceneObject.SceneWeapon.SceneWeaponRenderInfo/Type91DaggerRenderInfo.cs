using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class Type91DaggerRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(entity);
		SetSkinVisible(skins, "weaponeffect", flag: false);
	}
}
