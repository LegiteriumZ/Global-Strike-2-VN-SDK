using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Assets.Sources.Info.Effect.Scene;

public class SceneHomeGunGridConfig
{
	private static Vector3 SplitVector3(string data)
	{
		string[] array = ((data.IndexOf(' ') > -1) ? data.Split(' ') : data.Split(','));
		return new Vector3(Convert.ToSingle(array[0]), Convert.ToSingle(array[1]), Convert.ToSingle(array[2]));
	}

	public static Dictionary<int, SceneHomeGunGridData> ReadConfig(string data)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(data);
		Dictionary<int, SceneHomeGunGridData> dictionary = new Dictionary<int, SceneHomeGunGridData>();
		foreach (XmlNode item in xmlDocument)
		{
			foreach (XmlNode item2 in item)
			{
				SceneHomeGunGridData sceneHomeGunGridData = new SceneHomeGunGridData();
				sceneHomeGunGridData.gridListid = int.Parse(item2.Attributes["gridListid"].Value);
				sceneHomeGunGridData.num = int.Parse(item2.Attributes["num"].Value);
				sceneHomeGunGridData.gridDic = new Dictionary<int, SceneHomeGunGriditemData>(sceneHomeGunGridData.num);
				sceneHomeGunGridData.size = float.Parse(item2.Attributes["size"].Value);
				sceneHomeGunGridData.gap = float.Parse(item2.Attributes["gap"].Value);
				sceneHomeGunGridData.pos = SplitVector3(item2.Attributes["p"].Value);
				sceneHomeGunGridData.rot = SplitVector3(item2.Attributes["r"].Value);
				sceneHomeGunGridData.sle = SplitVector3(item2.Attributes["s"].Value);
				sceneHomeGunGridData.type = int.Parse(item2.Attributes["type"].Value);
				sceneHomeGunGridData.group = int.Parse(item2.Attributes["group"].Value);
				foreach (XmlNode item3 in item2)
				{
					SceneHomeGunGriditemData sceneHomeGunGriditemData = new SceneHomeGunGriditemData();
					sceneHomeGunGriditemData.gridid = int.Parse(item3.Attributes["gridid"].Value);
					sceneHomeGunGriditemData.uid = int.Parse(item3.Attributes["uid"].Value);
					sceneHomeGunGriditemData.did = int.Parse(item3.Attributes["did"].Value);
					sceneHomeGunGriditemData.lid = int.Parse(item3.Attributes["lid"].Value);
					sceneHomeGunGriditemData.rid = int.Parse(item3.Attributes["rid"].Value);
					sceneHomeGunGriditemData.localPos = SplitVector3(item3.FirstChild.Value);
					sceneHomeGunGridData.gridDic.Add(sceneHomeGunGriditemData.gridid, sceneHomeGunGriditemData);
				}
				dictionary.Add(sceneHomeGunGridData.group, sceneHomeGunGridData);
			}
		}
		return dictionary;
	}
}
