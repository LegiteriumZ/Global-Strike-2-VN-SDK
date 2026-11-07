using System;
using UnityEngine;

namespace Assets.UnityMaps.Lighting;

[Serializable]
public class CustomLightmapData
{
	public Texture2D Light;

	public Texture2D Dir;

	public Texture2D Shadowmask;
}
