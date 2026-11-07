using Assets.Sources.Components.SceneObject;
using Assets.Sources.Utils;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class DetevctiveGrenadeRenderInfo : GrenadeSceneWeaponRenderInfo
{
	protected override void UpdateRotate(SceneObjectEntity entity)
	{
		if (entity.sceneWeapon.Current.Level == 0)
		{
			base.UpdateRotate(entity);
		}
		else
		{
			entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(new Vector3(entity.sceneWeapon.Current.Pitch - 90f, 0f, entity.sceneWeapon.Current.Yaw - 90f));
		}
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
		SetParticleVisalbeByName(entity, "jingbao", entity.sceneWeapon.Current.Level == 1);
		SetParticleVisalbeByName(entity, "attackjingbao", entity.sceneWeapon.Current.Level == 2);
	}
}
