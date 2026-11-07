using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class CybertronBeast : AbstractThirdWeaponEffectLogic
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
			IPaticlePrefabInstancecs paticleBySkinName = GetPaticleBySkinName(player, "weapon_particle_fire_effect");
			if (Contexts.sharedInstance.gameRule.currentRule.Rule.IsBighead() || Contexts.sharedInstance.gameRule.currentRule.Rule.IsExplode() || RuleUtilty.IsGroupModel(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
			{
				paticleBySkinName?.SetInsScale(0.3f);
			}
			else
			{
				paticleBySkinName?.SetInsScale(1f);
			}
			_ = skins["weaponanchor"];
			if (_textureList == null)
			{
				_textureList = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponent<TextureList>();
			}
			if (_textureList != null && player.hasBasicInfo)
			{
				Material sharedMaterial = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterial;
				_value = (((player.basicInfo.Current.CurrentWeaponEffectLevel & 0x20) > 0) ? (_value + (float)_timeContext.time.FrameInterval / 3000f) : (_value - (float)_timeContext.time.FrameInterval / 3000f));
				_value = ((_value > 1f) ? 1f : ((_value < 0f) ? 0f : _value));
				sharedMaterial.SetFloat("_DissolveAlpha", _value);
			}
		}
	}
}
