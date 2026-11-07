using System.Collections.Generic;
using System.Xml;
using NetData;

namespace Assets.Sources.Info.Weapon.Logic.SelfKillLogic;

internal class WeaponSelfKillInfoFactory
{
	private static WeaponSelfKillInfoFactory _instance;

	private ISelfKillInfoTemplate _peekAbooSelfKillTemplate = new PeekAbooSelfKillInfoTemplate();

	private ISelfKillInfoTemplate _normalSelfKillTemplate = new NormalWeaponSelfKillInfoTemplate();

	private ISelfKillInfoTemplate _skillSelfKillTemplate = new SkillSelfKillInfoTemplate();

	private Dictionary<string, ISelfKillInfoTemplate> _ikillInfoTemplates = new Dictionary<string, ISelfKillInfoTemplate>();

	public static WeaponSelfKillInfoFactory Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new WeaponSelfKillInfoFactory();
			}
			return _instance;
		}
	}

	public SelfKillTempData GetSelfKillTempData(string realWeaponName, KillPlayerInfoData killInfoData, int raceType, bool isWet, bool addDefault = true)
	{
		if (raceType == 25)
		{
			return _peekAbooSelfKillTemplate.GetSelfKillTempData(killInfoData, raceType, isWet);
		}
		if (_ikillInfoTemplates.ContainsKey(killInfoData.WeaponName))
		{
			return _ikillInfoTemplates[killInfoData.WeaponName].GetSelfKillTempData(killInfoData, raceType, isWet);
		}
		ISelfKillInfoTemplate defaultTemplate = GetDefaultTemplate(realWeaponName, killInfoData.WeaponName);
		if (addDefault)
		{
			_ikillInfoTemplates.Add(killInfoData.WeaponName, defaultTemplate);
		}
		return defaultTemplate.GetSelfKillTempData(killInfoData, raceType, isWet);
	}

	private ISelfKillInfoTemplate GetDefaultTemplate(string realWeaponName, string weaponName)
	{
		switch (weaponName)
		{
		case "thunder":
		case "thunder2":
		case "thunder3":
		case "thunder4":
		case "rpg_lssd":
			return _skillSelfKillTemplate;
		default:
			if (WeaponInfoFactory.Instance.GetWeaponInfo(weaponName) == null && _ikillInfoTemplates.ContainsKey(realWeaponName))
			{
				return _ikillInfoTemplates[realWeaponName];
			}
			return _normalSelfKillTemplate;
		}
	}

	public static ISelfKillInfoTemplate Parse(string xml)
	{
		ISelfKillInfoTemplate result = null;
		int num = 0;
		if (xml != null)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlNode documentElement = xmlDocument.DocumentElement;
			if (documentElement != null)
			{
				num = int.Parse(documentElement.Attributes["killType"].Value);
			}
		}
		switch (num)
		{
		case 0:
			result = new NormalWeaponSelfKillInfoTemplate();
			break;
		case 2:
			result = new GoldWeaponSelfKillInfoTemplate();
			break;
		case 1:
			result = new HeroWeaponSelfKillInfoTemplate(xml);
			break;
		case 4:
			result = new PeekAbooSelfKillInfoTemplate();
			break;
		case 5:
			result = new SkillSelfKillInfoTemplate();
			break;
		case 3:
			result = new DragonWeaponSelfKillInfoTemplate();
			break;
		}
		return result;
	}

	public ISelfKillInfoTemplate ParseSelfKillInfoConfig(string weapon, string xml)
	{
		if (_ikillInfoTemplates.ContainsKey(weapon))
		{
			return _ikillInfoTemplates[weapon];
		}
		return Parse(xml);
	}

	public void AddSelfKillInfoTemplate(string weapon, ISelfKillInfoTemplate template)
	{
		_ikillInfoTemplates[weapon] = template;
	}

	public ISelfKillInfoTemplate GetSelfKillInfoTemplate(string currentWeaponName)
	{
		if (_ikillInfoTemplates.ContainsKey(currentWeaponName))
		{
			return _ikillInfoTemplates[currentWeaponName];
		}
		return null;
	}
}
