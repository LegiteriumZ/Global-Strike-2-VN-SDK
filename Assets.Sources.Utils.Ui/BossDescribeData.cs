using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Assets.Sources.Free.Data;
using SSJJAsset.Asset;
using SSJJAsset.AssetManager;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Utils.Ui;

public class BossDescribeData : SingletonInstance<BossDescribeData>
{
	private class BossSkillData
	{
		public string name;

		public string title1;

		public string title2;

		public int height;
	}

	public static int BASE_HEIGHT = 484;

	public static int SKILLPAGE1_HEIGHT = 70;

	public static int SKILLPAGE2_HEIGHT = 51;

	private string codename;

	private string name = "";

	private long hp;

	private List<string> typeList;

	private List<int> hpTypeList;

	private List<int> resistanceList;

	private List<int> yinyangDunList;

	private List<int> extraordinaryCountList;

	private int extraordinaryValue;

	private List<BossSkillData> skillDataList;

	private float bossTipsHpRage;

	private int extraInfoBool;

	public string Codename => codename;

	public string Name => name;

	public long Hp => (long)((float)hp * bossTipsHpRage);

	public float BossTipsHpRage
	{
		set
		{
			if (value == 0f)
			{
				value = 1f;
			}
			bossTipsHpRage = value;
		}
	}

	public int ExtraInfoBool
	{
		set
		{
			extraInfoBool = value;
		}
	}

	public int ExtraordinaryValue => extraordinaryValue;

	public IEnumerator LoadConfig()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync(new AssetInfo("ui/halfloadedres/bossDescribe", Contexts.sharedInstance.battleRoom.roomData.Data.RaceType.ToString()));
		if (loader.Result != null)
		{
			string text = loader.Result.text;
			ParseConfig(text);
			Resources.UnloadAsset(loader.Result);
		}
	}

	private void ParseConfig(string xml)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		XmlNode documentElement = xmlDocument.DocumentElement;
		if (documentElement == null)
		{
			return;
		}
		foreach (XmlNode childNode in getBossLevelXxml(documentElement).ChildNodes)
		{
			parseBossBase(childNode);
			parseBossSkill(childNode);
		}
	}

	private XmlNode getBossLevelXxml(XmlNode root)
	{
		BattleModel gameModel = GameModelLocator.GetInstance().GameModel;
		XmlNode xmlNode = null;
		foreach (XmlNode childNode in root.ChildNodes)
		{
			if (childNode.Attributes["level"] == null)
			{
				break;
			}
			int num = int.Parse(childNode.Attributes["level"].Value);
			if (gameModel.RoomData.PveLevel == num)
			{
				return childNode;
			}
			if (num == 0)
			{
				xmlNode = childNode;
			}
		}
		if (xmlNode == null)
		{
			xmlNode = root.ChildNodes[0];
		}
		return xmlNode;
	}

	private void parseBossSkill(XmlNode xmlNode)
	{
		if (xmlNode.LocalName.Equals("bossSkill"))
		{
			if (skillDataList == null)
			{
				skillDataList = new List<BossSkillData>();
			}
			BossSkillData bossSkillData = new BossSkillData();
			bossSkillData.name = xmlNode.Attributes["name"].Value;
			bossSkillData.title1 = xmlNode.Attributes["title1"].Value;
			if (xmlNode.Attributes["title2"] != null)
			{
				bossSkillData.title2 = xmlNode.Attributes["title2"].Value;
				bossSkillData.height = SKILLPAGE1_HEIGHT;
			}
			else
			{
				bossSkillData.height = SKILLPAGE2_HEIGHT;
			}
			skillDataList.Add(bossSkillData);
		}
	}

	private void parseBossBase(XmlNode xmlNode)
	{
		if (xmlNode.LocalName.Equals("bossBase"))
		{
			codename = xmlNode.Attributes["codename"].Value;
			name = xmlNode.Attributes["name"].Value;
			hp = long.Parse(xmlNode.Attributes["hp"].Value);
			extraordinaryValue = int.Parse(xmlNode.Attributes["extraordinaryValue"].Value);
			typeList = parseStringList(xmlNode.Attributes["type"].Value);
			hpTypeList = parseIntList(xmlNode.Attributes["hpType"].Value);
			resistanceList = parseIntList(xmlNode.Attributes["resistance"].Value);
			yinyangDunList = parseIntList(xmlNode.Attributes["yinyangDun"].Value);
			extraordinaryCountList = parseIntList(xmlNode.Attributes["extraordinary"].Value);
		}
	}

	private List<string> parseStringList(string value)
	{
		List<string> list = new List<string>();
		if (string.IsNullOrEmpty(value))
		{
			return list;
		}
		string[] array = value.Split('|');
		for (int i = 0; i < array.Length; i++)
		{
			list.Add(array[i]);
		}
		return list;
	}

	private List<int> parseIntList(string value)
	{
		List<int> list = new List<int>();
		if (string.IsNullOrEmpty(value))
		{
			return list;
		}
		string[] array = value.Split('|');
		for (int i = 0; i < array.Length; i++)
		{
			list.Add(int.Parse(array[i]));
		}
		return list;
	}

	public bool hasBossDescribe()
	{
		return !string.IsNullOrEmpty(codename);
	}

	public bool hasBossType(int index)
	{
		if (!hasBossDescribe())
		{
			return false;
		}
		return typeList.Count > index;
	}

	public string getBossType(int index)
	{
		return typeList[index];
	}

	public bool isShowHpType(int index)
	{
		if (!hasBossDescribe())
		{
			return false;
		}
		return hpTypeList.Count > index;
	}

	public int getHpType(int index)
	{
		return hpTypeList[index];
	}

	public int getResistance(int index)
	{
		if (!hasBossDescribe())
		{
			return 0;
		}
		if (isOpenResistance(index))
		{
			return resistanceList[index];
		}
		return 0;
	}

	public int getBossSkillHeight(int count)
	{
		if (!hasBossDescribe())
		{
			return 0;
		}
		if (count == -1)
		{
			count = skillDataList.Count;
		}
		count = ((count < skillDataList.Count) ? count : skillDataList.Count);
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			BossSkillData bossSkillData = skillDataList[i];
			num += bossSkillData.height;
		}
		return num;
	}

	public bool hasBossSkill(int index)
	{
		return skillDataList.Count > index;
	}

	public bool hasBossSkillTitle2(int index)
	{
		if (skillDataList.Count > index)
		{
			return !string.IsNullOrEmpty(skillDataList[index].title2);
		}
		return false;
	}

	public string getSkillName(int index)
	{
		if (skillDataList.Count > index)
		{
			return skillDataList[index].name;
		}
		return "";
	}

	public string getSkillTitle1(int index)
	{
		if (skillDataList.Count > index)
		{
			return skillDataList[index].title1;
		}
		return "";
	}

	public string getSkillTitle2(int index)
	{
		if (skillDataList.Count > index)
		{
			return skillDataList[index].title2;
		}
		return "";
	}

	public int getYinyangDunType(int index)
	{
		if (!hasBossDescribe())
		{
			return 0;
		}
		if (hasExtraInfo(1))
		{
			return yinyangDunList[index];
		}
		return 0;
	}

	public int getExtraordinaryCount(int index)
	{
		if (!hasBossDescribe())
		{
			return 0;
		}
		if (hasExtraInfo(2))
		{
			return extraordinaryCountList[index];
		}
		return 0;
	}

	private bool isOpenResistance(int index)
	{
		return index switch
		{
			0 => hasExtraInfo(4), 
			1 => hasExtraInfo(8), 
			2 => hasExtraInfo(16), 
			3 => hasExtraInfo(32), 
			_ => false, 
		};
	}

	private bool hasExtraInfo(int bossDescribeType)
	{
		return (extraInfoBool & bossDescribeType) > 0;
	}
}
