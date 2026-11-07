using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class BurningSmg : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	private float _value;

	private const float _multiplier = 1000f;

	public override void Update(PlayerEntity player, int raceType)
	{
		BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if (skins == null)
		{
			return;
		}
		_ = skins["weaponanchor"];
		if (_textureList == null)
		{
			_textureList = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponent<TextureList>();
		}
		if (_textureList != null)
		{
			bool flag = (player.basicInfo.Current.CurrentWeaponEffectLevel & 0x200) > 0;
			Material sharedMaterial = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterial;
			_value = (flag ? (_value + (float)_timeContext.time.FrameInterval / 1000f) : (_value - (float)_timeContext.time.FrameInterval / 1000f));
			_value = ((_value > 1f) ? 1f : ((_value < 0f) ? 0f : _value));
			if (flag)
			{
				float value = _value;
				sharedMaterial.SetFloat("_DissolveAlpha", value);
			}
			else
			{
				sharedMaterial.SetFloat("_DissolveAlpha", _value);
			}
		}
	}
}
