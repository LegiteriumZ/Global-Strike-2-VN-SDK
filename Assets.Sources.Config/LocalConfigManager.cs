using System.Xml.Linq;
using UnityEngine;

namespace Assets.Sources.Config;

public class LocalConfigManager
{
	public static LocalConfigManager Instance = new LocalConfigManager();

	private string GetXmlConfigUrl(string configName)
	{
		return "file:///" + Application.dataPath + "/Templates/" + configName;
	}

	public XElement LoadXmlConfig(string configName)
	{
		return XElement.Load(GetXmlConfigUrl(configName));
	}
}
