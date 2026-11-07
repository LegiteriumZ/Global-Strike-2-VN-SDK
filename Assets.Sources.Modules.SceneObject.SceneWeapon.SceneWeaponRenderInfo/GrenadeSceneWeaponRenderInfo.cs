using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;
using share;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class GrenadeSceneWeaponRenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdateRotate(SceneObjectEntity entity)
	{
		Vector3D vector3D = new Vector3D();
		if (entity.sceneWeapon.Current != null && entity.sceneWeapon.Next != null)
		{
			vector3D.x = entity.sceneWeapon.Next.X - entity.sceneWeapon.Current.X;
			vector3D.y = entity.sceneWeapon.Next.Y - entity.sceneWeapon.Current.Y;
			vector3D.z = entity.sceneWeapon.Next.Z - entity.sceneWeapon.Current.Z;
		}
		LoadResult loadResult = entity.unityObjects.LoadResults["WeaponModel"];
		Vector3D vector3D2 = VectorCoordConverter.UnityRotationToSsjj(loadResult.GameObject.transform.localEulerAngles);
		if (entity.sceneWeapon.Current != null)
		{
			Vector3 localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(new Vector3((float)(vector3D2.x + (double)(float)(vector3D.GetLength() / 90.0 / 2.0)), 0f, entity.sceneWeapon.Current.Yaw));
			loadResult.GameObject.transform.localEulerAngles = localEulerAngles;
		}
	}
}
