using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.CsvLoader;
using Assets.Sources.Utils.Weapon;
using NetData;
using SSJJBase.Singleton;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class ShotgunPistolStoneRenderInfo : AbstractSceneWeaponInfo
{
	private TextureList _textureList;

	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void InitMaterial(SceneObjectEntity entity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults["WeaponModel"].GameObject;
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> dictionary = new Dictionary<IgnoreCaseString, SkinnedMeshRenderer>();
		WeaponUtility.GetSkins(gameObject, dictionary);
		SkinnedMeshRenderer skinnedMeshRenderer = dictionary["weaponanchor"];
		if (_textureList == null)
		{
			_textureList = gameObject.GetComponent<TextureList>();
		}
		if (_textureList != null)
		{
			skinnedMeshRenderer.materials[0].mainTexture = _textureList.GetWeaponEffectTextures()[0];
			skinnedMeshRenderer.materials[1].mainTexture = _textureList.GetWeaponEffectTextures()[2];
		}
		SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		WeaponColorData weaponColorData = entity.sceneWeapon.Current.WeaponColorData;
		if (weaponColorData != null)
		{
			WeaponUtility.SetWeaponColor(weaponColorData, componentsInChildren);
		}
		else
		{
			WeaponUtility.SetWeaponColor(SingletonInstance<WeaponSkinColorLoader>.Instance.DefaultWeaponColorData, componentsInChildren);
		}
	}
}
