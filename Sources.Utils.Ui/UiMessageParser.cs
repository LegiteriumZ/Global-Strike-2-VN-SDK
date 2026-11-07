using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Assets.Generated.Table;
using Assets.Sources.CsvLoader;
using SSJJAsset.Asset;
using SSJJAsset.AssetManager;
using SSJJBase.Singleton;
using UnityEngine;

namespace Sources.Utils.Ui;

public class UiMessageParser : SingletonInstance<UiMessageParser>
{
	private Dictionary<int, UiMessageConfig> _dictionary = new Dictionary<int, UiMessageConfig>();

	public UiMessageConfig GetMessageConfig(int eventId)
	{
		if (_dictionary == null)
		{
			return null;
		}
		if (_dictionary.ContainsKey(eventId))
		{
			return _dictionary[eventId];
		}
		return null;
	}

	public IEnumerator LoadConfig()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync(new AssetInfo("ui/common", "localText"));
		if (loader.Result != null)
		{
			string text = loader.Result.text;
			_dictionary = ParseConfig(text);
			Resources.UnloadAsset(loader.Result);
		}
	}

	private Dictionary<int, UiMessageConfig> ParseConfig(string xml)
	{
		Dictionary<int, UiMessageConfig> dictionary = new Dictionary<int, UiMessageConfig>();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		XmlNode documentElement = xmlDocument.DocumentElement;
		if (documentElement != null)
		{
			foreach (XmlNode childNode in documentElement.ChildNodes)
			{
				UiMessageConfig uiMessageConfig = new UiMessageConfig();
				uiMessageConfig.describe = childNode.Attributes["describe"].Value;
				uiMessageConfig.showTime = int.Parse(childNode.Attributes["showTime"].Value);
				uiMessageConfig.eventid = int.Parse(childNode.Attributes["eventid"].Value);
				uiMessageConfig.tipid = int.Parse(childNode.Attributes["tipid"].Value);
				uiMessageConfig.arguments = ((childNode.Attributes["arguments"] != null) ? childNode.Attributes["arguments"].Value.Split(',') : null);
				uiMessageConfig.isImage = childNode.Attributes["isImage"] != null && bool.Parse(childNode.Attributes["isImage"].Value);
				uiMessageConfig.messagePosY = ((childNode.Attributes["messagePosY"] != null) ? int.Parse(childNode.Attributes["messagePosY"].Value) : 240);
				uiMessageConfig.timeScale = ((childNode.Attributes["timeScale"] != null) ? childNode.Attributes["timeScale"].Value.Split(',') : null);
				UiMessageConfig uiMessageConfig2 = uiMessageConfig;
				if (uiMessageConfig2.isImage)
				{
					GameMessagePvpLoader.Instance.Table.GetRowList().Add(new GameMessagePvpTable.Row
					{
						ModeId = -1,
						Type = uiMessageConfig2.eventid,
						Mode = "halfLoadedRes",
						Image = uiMessageConfig2.describe.Replace('-', '/'),
						Time = uiMessageConfig2.showTime,
						Priority = 1,
						NumType = 0,
						PosX = 0,
						PosY = 0,
						MsgPosY = uiMessageConfig2.messagePosY
					});
				}
				dictionary.Add(uiMessageConfig2.eventid, uiMessageConfig2);
			}
		}
		return dictionary;
	}
}
