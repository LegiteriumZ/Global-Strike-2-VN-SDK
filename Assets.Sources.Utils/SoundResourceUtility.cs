using Assets.Sources.Constant;
using Assets.Sources.Utils.Pool;
using Assets.Sources.Utils.Ui;
using SSJJAsset.Asset;

namespace Assets.Sources.Utils;

public class SoundResourceUtility
{
	public static AssetInfo GetWeaponSoundAssetInfo(string weapon, string suffix)
	{
		SimpleParams simpleParams = SimpleParams.Create(weapon, suffix);
		SimpleParams simpleParams2 = SimpleParams.Create(weapon);
		if (!AnimationNameCache.TryGet(simpleParams2, out var cachedata))
		{
			cachedata = $"sound/weapon/{weapon}";
			AnimationNameCache.Add(simpleParams2, cachedata);
		}
		else
		{
			simpleParams2.Release();
		}
		if (!AnimationNameCache.TryGet(simpleParams, out var cachedata2))
		{
			cachedata2 = $"Assets/Res/Assets/sound/weapon/{weapon}{suffix}.mp3";
			AnimationNameCache.Add(simpleParams, cachedata2);
		}
		else
		{
			simpleParams.Release();
		}
		return new AssetInfo(cachedata, cachedata2);
	}

	public static AssetInfo GetChickenFlySoundUrl()
	{
		return new AssetInfo("sound/chicken", "Assets/Res/Assets/sound/chicken/fly.mp3");
	}

	public static AssetInfo GetChickenLandSoundUrl()
	{
		return new AssetInfo("sound/chicken", "Assets/Res/Assets/sound/chicken/land.mp3");
	}

	public static AssetInfo GetCatSprintSoundUrl()
	{
		return new AssetInfo("sound/cat", "Assets/Res/Assets/sound/cat/sprint.mp3");
	}

	public static AssetInfo GetCatStopSoundUrl()
	{
		return new AssetInfo("sound/cat", "Assets/Res/Assets/sound/cat/stop.mp3");
	}

	public static AssetInfo GetPigJumpLandSoundUrl()
	{
		return new AssetInfo("sound/pig", "Assets/Res/Assets/sound/pig/jumpland.mp3");
	}

	public static AssetInfo GetPigJumpSoundUrl()
	{
		return new AssetInfo("sound/pig", "Assets/Res/Assets/sound/pig/jump.mp3");
	}

	public static AssetInfo GetWeaponSoundFireAssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "_fire");
	}

	public static AssetInfo GetWeaponSoundSecFireAssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "_sec_fire");
	}

	public static AssetInfo GetWeaponSoundFire3AssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "_fire3");
	}

	public static AssetInfo GetWeaponSoundFire4AssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "_fire4");
	}

	public static AssetInfo GetWeaponSoundChangeAssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "_change");
	}

	public static AssetInfo GetWeaponSoundChange2AssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "_change2");
	}

	public static AssetInfo GetWeaponSoundReloadAssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "_reload");
	}

	public static AssetInfo GetWeaponSoundReload2AssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "_reload2");
	}

	public static AssetInfo GetWeaponSoundRaiseAssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "_raise");
	}

	public static AssetInfo GetWeaponSoundRaise2AssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "_raise2");
	}

	public static AssetInfo GetWeaponSoundSkillAssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "_skill");
	}

	public static AssetInfo GetWeaponSoundSkill2AssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "_skill2");
	}

	public static AssetInfo GetWeaponSoundNotifyAssetInfo(string weapon)
	{
		return GetWeaponSoundAssetInfo(weapon, "");
	}

	public static AssetInfo GetPlayerStepOnLadder()
	{
		return new AssetInfo("sound/player", "Assets/Res/Assets/sound/player/pl_ladder.mp3");
	}

	public static AssetInfo GetPlayerStepDefault()
	{
		return new AssetInfo("sound/player", "Assets/Res/Assets/sound/player/pl_step.mp3");
	}

	public static AssetInfo GetPlayerStepForIndex(int index)
	{
		return new AssetInfo("sound/player", "Assets/Res/Assets/sound/player/pl_step" + index + ".mp3");
	}

	public static AssetInfo GetPlayerStepCareer(string career)
	{
		return new AssetInfo("sound/player", $"Assets/Res/Assets/sound/player/pl_step_{career}.mp3");
	}

	public static AssetInfo GetNpcSound(string soundName)
	{
		return new AssetInfo("sound/npcsound", $"Assets/Res/Assets/sound/npcsound/{soundName}.mp3");
	}

	public static AssetInfo GetSceneSound(string soundName)
	{
		return new AssetInfo("sound/scenesound", $"Assets/Res/Assets/sound/scenesound/{soundName}.mp3");
	}

	public static AssetInfo GetSoundUrl(int rule, string soundName)
	{
		string soundModelUrl = GetSoundModelUrl(rule);
		return new AssetInfo($"sound/{soundModelUrl}", $"Assets/Res/Assets/sound/{soundModelUrl}/{soundName}.mp3");
	}

	public static AssetInfo GetPveCommonSoundUrl(string soundName)
	{
		return new AssetInfo("sound/pvecommon", $"Assets/Res/Assets/sound/pvecommon/{soundName}.mp3");
	}

	public static AssetInfo GetCommonSoundUrl(string soundName)
	{
		return new AssetInfo("sound/common", $"Assets/Res/Assets/sound/common/{soundName}.mp3");
	}

	private static string GetSoundModelUrl(int rule)
	{
		if (RuleUtilty.IsExplode(rule))
		{
			return "explodesound";
		}
		if (25 == rule)
		{
			return "peekaboosound";
		}
		if (1001 == rule)
		{
			return "towerdefense";
		}
		if (1002 == rule)
		{
			return "titanlaboratory";
		}
		if (1004 == rule)
		{
			return "losttemple";
		}
		if (29 == rule)
		{
			return "mechsound";
		}
		if (31 == rule)
		{
			return "biomechsound";
		}
		if (33 == rule)
		{
			return "bio2sound";
		}
		if (39 == rule)
		{
			return "intelligencesound";
		}
		if (25 == rule)
		{
			return "peekaboosound";
		}
		return "common";
	}
}
