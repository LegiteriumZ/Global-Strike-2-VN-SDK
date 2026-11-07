using System;
using System.Collections.Generic;
using SSJJParticle;
using UnityEngine;

namespace Assets.Res.Assets.Scripts.PrefabInstance;

public class AccessoryParticleInstance : PaticlePrefabInstancecs
{
	[Serializable]
	public struct MatrixData
	{
		public string Name;

		public string JointName;

		public Vector3 ConfigPosition;

		public Quaternion ConfigRotation;

		public Vector3 ConfigScale;
	}

	public string AccessoryDyeingColor;

	public bool isSole;

	public List<MatrixData> DataList = new List<MatrixData>();

	public void updateDyeingColor(Color color)
	{
		if ((bool)ins)
		{
			changeDyeingColor(ins, color);
		}
		else
		{
			changeDyeingColor(base.transform.gameObject, color);
		}
	}

	private void changeDyeingColor(GameObject ins, Color color)
	{
		if (!ins)
		{
			return;
		}
		MeshRenderer[] componentsInChildren = ins.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer meshRenderer in componentsInChildren)
		{
			Transform parent = meshRenderer.transform.parent;
			if (!(parent == null) && !(parent.GetComponent<ParticleSystemRenderer>() == null))
			{
				Material[] materials = meshRenderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].SetColor("_DyeingColor", color);
				}
			}
		}
		ParticleSystemRenderer[] componentsInChildren2 = ins.GetComponentsInChildren<ParticleSystemRenderer>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			Material[] materials = componentsInChildren2[i].materials;
			foreach (Material material in materials)
			{
				if ((bool)material)
				{
					material.SetColor("_DyeingColor", color);
				}
			}
		}
		global::SSJJParticle.SSJJParticle[] componentsInChildren3 = ins.GetComponentsInChildren<global::SSJJParticle.SSJJParticle>();
		foreach (global::SSJJParticle.SSJJParticle sSJJParticle in componentsInChildren3)
		{
			Material material2 = sSJJParticle.mater;
			if (!material2.name.EndsWith("_Dyeing"))
			{
				Material material3 = UnityEngine.Object.Instantiate(material2);
				material3.name += "_Dyeing";
				sSJJParticle.mater = material3;
				material2 = material3;
			}
			if ((bool)material2)
			{
				material2.SetColor("_DyeingColor", color);
			}
		}
	}
}
