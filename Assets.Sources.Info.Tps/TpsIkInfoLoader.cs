using System.Collections;
using System.Collections.Generic;
using System.Xml;
using SSJJAsset.AssetManager;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Info.Tps;

public class TpsIkInfoLoader : MonoBehaviourSingleton<TpsIkInfoLoader>
{
	public List<TpsIkInfo> TpsIkInfos = new List<TpsIkInfo>();

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "TpsIk");
		string text = loader.Result.text;
		ParseIk(text);
	}

	private void ParseIk(string xmlContent)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xmlContent);
		foreach (XmlElement childNode in xmlDocument.FirstChild.ChildNodes)
		{
			TpsIkInfo tpsIkInfo = new TpsIkInfo();
			TpsIkInfos.Add(tpsIkInfo);
			tpsIkInfo.PlayerCodeName = childNode.Read("PlayerCodeName");
			tpsIkInfo.PlayerHeightType = childNode.ReadEnum<PlayerHeightType>("HeightType");
			tpsIkInfo.WeaponScale = childNode.Read("WeaponScale", 0f);
			tpsIkInfo.WeaponCodeName = childNode.Read("WeaponCodeName");
			tpsIkInfo.WeaponAnchorDiff = StrToVector3(childNode.Read("WeaponAnchorDiff"));
		}
	}

	private Vector3 StrToVector3(string vec)
	{
		string[] array = vec.Split(',');
		return new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
	}

	public TpsIkInfo GetIkInfo(string playerCodeName, string weaponCodeName)
	{
		for (int i = 0; i < TpsIkInfos.Count; i++)
		{
			if (TpsIkInfos[i].PlayerCodeName == playerCodeName && TpsIkInfos[i].WeaponCodeName == weaponCodeName)
			{
				return TpsIkInfos[i];
			}
		}
		return null;
	}
}
