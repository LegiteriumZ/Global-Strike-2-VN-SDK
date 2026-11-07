using System;
using System.Collections.Generic;
using Assets.Sources.Utils.Weapon;
using NetData;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

internal class InfiniteHand : AbstractThirdWeaponEffectLogic
{
	private const string WEAPON_EFFECT1 = "5_zhendangbo";

	private const string WEAPON_EFFECT2 = "7_tuci";

	private const string WEAPON_EFFECT3 = "01_you_shou";

	private const string WEAPON_EFFECT4 = "01_you_pao";

	private const string WEAPON_EFFECT5 = "01_zuo_shou";

	private const string WEAPON_EFFECT6 = "02_you";

	private const string WEAPON_EFFECT7 = "1_gedou_you03";

	private const string WEAPON_EFFECT8 = "03_zuo";

	protected Func<PlayerEntity, string, string, int> ZeroFunc;

	protected Func<PlayerEntity, string, string, int> FirstFunc;

	protected Func<PlayerEntity, string, string, int> SecondFunc;

	public override void Update(PlayerEntity player, int raceType)
	{
		if (player.hasBasicInfo && player.basicInfo.Current != null)
		{
			switch (player.basicInfo.Current.CurrentWeaponName)
			{
			case "infinite_hand1":
			case "infinite_hand2":
			case "infinite_hand3":
				UpdateZero(player, raceType, player.basicInfo.Current);
				break;
			case "infinite_hand1_change_1":
			case "infinite_hand2_change_1":
			case "infinite_hand3_change_1":
				UpdateFirst(player, raceType, player.basicInfo.Current);
				break;
			case "infinite_hand1_change_2":
			case "infinite_hand2_change_2":
			case "infinite_hand3_change_2":
				UpdateSecond(player, raceType, player.basicInfo.Current);
				break;
			}
		}
	}

	private void UpdateZero(PlayerEntity player, int raceType, PlayerEntityData data)
	{
		if (ZeroFunc == null)
		{
			ZeroFunc = SetZeroParticle;
		}
		SetParticleActiveBySkinName(player, ZeroFunc);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if ((data.CurrentWeaponEffectLevel & 2) > 0)
		{
			SetSkinVisible(skins, "weaponanchor", flag: false);
			SetSkinVisible(skins, "weaponanchor2", flag: true);
			SetSkinVisible(skins, "weaponanchor3", flag: true);
			SetParticleActiveBySkinName(player, "weapon_particle_fire_effect", FireUtility.IsFiring(player, isSelf: false));
			SetParticleActiveBySkinName(player, "weapon_left_particle_fire_effect", FireUtility.IsFiring(player, isSelf: false, right: false));
		}
		else
		{
			SetSkinVisible(skins, "weaponanchor", flag: true);
			SetSkinVisible(skins, "weaponanchor2", flag: true);
			SetSkinVisible(skins, "weaponanchor3", flag: false);
			SetParticleActiveBySkinName(player, "weapon_particle_fire_effect", flag: false);
			SetParticleActiveBySkinName(player, "weapon_left_particle_fire_effect", FireUtility.IsFiring(player, isSelf: false, right: false));
		}
	}

	private static int SetZeroParticle(PlayerEntity player, string skin, string particle)
	{
		int num = -1;
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		switch (particle)
		{
		case "1_xiandan_you":
		case "1_xiandan_zuo":
			return 0;
		case "01_you_pao":
			if ((currentWeaponEffectLevel & 2) > 0)
			{
				return 1;
			}
			return 0;
		default:
			return 1;
		}
	}

	private void UpdateFirst(PlayerEntity player, int raceType, PlayerEntityData data)
	{
		if (FirstFunc == null)
		{
			FirstFunc = SetFirstParticle;
		}
		SetParticleActiveBySkinName(player, FirstFunc);
		SetParticleActiveBySkinName(player, "weapon_left_particle_fire_effect", FireUtility.IsFiring(player, isSelf: false, right: false));
	}

	private static int SetFirstParticle(PlayerEntity player, string skin, string particle)
	{
		int num = -1;
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		switch (particle)
		{
		case "1_gedou_you01":
		case "1_gedou_you02":
		case "1_gedou_zuo":
			return 0;
		case "5_zhendangbo":
			if ((currentWeaponEffectLevel & 1) > 0)
			{
				return 1;
			}
			return 0;
		case "02_you_juexin":
			if ((currentWeaponEffectLevel & 2) > 0)
			{
				return 1;
			}
			return 0;
		case "7_tuci":
			if ((currentWeaponEffectLevel & 4) > 0)
			{
				return 1;
			}
			return 0;
		case "1_gedou_you03":
			if ((currentWeaponEffectLevel & 8) > 0)
			{
				return 1;
			}
			return 0;
		default:
			return 1;
		}
	}

	private void UpdateSecond(PlayerEntity player, int raceType, PlayerEntityData data)
	{
		if (SecondFunc == null)
		{
			SecondFunc = SetSecondParticle;
		}
		SetParticleActiveBySkinName(player, SecondFunc);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if ((data.CurrentWeaponEffectLevel & 2) > 0)
		{
			SetSkinVisible(skins, "weaponanchor", flag: false);
			SetSkinVisible(skins, "weaponanchor2", flag: false);
			SetSkinVisible(skins, "weaponanchor3", flag: true);
			SetParticleActiveBySkinName(player, "weapon_particle_fire_effect", FireUtility.IsFiring(player, isSelf: false));
			SetParticleActiveBySkinName(player, "weapon_left_particle_fire_effect", flag: false);
		}
		else
		{
			SetSkinVisible(skins, "weaponanchor", flag: true);
			SetSkinVisible(skins, "weaponanchor2", flag: true);
			SetSkinVisible(skins, "weaponanchor3", flag: false);
			SetParticleActiveBySkinName(player, "weapon_left_particle_fire_effect", FireUtility.IsFiring(player, isSelf: false, right: false));
			SetParticleActiveBySkinName(player, "weapon_particle_fire_effect", FireUtility.IsFiring(player, isSelf: false));
		}
	}

	private static int SetSecondParticle(PlayerEntity player, string skin, string particle)
	{
		int num = -1;
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		switch (particle)
		{
		case "1_zhongpao_you01":
		case "1_zhongpao_you02":
		case "1_zhongpao_zuo":
			return 0;
		case "03_you_juexin":
			if ((currentWeaponEffectLevel & 2) > 0)
			{
				return 1;
			}
			return 0;
		case "03_zuo":
			if ((currentWeaponEffectLevel & 2) > 0)
			{
				return 0;
			}
			return 1;
		default:
			return 1;
		}
	}
}
