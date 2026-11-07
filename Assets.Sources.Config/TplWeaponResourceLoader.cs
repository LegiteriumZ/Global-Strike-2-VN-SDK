using System.Collections.Generic;
using System.Xml.Linq;

namespace Assets.Sources.Config;

public class TplWeaponResourceLoader
{
	public static Dictionary<int, TplWeaponResource> LoadWeaponResourceInfoMap()
	{
		Dictionary<int, TplWeaponResource> dictionary = new Dictionary<int, TplWeaponResource>();
		foreach (XElement item in LocalConfigManager.Instance.LoadXmlConfig("tpl_weapon_resource.xml").Descendants("child"))
		{
			TplWeaponResource tplWeaponResource = new TplWeaponResource();
			tplWeaponResource.Id = int.Parse((string)item.Element("id"));
			tplWeaponResource.Name = (string)item.Element("name");
			tplWeaponResource.CodeName = (string)item.Element("codeName");
			tplWeaponResource.ThirdWeaponLayerIndex = int.Parse((string)item.Element("ThirdWeaponLayerIndex"));
			tplWeaponResource.ThirdWeaponLobbyPrefabeEnable = bool.Parse((string)item.Element("ThirdWeaponLobbyPrefabeEnable"));
			tplWeaponResource.ThirdWeaponAnimationDataName = (string)item.Element("ThirdWeaponAnimationDataName");
			tplWeaponResource.LobbyWeaponAnchorName = (string)item.Element("LobbyWeaponAnchorName");
			tplWeaponResource.WeaponAssetBundleName = (string)item.Element("WeaponAssetBundleName");
			tplWeaponResource.DefaultWeaponName = (string)item.Element("DefaultWeaponName");
			tplWeaponResource.WeaponOffset = (string)item.Element("WeaponOffset");
			tplWeaponResource.ThirdWeaponHitBack = int.Parse((string)item.Element("ThirdWeaponHitBack"));
			dictionary.Add(tplWeaponResource.Id, tplWeaponResource);
		}
		return dictionary;
	}
}
