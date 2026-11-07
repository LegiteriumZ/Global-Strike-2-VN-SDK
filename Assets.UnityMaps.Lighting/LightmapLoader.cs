using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Assets.UnityMaps.Lighting;

public class LightmapLoader : MonoBehaviour
{
	public string ObjectHash;

	public MeshRenderer Render;

	public Texture2D LightmapColor;

	public Texture2D LightmapDir;

	public Texture2D ShadowMask;

	public Vector4 LightmapST;

	public int RealTimeLightMapIndex = -1;

	private static int _Index = 0;

	private static List<LightmapData> lightmaps = new List<LightmapData>();

	private static Dictionary<string, int> customLightmapData = new Dictionary<string, int>();

	private static bool inited = false;

	private void Start()
	{
		Init();
		Render.lightmapIndex = AddLightmap(this);
		RealTimeLightMapIndex = Render.lightmapIndex;
		Render.lightmapScaleOffset = LightmapST;
	}

	private static string GetObjectHash(LightmapData lightData)
	{
		return GetStringSha256Hash($"{((!(lightData.lightmapColor == null)) ? lightData.lightmapColor.GetInstanceID() : 0)}_{((!(lightData.lightmapDir == null)) ? lightData.lightmapDir.GetInstanceID() : 0)}_{((!(lightData.shadowMask == null)) ? lightData.shadowMask.GetInstanceID() : 0)}");
	}

	public void SaveLightmap()
	{
		MeshRenderer component = base.gameObject.GetComponent<MeshRenderer>();
		LightmapData lightmapData = LightmapSettings.lightmaps[component.lightmapIndex];
		ObjectHash = GetObjectHash(lightmapData);
		Render = component;
		LightmapColor = lightmapData.lightmapColor;
		LightmapDir = lightmapData.lightmapDir;
		ShadowMask = lightmapData.shadowMask;
		LightmapST = component.lightmapScaleOffset;
	}

	private static string GetStringSha256Hash(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		using SHA256Managed sHA256Managed = new SHA256Managed();
		byte[] bytes = Encoding.UTF8.GetBytes(text);
		return BitConverter.ToString(sHA256Managed.ComputeHash(bytes)).Replace("-", string.Empty);
	}

	public static void Init()
	{
		if (!inited)
		{
			inited = true;
			lightmaps.Clear();
			customLightmapData.Clear();
			lightmaps.AddRange(LightmapSettings.lightmaps);
		}
	}

	public static int AddLightmap(LightmapData lightmap)
	{
		int num = lightmaps.IndexOf(lightmap);
		if (num != -1)
		{
			return num;
		}
		lightmaps.Add(lightmap);
		LightmapSettings.lightmaps = lightmaps.ToArray();
		return lightmaps.Count - 1;
	}

	public static int AddLightmap(LightmapLoader loader)
	{
		if (customLightmapData.TryGetValue(loader.ObjectHash, out var value))
		{
			return value;
		}
		value = AddLightmap(new LightmapData
		{
			lightmapColor = loader.LightmapColor,
			lightmapDir = loader.LightmapDir,
			shadowMask = loader.ShadowMask
		});
		customLightmapData.Add(loader.ObjectHash, value);
		return value;
	}
}
