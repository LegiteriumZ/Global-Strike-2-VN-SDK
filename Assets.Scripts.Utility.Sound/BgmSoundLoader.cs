using System;
using System.Collections;
using System.Xml;
using SSJJAsset.AssetManager;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Scripts.Utility.Sound;

public class BgmSoundLoader : MonoBehaviourSingleton<BgmSoundLoader>
{
	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("sound/bgm", "bgmSoundConfig");
		string text = loader.Result.text;
		LoadAutoSoundData(text);
	}

	public void LoadAutoSoundData(string xmlData)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xmlData);
		XmlElement documentElement = xmlDocument.DocumentElement;
		if (documentElement == null)
		{
			return;
		}
		foreach (XmlNode item in documentElement)
		{
			try
			{
				BgmSoundSoundConfig bgmSoundSoundConfig = new BgmSoundSoundConfig
				{
					CdTime = int.Parse(item.Read("cdTime")),
					SoundUrl = item.Read("soundUrl"),
					FreeCondition = item.Read("freeCondition"),
					Loop = (int.Parse(item.Read("loop")) == 1)
				};
				if (item.Read("vol") != "")
				{
					bgmSoundSoundConfig.vol = float.Parse(item.Read("vol"));
				}
				else
				{
					bgmSoundSoundConfig.vol = 1f;
				}
				bgmSoundSoundConfig.parseRuleTypeList(item.Read("raceTypeList"));
				bgmSoundSoundConfig.Init();
				MonoBehaviourSingleton<BgmSoundManager>.Instance.soundConfigs.Add(bgmSoundSoundConfig);
			}
			catch (Exception ex)
			{
				Debug.LogWarning(ex.StackTrace);
			}
		}
	}
}
