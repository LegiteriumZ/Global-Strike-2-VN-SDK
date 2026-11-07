using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class LightDarknessSubmachinegun : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

	private float _value;

	private const float _multiplier = 3000f;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
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
			_textureList = player.firstPersonUnityObjects.WeaponGameObject.GetComponent<TextureList>();
		}
		if (_textureList != null)
		{
			Material sharedMaterial = player.firstPersonUnityObjects.WeaponGameObject.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterial;
			_value = (((currentWeapon.special.EffectLevel & 0x40) > 0) ? (_value + ((float)_timeContext.time.FrameInterval + 0.5f) / 3000f) : (_value - (float)_timeContext.time.FrameInterval / 3000f));
			if ((currentWeapon.special.EffectLevel & 0x40) > 0)
			{
				float value = _value + 0.5f;
				sharedMaterial.SetFloat("_DissolveAlpha", value);
			}
			else
			{
				_value = ((_value > 1f) ? 1f : ((_value < 0f) ? 0f : _value));
				sharedMaterial.SetFloat("_DissolveAlpha", _value);
			}
		}
	}
}
