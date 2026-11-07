using System.Collections;
using System.Collections.Generic;
using System.Xml;
using SSJJAsset.AssetManager;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Scripts.Utility.Sound;

public class AutoSoundLoader : MonoBehaviourSingleton<AutoSoundLoader>
{
	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("sound/autosound", "autoSoundConfig");
		string text = loader.Result.text;
		LoadAutoSoundData(text);
	}

	public List<string> ParseStrList(string data)
	{
		string[] array = data.Split(',');
		List<string> list = new List<string>();
		if (string.IsNullOrEmpty(data))
		{
			return list;
		}
		for (int i = 0; i < array.Length; i++)
		{
			list.Add(array[i]);
		}
		return list;
	}

	public List<int> ParseIntList(string data)
	{
		string[] array = data.Split(',');
		List<int> list = new List<int>();
		if (string.IsNullOrEmpty(data))
		{
			return list;
		}
		for (int i = 0; i < array.Length; i++)
		{
			list.Add(int.Parse(array[i]));
		}
		return list;
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
			AutoSoundEventConfig autoSoundEventConfig = new AutoSoundEventConfig
			{
				EventType = item.Read("eventType"),
				CanClose = (int.Parse(item.Read("canClose")) == 1),
				EventPriority = int.Parse(item.Read("eventPriority")),
				Probability = int.Parse(item.Read("probability")),
				SoundItems = new List<AutoSoundItemConfig>()
			};
			MonoBehaviourSingleton<AutoSoundManager>.Instance.AutoConfigs.Add(autoSoundEventConfig);
			foreach (XmlNode childNode in item.ChildNodes)
			{
				AutoSoundItemConfig autoSoundItemConfig = new AutoSoundItemConfig
				{
					CdTime = int.Parse(childNode.Read("cdTime")),
					CodeName = int.Parse(childNode.Read("codeName")),
					SoundUrl = childNode.Read("soundUrl"),
					RuleTypeList = ParseIntList(childNode.Read("ruleTypeList")),
					AllRule = (int.Parse(childNode.Read("allRule")) == 1),
					AllPvpRule = (int.Parse(childNode.Read("allPvpRule")) == 1),
					AllPveRule = (int.Parse(childNode.Read("allPveRule")) == 1),
					AllRpgRule = (int.Parse(childNode.Read("allRpgRule")) == 1),
					AllBioRule = (int.Parse(childNode.Read("allBioRule")) == 1),
					AllExplodRule = (int.Parse(childNode.Read("allExplodRule")) == 1),
					CareerList = ParseStrList(childNode.Read("careerList")),
					AllHumanity = (int.Parse(childNode.Read("allHumanity")) == 1),
					AllDoun = (int.Parse(childNode.Read("allDoun")) == 1),
					IsMan = int.Parse(childNode.Read("isMan")),
					IsDefault = (int.Parse(childNode.Read("isDefault")) == 1),
					SoundPriority = int.Parse(childNode.Read("soundPriority")),
					Cankill = (int.Parse(childNode.Read("cankill")) == 1),
					CanUse = (int.Parse(childNode.Read("canUse")) == 1),
					FreeCondition = childNode.Read("freeCondition")
				};
				autoSoundItemConfig.Init();
				autoSoundEventConfig.SoundItems.Add(autoSoundItemConfig);
			}
		}
	}
}
