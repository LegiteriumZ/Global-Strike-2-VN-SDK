using System;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class GhostItem : MonoBehaviour
{
	[NonSerialized]
	[HideInInspector]
	public GhostShadowFactory.GhostShadowAssembly AssemblyData;

	public float Duration;

	public float DeleteTime;

	public Color StartColor;

	public MeshRenderer MeshRenderer;

	public void InitData(float duration, float deleteTime, Color startColor, GhostShadowFactory.GhostShadowAssembly assembly)
	{
		Duration = duration;
		StartColor = startColor;
		DeleteTime = deleteTime;
		AssemblyData = assembly;
	}

	private void Update()
	{
		float num = DeleteTime - Time.time;
		if (num <= 0f)
		{
			if (AssemblyData != null)
			{
				GhostShadowFactory.Instance.Release(AssemblyData);
			}
		}
		else if ((bool)MeshRenderer.material)
		{
			float num2 = num / Duration;
			for (int i = 0; i < MeshRenderer.materials.Length; i++)
			{
				StartColor.a *= num2;
				AssemblyData.Block.SetColor("_RimColor", StartColor);
				AssemblyData.MeshRenderer.SetPropertyBlock(AssemblyData.Block);
			}
		}
	}
}
