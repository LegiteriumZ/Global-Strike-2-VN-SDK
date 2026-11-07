using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect;
using SSJJAsset.AssetManager;
using SSJJBase.Extensions;
using SSJJBase.Manager;
using Sharpen;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class EffectConfigLoader : IConfigLoader
{
	private class HalfEffectConfig
	{
		public int Id;

		public string Path;

		public int Count;
	}

	public static EffectConfigLoader Instance = new EffectConfigLoader();

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("effect/other", "EffectConfig");
		string text = loader.Result.text;
		Load(text);
		LoadHalfEffect();
	}

	public void LoadPlayerTextures(string playerName, string data)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(data);
		XmlNodeList childNodes = xmlDocument.SelectSingleNode("effectConfig").ChildNodes;
		Dictionary<int, List<EffectTexture>> dictionary = new Dictionary<int, List<EffectTexture>>();
		foreach (XmlNode item in childNodes)
		{
			if (!(item.Name == "EffectTexture"))
			{
				continue;
			}
			int ruleModel = Convert.ToInt32(item.Attributes["ruleModel"].Value);
			int weights = Convert.ToInt32(item.Attributes["weights"].Value);
			int num = Convert.ToInt32(item.Attributes["resID"].Value);
			List<EffectTexture> list = dictionary.GetOrDefault(num);
			if (list == null)
			{
				list = new List<EffectTexture>();
				dictionary.Add(num, list);
			}
			foreach (XmlNode childNode in item.ChildNodes)
			{
				int index = Convert.ToInt32(childNode.Attributes["index"].Value);
				string value = childNode.Attributes["name"].Value;
				list.Add(new EffectTexture
				{
					Index = index,
					Name = "/player/" + playerName + "/effect" + value,
					ResId = num,
					RuleModel = ruleModel,
					Weights = weights,
					Type = TextureType.Player,
					SubName = playerName
				});
			}
		}
		foreach (KeyValuePair<int, List<EffectTexture>> item2 in dictionary)
		{
			List<EffectTexture> textures = item2.Value.OrderBy((EffectTexture x) => x.Index).ToList();
			BattleSingletonInstance<EffectConfigFactory>.Instance.AddEffectTextures(TextureType.Player, new EffectTextureList(item2.Key, textures));
		}
	}

	public void LoadHalfEffect()
	{
		AList<HalfEffectConfig> obj = new AList<HalfEffectConfig>
		{
			new HalfEffectConfig
			{
				Id = 0,
				Path = EffectResIdConstant.GetResidToFileName(0),
				Count = 20
			},
			new HalfEffectConfig
			{
				Id = 1,
				Path = EffectResIdConstant.GetResidToFileName(1),
				Count = 33
			},
			new HalfEffectConfig
			{
				Id = 2,
				Path = EffectResIdConstant.GetResidToFileName(2),
				Count = 15
			},
			new HalfEffectConfig
			{
				Id = 3,
				Path = EffectResIdConstant.GetResidToFileName(3),
				Count = 11
			},
			new HalfEffectConfig
			{
				Id = 4,
				Path = EffectResIdConstant.GetResidToFileName(4),
				Count = 15
			},
			new HalfEffectConfig
			{
				Id = 5,
				Path = EffectResIdConstant.GetResidToFileName(5),
				Count = 31
			},
			new HalfEffectConfig
			{
				Id = 6,
				Path = EffectResIdConstant.GetResidToFileName(6),
				Count = 15
			},
			new HalfEffectConfig
			{
				Id = 7,
				Path = EffectResIdConstant.GetResidToFileName(7),
				Count = 15
			},
			new HalfEffectConfig
			{
				Id = 10,
				Path = EffectResIdConstant.GetResidToFileName(10),
				Count = 13
			},
			new HalfEffectConfig
			{
				Id = 9,
				Path = EffectResIdConstant.GetResidToFileName(9),
				Count = 13
			},
			new HalfEffectConfig
			{
				Id = 11,
				Path = EffectResIdConstant.GetResidToFileName(11),
				Count = 15
			},
			new HalfEffectConfig
			{
				Id = 13,
				Path = EffectResIdConstant.GetResidToFileName(13),
				Count = 11
			},
			new HalfEffectConfig
			{
				Id = 14,
				Path = EffectResIdConstant.GetResidToFileName(14),
				Count = 24
			},
			new HalfEffectConfig
			{
				Id = 15,
				Path = EffectResIdConstant.GetResidToFileName(15),
				Count = 8
			},
			new HalfEffectConfig
			{
				Id = 16,
				Path = EffectResIdConstant.GetResidToFileName(16),
				Count = 15
			},
			new HalfEffectConfig
			{
				Id = 6,
				Path = EffectResIdConstant.GetResidToFileName(6),
				Count = 20
			},
			new HalfEffectConfig
			{
				Id = 18,
				Path = EffectResIdConstant.GetResidToFileName(18),
				Count = 12
			},
			new HalfEffectConfig
			{
				Id = 19,
				Path = EffectResIdConstant.GetResidToFileName(19),
				Count = 7
			},
			new HalfEffectConfig
			{
				Id = 8,
				Path = EffectResIdConstant.GetResidToFileName(8),
				Count = 14
			},
			new HalfEffectConfig
			{
				Id = 17,
				Path = EffectResIdConstant.GetResidToFileName(17),
				Count = 20
			}
		};
		Dictionary<int, List<EffectTexture>> dictionary = new Dictionary<int, List<EffectTexture>>();
		foreach (HalfEffectConfig item in obj)
		{
			List<EffectTexture> list = dictionary.GetOrDefault(item.Id);
			if (list == null)
			{
				list = new List<EffectTexture>();
				dictionary.Add(item.Id, list);
			}
			for (int i = 0; i < item.Count; i++)
			{
				list.Add(new EffectTexture
				{
					Index = i,
					Name = "/effect/halfloadeffect/" + item.Path + "/" + i + ".png",
					ResId = item.Id,
					RuleModel = -1,
					Weights = 0,
					Type = TextureType.Half,
					SubName = item.Path
				});
			}
		}
		foreach (KeyValuePair<int, List<EffectTexture>> item2 in dictionary)
		{
			List<EffectTexture> textures = item2.Value.OrderBy((EffectTexture x) => x.Index).ToList();
			BattleSingletonInstance<EffectConfigFactory>.Instance.AddEffectTextures(TextureType.Half, new EffectTextureList(item2.Key, textures));
		}
	}

	public void LoadWeaponTextures(string playerName, string data)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(data);
		XmlNodeList childNodes = xmlDocument.SelectSingleNode("effectConfig").ChildNodes;
		Dictionary<int, List<EffectTexture>> dictionary = new Dictionary<int, List<EffectTexture>>();
		foreach (XmlNode item in childNodes)
		{
			if (!(item.Name == "EffectTexture"))
			{
				continue;
			}
			int ruleModel = Convert.ToInt32(item.Attributes["ruleModel"].Value);
			int weights = Convert.ToInt32(item.Attributes["weights"].Value);
			int num = Convert.ToInt32(item.Attributes["resID"].Value);
			List<EffectTexture> list = dictionary.GetOrDefault(num);
			if (list == null)
			{
				list = new List<EffectTexture>();
				dictionary.Add(num, list);
			}
			foreach (XmlNode childNode in item.ChildNodes)
			{
				int index = Convert.ToInt32(childNode.Attributes["index"].Value);
				string value = childNode.Attributes["name"].Value;
				list.Add(new EffectTexture
				{
					Index = index,
					Name = "/weapon/" + playerName + "/effect" + value,
					ResId = num,
					RuleModel = ruleModel,
					Weights = weights,
					Type = TextureType.Weapon,
					SubName = playerName
				});
			}
		}
		foreach (KeyValuePair<int, List<EffectTexture>> item2 in dictionary)
		{
			List<EffectTexture> textures = item2.Value.OrderBy((EffectTexture x) => x.Index).ToList();
			BattleSingletonInstance<EffectConfigFactory>.Instance.AddEffectTextures(TextureType.Weapon, new EffectTextureList(item2.Key, textures));
		}
	}

	public HashSet<string> GetEffectSubPath(HashSet<int> ruleModes)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (EffectTexture allEffect in BattleSingletonInstance<EffectConfigFactory>.Instance.GetAllEffectList(TextureType.Effect))
		{
			int length = allEffect.Name.IndexOf("/", "/effect/".Length, StringComparison.Ordinal);
			string item = allEffect.Name.Substring(0, length).Substring("/effect/".Length).ToLower();
			if (ruleModes.Contains(allEffect.RuleModel) && !hashSet.Contains(item))
			{
				hashSet.Add(item);
			}
		}
		return hashSet;
	}

	public void Load(string data)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(data);
		XmlNodeList childNodes = xmlDocument.SelectSingleNode("effectConfig").ChildNodes;
		Dictionary<int, List<EffectTexture>> dictionary = new Dictionary<int, List<EffectTexture>>();
		foreach (XmlNode item in childNodes)
		{
			if (item.Name == "EffectTexture")
			{
				XmlAttributeCollection attributes = item.Attributes;
				string value = attributes["name"].Value;
				int index = Convert.ToInt32(attributes["index"].Value);
				int num = Convert.ToInt32(attributes["resID"].Value);
				int ruleModel = Convert.ToInt32(attributes["ruleModel"].Value);
				int weights = Convert.ToInt32(attributes["weights"].Value);
				List<EffectTexture> list = dictionary.GetOrDefault(num);
				if (list == null)
				{
					list = new List<EffectTexture>();
					dictionary.Add(num, list);
				}
				list.Add(new EffectTexture
				{
					Index = index,
					Name = value,
					ResId = num,
					RuleModel = ruleModel,
					Weights = weights,
					Type = TextureType.Effect,
					SubName = ""
				});
			}
		}
		foreach (KeyValuePair<int, List<EffectTexture>> item2 in dictionary)
		{
			List<EffectTexture> textures = item2.Value.OrderBy((EffectTexture x) => x.Index).ToList();
			BattleSingletonInstance<EffectConfigFactory>.Instance.AddEffectTextures(TextureType.Effect, new EffectTextureList(item2.Key, textures));
		}
	}
}
