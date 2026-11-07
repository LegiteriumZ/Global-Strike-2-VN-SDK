using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace Assets.Sources.Info.Effect.Scene;

public class SceneEffectConfig
{
	public SceneEffectData EffectData;

	public SceneEffectTextureData[] EffectTextureDatas;

	public SceneEffectTextureData[] CubeEffectTextureDatas;

	private static Vector3 SplitVector3(string data)
	{
		string[] array = ((data.IndexOf(' ') > -1) ? data.Split(' ') : data.Split(','));
		return new Vector3(Convert.ToSingle(array[0]), Convert.ToSingle(array[1]), Convert.ToSingle(array[2]));
	}

	private static Vector3[] SplitVector3Array(string data, int count)
	{
		string[] array = ((data.IndexOf(' ') > -1) ? data.Split(' ') : data.Split(','));
		Vector3[] array2 = new Vector3[count];
		for (int i = 0; i < count; i++)
		{
			array2[i] = new Vector3(Convert.ToSingle(array[i * 3]), Convert.ToSingle(array[i * 3 + 1]), Convert.ToSingle(array[i * 3 + 2]));
		}
		return array2;
	}

	private static Vector2[] SplitVector2Array(string data, int count)
	{
		string[] array = ((data.IndexOf(' ') > -1) ? data.Split(' ') : data.Split(','));
		Vector2[] array2 = new Vector2[count];
		for (int i = 0; i < count; i++)
		{
			array2[i] = new Vector3(Convert.ToSingle(array[i * 2]), Convert.ToSingle(array[i * 2 + 1]));
		}
		return array2;
	}

	private static int[] SplitInt(string data, int count)
	{
		string[] array = ((data.IndexOf(' ') > -1) ? data.Split(' ') : data.Split(','));
		int[] array2 = new int[count];
		for (int i = 0; i < count; i++)
		{
			array2[i] = Convert.ToInt32(array[i]);
		}
		return array2;
	}

	private static SceneEffectTextureData[] GetTextureDatas(XmlNodeList nodeList)
	{
		List<SceneEffectTextureData> list = new List<SceneEffectTextureData>();
		if (nodeList != null)
		{
			for (int i = 0; i < nodeList.Count; i++)
			{
				SceneEffectTextureData sceneEffectTextureData = new SceneEffectTextureData();
				sceneEffectTextureData.Name = (nodeList[i] as XmlElement).GetAttribute("name");
				if (!string.IsNullOrEmpty(sceneEffectTextureData.Name))
				{
					sceneEffectTextureData.NameWithoutExtension = Path.GetFileNameWithoutExtension(sceneEffectTextureData.Name);
				}
				list.Add(sceneEffectTextureData);
			}
		}
		return list.ToArray();
	}

	public static List<SceneEffectConfig> ReadEffectXml(string data)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(data);
		XmlNodeList childNodes = xmlDocument.SelectSingleNode("SceneObjects").ChildNodes;
		List<SceneEffectConfig> list = new List<SceneEffectConfig>();
		foreach (XmlNode item in childNodes)
		{
			if (!(item is XmlElement))
			{
				continue;
			}
			if (item.Name == "JumpPoint" || item.Name == "SceneEffects")
			{
				foreach (XmlElement item2 in item.SelectNodes("effectData"))
				{
					SceneEffectConfig sceneEffectConfig = new SceneEffectConfig();
					list.Add(sceneEffectConfig);
					SceneEffectData sceneEffectData = (sceneEffectConfig.EffectData = new SceneEffectData());
					ReadEffectData(sceneEffectData, item2);
					sceneEffectData.EffectName = item.Name;
				}
			}
			else
			{
				if (!(item.Name == "SceneEvents"))
				{
					continue;
				}
				foreach (XmlElement item3 in item.SelectNodes("sceneEventData"))
				{
					SceneEffectConfig sceneEffectConfig2 = new SceneEffectConfig();
					list.Add(sceneEffectConfig2);
					SceneEffectData sceneEffectData2 = (sceneEffectConfig2.EffectData = new SceneEffectData());
					ReadEffectData(sceneEffectData2, item3);
					sceneEffectData2.EffectName = item.Name;
				}
			}
		}
		return list;
	}

	private static void ReadEffectData(SceneEffectData effectData, XmlElement effectDataNode)
	{
		if (effectDataNode.HasAttribute("effect_name"))
		{
			effectData.EffectName = effectDataNode.GetAttribute("effect_name");
		}
		if (effectDataNode.HasAttribute("effect_type"))
		{
			effectData.EffectType = effectDataNode.GetAttribute("effect_type");
		}
		if (effectDataNode.HasAttribute("time"))
		{
			effectData.Time = Convert.ToInt32(effectDataNode.GetAttribute("time"));
		}
		if (effectDataNode.HasAttribute("model_name"))
		{
			effectData.ModelName = effectDataNode.GetAttribute("model_name");
		}
		if (effectDataNode.HasAttribute("rotation_speed"))
		{
			effectData.RotationSpeed = Convert.ToInt32(effectDataNode.GetAttribute("rotation_speed"));
		}
		if (effectDataNode.HasAttribute("rotation_normal"))
		{
			effectData.RotationNormal = SplitVector3(effectDataNode.GetAttribute("rotation_normal"));
		}
		if (effectDataNode.HasAttribute("position"))
		{
			effectData.Position = SplitVector3(effectDataNode.GetAttribute("position"));
		}
		if (effectDataNode.HasAttribute("rotation"))
		{
			effectData.Rotation = SplitVector3(effectDataNode.GetAttribute("rotation"));
		}
		if (effectDataNode.HasAttribute("pos0"))
		{
			effectData.Pos0 = SplitVector3(effectDataNode.GetAttribute("pos0"));
		}
		if (effectDataNode.HasAttribute("pos1"))
		{
			effectData.Pos1 = SplitVector3(effectDataNode.GetAttribute("pos1"));
		}
		if (effectDataNode.HasAttribute("pos2"))
		{
			effectData.Pos2 = SplitVector3(effectDataNode.GetAttribute("pos2"));
		}
		if (effectDataNode.HasAttribute("pos3"))
		{
			effectData.Pos3 = SplitVector3(effectDataNode.GetAttribute("pos3"));
		}
		if (effectDataNode.HasAttribute("scale"))
		{
			effectData.Scale = Convert.ToSingle(effectDataNode.GetAttribute("scale"));
		}
		if (effectDataNode.HasAttribute("mustShow"))
		{
			effectData.MustShow = Convert.ToInt32(effectDataNode.GetAttribute("mustShow"));
		}
		if (effectDataNode.HasAttribute("setdepthtest"))
		{
			effectData.SetDepthTest = Convert.ToInt32(effectDataNode.GetAttribute("setdepthtest"));
		}
		if (effectDataNode.HasAttribute("envBoxMin"))
		{
			effectData.EnvBoxMin = SplitVector3(effectDataNode.GetAttribute("envBoxMin"));
		}
		if (effectDataNode.HasAttribute("envBoxMax"))
		{
			effectData.EnvBoxMax = SplitVector3(effectDataNode.GetAttribute("envBoxMax"));
		}
		if (effectDataNode.HasAttribute("envBoxPos"))
		{
			effectData.EnvBoxPos = SplitVector3(effectDataNode.GetAttribute("envBoxPos"));
		}
		if (effectDataNode.HasAttribute("vertexCount"))
		{
			effectData.VertexCount = Convert.ToInt32(effectDataNode.GetAttribute("vertexCount"));
			effectData.VertexData = SplitVector3Array(effectDataNode.GetAttribute("vertexData"), effectData.VertexCount);
		}
		if (effectDataNode.HasAttribute("normalData"))
		{
			effectData.NormalData = SplitVector3Array(effectDataNode.GetAttribute("normalData"), effectData.VertexCount);
		}
		if (effectDataNode.HasAttribute("uvCount"))
		{
			effectData.UvCount = Convert.ToInt32(effectDataNode.GetAttribute("uvCount"));
			effectData.UvData = SplitVector2Array(effectDataNode.GetAttribute("uvData"), effectData.UvCount);
		}
		if (effectDataNode.HasAttribute("indexCount"))
		{
			effectData.IndexCount = Convert.ToInt32(effectDataNode.GetAttribute("indexCount"));
			effectData.IndexData = SplitInt(effectDataNode.GetAttribute("index"), effectData.IndexCount);
		}
		if (effectDataNode.HasAttribute("ReflectionProbeBoundMin"))
		{
			effectData.ReflectionProbeBoundMin = SplitVector3(effectDataNode.GetAttribute("ReflectionProbeBoundMin"));
		}
		if (effectDataNode.HasAttribute("ReflectionProbeBoundMax"))
		{
			effectData.ReflectionProbeBoundMax = SplitVector3(effectDataNode.GetAttribute("ReflectionProbeBoundMax"));
		}
		if (effectDataNode.HasAttribute("alpha"))
		{
			effectData.Alpha = Convert.ToSingle(effectDataNode.GetAttribute("alpha"));
		}
		if (effectDataNode.HasAttribute("cull"))
		{
			effectData.Cull = Convert.ToInt32(effectDataNode.GetAttribute("cull"));
		}
		if (effectDataNode.HasAttribute("sceneEventID"))
		{
			effectData.SceneEventID = effectDataNode.GetAttribute("sceneEventID");
		}
		if (effectDataNode.HasAttribute("soundName"))
		{
			effectData.SoundName = effectDataNode.GetAttribute("soundName");
		}
		if (effectDataNode.HasAttribute("radius"))
		{
			effectData.Radius = Convert.ToInt32(effectDataNode.GetAttribute("radius"));
		}
	}

	public static List<SceneEffectConfig> ReadConfig(string data)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(data);
		XmlNodeList childNodes = xmlDocument.SelectSingleNode("sceneEffectConfig").ChildNodes;
		List<SceneEffectConfig> list = new List<SceneEffectConfig>();
		foreach (XmlNode item in childNodes)
		{
			if (item is XmlElement)
			{
				SceneEffectConfig sceneEffectConfig = new SceneEffectConfig();
				list.Add(sceneEffectConfig);
				XmlElement effectDataNode = item["effectData"];
				ReadEffectData(sceneEffectConfig.EffectData = new SceneEffectData(), effectDataNode);
				sceneEffectConfig.EffectTextureDatas = GetTextureDatas(item.SelectNodes("effectTexture"));
				sceneEffectConfig.CubeEffectTextureDatas = GetTextureDatas(item.SelectNodes("cubeEffectTexture"));
			}
		}
		return list;
	}
}
