using Assets.Sources.Components.SceneObject;
using Assets.Sources.Utils;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class ElecticeGrenadeRenderInfo : GrenadeSceneWeaponRenderInfo
{
	protected override void UpdateRotate(SceneObjectEntity entity)
	{
		entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(new Vector3(entity.sceneWeapon.Current.Pitch + 90f, 180f, entity.sceneWeapon.Current.Yaw));
	}

	protected override void InitSound(SceneObjectEntity entity)
	{
		InitDummySound(entity);
	}

	protected override void UpdateSound(SceneObjectEntity entity)
	{
		ISoundPlayer source = entity.sound.Source;
		if (entity.sceneWeapon.Current.Level > 1)
		{
			AssetInfo weaponSoundNotifyAssetInfo = SoundResourceUtility.GetWeaponSoundNotifyAssetInfo(entity.sceneWeapon.Current.WeaponName);
			if (source.AssetInfo != weaponSoundNotifyAssetInfo)
			{
				source.PlaySound(weaponSoundNotifyAssetInfo, 1f, 2000, loop: true);
			}
		}
		else
		{
			source.StopSound();
		}
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		SetParticleVisalbeByName(entity, "dimian", entity.sceneWeapon.Current.Level == 1);
		SetParticleVisalbeByName(entity, "zhuizongtexiao", entity.sceneWeapon.Current.Level == 2);
	}
}
