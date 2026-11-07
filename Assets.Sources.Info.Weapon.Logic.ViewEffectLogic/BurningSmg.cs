using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class BurningSmg : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

	private float _value;

	private const float _multiplier = 1000f;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
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
			bool specialMode = currentWeapon.special.SpecialMode;
			int viewAnimId = player.GetViewAnimId();
			int viewAnimTimer = player.GetViewAnimTimer();
			bool flag = specialMode || (viewAnimId == 44 && viewAnimTimer <= 2100);
			if (viewAnimId == 44 && viewAnimTimer <= 500)
			{
				flag = false;
			}
			Material sharedMaterial = player.firstPersonUnityObjects.WeaponGameObject.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterial;
			_value = (flag ? (_value + ((float)_timeContext.time.FrameInterval + 0.33f) / 1000f) : (_value - (float)_timeContext.time.FrameInterval / 1600f));
			if (flag)
			{
				float value = _value + 0.33f;
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
