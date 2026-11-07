using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class M4A1Silence : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	private float _value;

	private const float _multiplier = 3000f;

	public override void Update(PlayerEntity player, int raceType)
	{
		BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if (skins != null)
		{
			_ = skins["weaponanchor"];
			if (_textureList == null)
			{
				_textureList = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponent<TextureList>();
			}
			if (_textureList != null && player.hasBasicInfo)
			{
				Material sharedMaterial = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterial;
				_value = (((player.basicInfo.Current.CurrentWeaponEffectLevel & 0x40) > 0 || (player.basicInfo.Current.CurrentWeaponEffectLevel & 0x80) > 0) ? (_value + (float)_timeContext.time.FrameInterval / 3000f) : (_value - (float)_timeContext.time.FrameInterval / 3000f));
				_value = ((_value > 1f) ? 1f : ((_value < 0f) ? 0f : _value));
				sharedMaterial.SetFloat("_DissolveAlpha", _value);
			}
		}
	}
}
