using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Utils;

public class MaterialCache : MonoBehaviour
{
	public Dictionary<Material, bool> Zwrites = new Dictionary<Material, bool>();

	public Dictionary<Material, int> RenderQueues = new Dictionary<Material, int>();

	public void GetCache()
	{
		Material[] sharedMaterials = GetComponent<Renderer>().sharedMaterials;
		foreach (Material material in sharedMaterials)
		{
			if (material == null)
			{
				break;
			}
			if (material.HasProperty("_ZWrite") && !Zwrites.ContainsKey(material))
			{
				Zwrites.Add(material, material.GetInt("_ZWrite") == 1);
			}
			if (!RenderQueues.ContainsKey(material))
			{
				RenderQueues.Add(material, material.renderQueue);
			}
		}
	}
}
