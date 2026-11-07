using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class BloodKnife : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

	private UvHuxiEffect _uvHuxiEffect;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		Dictionary<IParticleKey, IPaticlePrefabInstancecs> particles = GetParticles(player);
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		if (skins.TryGetValue(new IgnoreCaseString("weaponanchor"), out var value))
		{
			if (_textureList == null)
			{
				_textureList = player.firstPersonUnityObjects.WeaponGameObject.GetComponent<TextureList>();
			}
			if (_uvHuxiEffect == null)
			{
				_uvHuxiEffect = value.GetComponent<UvHuxiEffect>();
			}
			if (_uvHuxiEffect != null && _textureList != null)
			{
				if (currentWeapon.special.SpecialMode)
				{
					if (_textureList.Textures.Length > 3)
					{
						_uvHuxiEffect.enabled = true;
						_uvHuxiEffect.Texture = _textureList.GetWeaponTextures(skinInfo)[3];
						value.sharedMaterial.mainTexture = _textureList.GetWeaponTextures(skinInfo)[1];
					}
				}
				else if (_textureList.Textures.Length > 2)
				{
					_uvHuxiEffect.Texture = _textureList.GetWeaponTextures(skinInfo)[2];
					_uvHuxiEffect.enabled = false;
					value.sharedMaterial.mainTexture = _textureList.GetWeaponTextures(skinInfo)[0];
				}
			}
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> item in particles)
		{
			item.Value.SetInsActive(currentWeapon.special.SpecialMode);
		}
	}
}
