using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class LightDarknessSubmachinegun : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	private float _value;

	private const float _multiplier = 3000f;

	public override void Update(PlayerEntity player, int raceType)
	{
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
			Material sharedMaterial = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterial;
			_value = (((player.basicInfo.Current.CurrentWeaponEffectLevel & 0x40) > 0) ? (_value + (float)_timeContext.time.FrameInterval / 3000f) : (_value - (float)_timeContext.time.FrameInterval / 3000f));
			_value = ((_value > 1f) ? 1f : ((_value < 0f) ? 0f : _value));
			if ((player.basicInfo.Current.CurrentWeaponEffectLevel & 0x40) > 0)
			{
				float value = _value + 0.5f;
				sharedMaterial.SetFloat("_DissolveAlpha", value);
			}
			else
			{
				sharedMaterial.SetFloat("_DissolveAlpha", _value);
			}
		}
	}
}
