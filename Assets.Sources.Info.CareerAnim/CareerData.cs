using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Assets.Scripts;
using Assets.Sources.Utils.AssetManager;
using Assets.Sources.Utils.Weapon;
using SSJJAsset.Asset;
using SSJJAsset.AssetManager;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;
using careerConfigPackage;

namespace Assets.Sources.Info.CareerAnim;

public class CareerData
{
	private static Dictionary<string, string> _animConfig = new Dictionary<string, string>();

	private static Dictionary<int, Dictionary<string, HeroWeaponConfig>> _heroWeaponConfig;

	public static bool AnimationTypeConfigLoaded => _animConfig.Count > 0;

	public static HeroWeaponConfig GetWeaponConfig(int raceType, string weaponName)
	{
		if (!_heroWeaponConfig.TryGetValue(raceType, out var value))
		{
			value = _heroWeaponConfig[-1];
		}
		if (value.TryGetValue(weaponName, out var value2))
		{
			return value2;
		}
		return null;
	}

	public static IEnumerator LoadConfig()
	{
		yield return LoadAnimationTypeConfig();
		yield return LoadCareerConfig();
		yield return LoadHeroWeaponConfig();
	}

	private static IEnumerator LoadAnimationTypeConfig()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync(new AssetInfo("playeranim/default", "animConfig"));
		XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(loader.Result.text));
		while (xmlTextReader.Read())
		{
			if (xmlTextReader.Name == "career")
			{
				_animConfig.Add(xmlTextReader.GetAttribute("name"), xmlTextReader.GetAttribute("anim"));
			}
		}
		Resources.UnloadAsset(loader.Result);
	}

	public static string GetCareerAnimationType(string career)
	{
		if (_animConfig.TryGetValue(career, out var value))
		{
			return value;
		}
		return career;
	}

	private static IEnumerator LoadHeroWeaponConfig()
	{
		AssetInfo heroweaponconfig = new AssetInfo("weapon/default", "Assets/Res/Assets/weapon/heroWeaponConfig.xml", typeof(TextAsset), optional: true);
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(heroweaponconfig, BaseAsyncManager.Instance);
		yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(heroweaponconfig);
		TextAsset obj = SingletonInstance<AssetPool>.Instance.GetOrNull(heroweaponconfig) as TextAsset;
		_heroWeaponConfig = HeroWeaponPaser.ParseConfig(obj.text);
		Resources.UnloadAsset(obj);
		MonoBehaviourSingleton<GarbageDestoryer>.Instance.RemoveLinker(heroweaponconfig);
	}

	private static IEnumerator LoadCareerConfig()
	{
		AssetInfo playerCareerconfig = new AssetInfo("player/default", "Assets/Res/Assets/player/careerConfig.xml", typeof(TextAsset), optional: true);
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(playerCareerconfig, BaseAsyncManager.Instance);
		yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(playerCareerconfig);
		TextAsset textAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(playerCareerconfig) as TextAsset;
		CareerConfigManager.GetInstance().Init(textAsset.text);
		Resources.UnloadAsset(textAsset);
		MonoBehaviourSingleton<GarbageDestoryer>.Instance.RemoveLinker(playerCareerconfig);
	}

	public static void Clear()
	{
		_animConfig.Clear();
	}
}
