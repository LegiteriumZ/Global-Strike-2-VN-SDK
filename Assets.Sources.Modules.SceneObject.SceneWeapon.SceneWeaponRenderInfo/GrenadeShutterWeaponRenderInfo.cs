using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class GrenadeShutterWeaponRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdateRotate(SceneObjectEntity entity)
	{
		entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(new Vector3(entity.sceneWeapon.Current.Pitch, 0f, entity.sceneWeapon.Current.Yaw));
	}
}
