using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class ThunderBoomRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		if (entity.hasSceneWeapon)
		{
			GameObject gameObject = entity.unityObjects.LoadResults["WeaponModel"].GameObject;
			if ((entity.sceneWeapon.Current.Level & 8) > 0)
			{
				gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
			}
			else
			{
				gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
			}
		}
	}
}
