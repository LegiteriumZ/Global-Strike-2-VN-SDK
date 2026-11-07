using System.Collections.Generic;
using UnityEngine;

public class GPUSkinningPlayerMonoManager
{
	private List<GPUSkinningPlayerResources> items = new List<GPUSkinningPlayerResources>();

	public void Register(GPUSkinningAnimation anim, Mesh mesh, Material originalMtrl, TextAsset textureRawData, GPUSkinningPlayerMono player, out GPUSkinningPlayerResources resources)
	{
		resources = null;
		if (anim == null || originalMtrl == null || textureRawData == null || player == null)
		{
			return;
		}
		GPUSkinningPlayerResources gPUSkinningPlayerResources = null;
		int count = items.Count;
		for (int i = 0; i < count; i++)
		{
			if (items[i].anim.guid == anim.guid)
			{
				gPUSkinningPlayerResources = items[i];
				break;
			}
		}
		if (gPUSkinningPlayerResources == null)
		{
			gPUSkinningPlayerResources = new GPUSkinningPlayerResources();
			items.Add(gPUSkinningPlayerResources);
		}
		if (gPUSkinningPlayerResources.anim == null)
		{
			gPUSkinningPlayerResources.anim = anim;
		}
		if (gPUSkinningPlayerResources.mesh == null)
		{
			gPUSkinningPlayerResources.mesh = mesh;
		}
		gPUSkinningPlayerResources.InitMaterial(originalMtrl, HideFlags.None);
		if (gPUSkinningPlayerResources.texture == null)
		{
			gPUSkinningPlayerResources.texture = GPUSkinningUtil.CreateTexture2D(textureRawData, anim);
		}
		if (!gPUSkinningPlayerResources.players.Contains(player))
		{
			gPUSkinningPlayerResources.players.Add(player);
			gPUSkinningPlayerResources.AddCullingBounds();
		}
		resources = gPUSkinningPlayerResources;
	}

	public void Unregister(GPUSkinningPlayerMono player)
	{
		if (player == null)
		{
			return;
		}
		int count = items.Count;
		for (int i = 0; i < count; i++)
		{
			int num = items[i].players.IndexOf(player);
			if (num != -1)
			{
				items[i].players.RemoveAt(num);
				items[i].RemoveCullingBounds(num);
				if (items[i].players.Count == 0)
				{
					items[i].Destroy();
					items.RemoveAt(i);
				}
				break;
			}
		}
	}
}
