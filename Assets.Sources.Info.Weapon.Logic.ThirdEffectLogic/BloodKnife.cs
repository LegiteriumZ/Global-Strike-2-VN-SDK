using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class BloodKnife : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	private UvHuxiEffect _uvEffect;

	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		Dictionary<IParticleKey, IPaticlePrefabInstancecs> particles = GetParticles(player);
		if (skins.TryGetValue("weaponanchor", out var value))
		{
			if (_textureList == null)
			{
				_textureList = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponent<TextureList>();
			}
			WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
			if (_uvEffect == null)
			{
				_uvEffect = value.GetComponent<UvHuxiEffect>();
			}
			if (_uvEffect != null && _textureList != null)
			{
				_uvEffect.enabled = false;
				value.sharedMaterial.mainTexture = _textureList.GetWeaponTextures(skinInfo)[0];
			}
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> item in particles)
		{
			item.Value.SetInsActive(flag: false);
		}
	}
}
