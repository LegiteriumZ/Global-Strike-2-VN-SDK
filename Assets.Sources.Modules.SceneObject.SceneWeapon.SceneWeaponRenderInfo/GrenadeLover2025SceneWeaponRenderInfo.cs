using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class GrenadeLover2025SceneWeaponRenderInfo : GrenadeSceneWeaponRenderInfo
{
	protected override void UpdateRotate(SceneObjectEntity entity)
	{
		int level = entity.sceneWeapon.Current.Level;
		if (level != 0 && level != 4 && level != 5 && level != 6)
		{
			base.UpdateRotate(entity);
			return;
		}
		Vector3 localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(new Vector3(entity.orientation.Roll, entity.orientation.Pitch, entity.orientation.Yaw));
		entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.localEulerAngles = localEulerAngles;
		entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.Rotate(0f, 90f, 0f);
	}
}
