using System.Collections.Generic;
using System.Xml;
using Assets.Sources.Utils;
using NetData;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Weapon.Logic.SelfKillLogic;

public class HeroWeaponSelfKillInfoTemplate : ISelfKillInfoTemplate
{
	private class HeroTextures
	{
		public string ImageName { get; set; }

		public int Lenght { get; set; }
	}

	private Dictionary<int, SelfKillTempData> _selfKillImageDic = new Dictionary<int, SelfKillTempData>();

	private Dictionary<int, HeroTextures> _selfKillTexturesTureDic = new Dictionary<int, HeroTextures>();

	public int GetSelfKillType()
	{
		return 1;
	}

	public HeroWeaponSelfKillInfoTemplate(string xml)
	{
		ParseXml(xml);
	}

	private void ParseXml(string xml)
	{
		_selfKillTexturesTureDic.Clear();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		XmlNode documentElement = xmlDocument.DocumentElement;
		if (documentElement == null)
		{
			return;
		}
		foreach (XmlNode item in documentElement)
		{
			bool specail = false;
			bool headShot = false;
			bool awake = false;
			bool knife = false;
			bool wall = false;
			int movieLenth = 8;
			if (item.Name.Equals("selfHeroKill"))
			{
				if (item.Attributes["special"] != null)
				{
					specail = bool.Parse(item.Attributes["special"].Value);
				}
				if (item.Attributes["headShot"] != null)
				{
					headShot = bool.Parse(item.Attributes["headShot"].Value);
				}
				if (item.Attributes["awake"] != null)
				{
					awake = bool.Parse(item.Attributes["awake"].Value);
				}
				if (item.Attributes["knife"] != null)
				{
					knife = bool.Parse(item.Attributes["knife"].Value);
				}
				if (item.Attributes["wallShot"] != null)
				{
					wall = bool.Parse(item.Attributes["wallShot"].Value);
				}
				if (item.Attributes["movieLenth"] != null)
				{
					movieLenth = int.Parse(item.Attributes["movieLenth"].Value);
				}
				string value = item.Attributes["imageName"].Value;
				AddSelfKillImage(specail, headShot, awake, knife, wall, movieLenth, value);
			}
		}
	}

	private void AddSelfKillImage(bool specail, bool headShot, bool awake, bool knife, bool wall, int movieLenth, string imageName)
	{
		int selfKillKey = GetSelfKillKey(specail, headShot, awake, knife, wall);
		if (!_selfKillTexturesTureDic.ContainsKey(selfKillKey))
		{
			_selfKillTexturesTureDic[selfKillKey] = new HeroTextures
			{
				ImageName = imageName,
				Lenght = movieLenth
			};
		}
	}

	public SelfKillTempData GetSelfKillTempData(KillPlayerInfoData killInfoData, int raceType, bool isWet)
	{
		int selfKillKey = GetSelfKillKey(killInfoData.SpecialAttack, killInfoData.Headshot, killInfoData.IsAwakenKill, killInfoData.WeaponType == 2, killInfoData.Wallshot);
		if (_selfKillImageDic.ContainsKey(selfKillKey))
		{
			return _selfKillImageDic[selfKillKey];
		}
		if (_selfKillImageDic.ContainsKey(0))
		{
			return _selfKillImageDic[0];
		}
		return null;
	}

	public List<AssetInfo> GetAllSelfKillAssets(string weapon, int weaponType, int raceType)
	{
		List<AssetInfo> list = new List<AssetInfo>();
		foreach (KeyValuePair<int, SelfKillTempData> item in _selfKillImageDic)
		{
			SelfKillTempData value = item.Value;
			list.AddRange(value.KillImage);
		}
		return list;
	}

	public void Init(string weapon)
	{
		_selfKillImageDic.Clear();
		foreach (KeyValuePair<int, HeroTextures> item in _selfKillTexturesTureDic)
		{
			int lenght = item.Value.Lenght;
			string imageName = item.Value.ImageName;
			SelfKillTempData selfKillTempData = new SelfKillTempData(lenght);
			for (int i = 0; i < selfKillTempData.KillImage.Length; i++)
			{
				selfKillTempData.KillImage[i] = UIResourceUtility.GetWeaponUISelfKillTextureName(weapon, string.Format("selfkill/{0}{1}", imageName, (selfKillTempData.KillImage.Length == 1) ? "" : string.Concat(i + 1)));
			}
			_selfKillImageDic[item.Key] = selfKillTempData;
		}
	}

	private static int GetSelfKillKey(bool special, bool headShot, bool awake, bool knife, bool wall)
	{
		int num = 0;
		if (special)
		{
			num += 2;
		}
		else if (wall)
		{
			if (headShot)
			{
				num += 4;
			}
			num += 32;
		}
		else if (headShot)
		{
			if (knife)
			{
				num += 16;
			}
			num += 4;
		}
		else if (awake)
		{
			num += 8;
		}
		else if (knife)
		{
			num += 16;
		}
		return num;
	}
}
