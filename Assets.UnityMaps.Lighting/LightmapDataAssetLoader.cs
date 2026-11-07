using System.Linq;
using UnityEngine;

namespace Assets.UnityMaps.Lighting;

public class LightmapDataAssetLoader : MonoBehaviour
{
	public CustomLightmapData[] Data;

	private void Awake()
	{
		LightmapSettings.lightmaps = Data.Select((CustomLightmapData x) => new LightmapData
		{
			lightmapColor = x.Light,
			lightmapDir = x.Dir,
			shadowMask = x.Shadowmask
		}).ToArray();
	}
}
