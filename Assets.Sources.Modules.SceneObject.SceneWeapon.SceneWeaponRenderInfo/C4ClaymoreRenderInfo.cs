using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class C4ClaymoreRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		SetParticleVisalbeByName(entity, "jiguang_180", flag: true);
	}

	protected override void UpdateRotate(SceneObjectEntity entity)
	{
		entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(new Vector3(0f, 0f, entity.sceneWeapon.Current.Yaw));
	}
}
