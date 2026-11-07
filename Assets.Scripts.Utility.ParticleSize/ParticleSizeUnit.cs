using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Scripts.Utility.ParticleSize;

[ExecuteInEditMode]
public class ParticleSizeUnit : MonoBehaviour, IParticleSizeUnit
{
	[Serializable]
	public class RenderSize
	{
		public Renderer Ren;

		public Vector3 Min;

		public Vector3 Max;

		public Vector3 OriginCenter;

		public float Size;

		public bool IsSee;
	}

	public string Md5;

	public Vector3 Min;

	public Vector3 Max;

	public float Size;

	private float _minSize = 30f;

	public int FrameOffSet;

	public List<RenderSize> Sizes = new List<RenderSize>();

	public IFireEffectControl FireEffect;

	public bool IsAllSee;

	public void ResetSee()
	{
		IsAllSee = true;
		for (int i = 0; i < Sizes.Count; i++)
		{
			Sizes[i].Ren.enabled = true;
			Sizes[i].IsSee = true;
		}
		FrameOffSet = UnityEngine.Random.Range(0, 19);
	}

	public void AllUnSee()
	{
		IsAllSee = false;
		for (int i = 0; i < Sizes.Count; i++)
		{
			if (Sizes[i].IsSee)
			{
				Sizes[i].Ren.enabled = false;
				Sizes[i].IsSee = false;
			}
		}
	}

	public void SeeUnitCheck(int index, bool isSee)
	{
		if (isSee != Sizes[index].IsSee)
		{
			Sizes[index].Ren.enabled = isSee;
			Sizes[index].IsSee = isSee;
		}
	}

	public void CaculateFinalBox()
	{
		Max = -new Vector3(100000f, 10000f, 10000f);
		Min = new Vector3(100000f, 10000f, 10000f);
		foreach (RenderSize size in Sizes)
		{
			Max.x = Mathf.Max(Max.x, size.Max.x);
			Max.y = Mathf.Max(Max.y, size.Max.y);
			Max.z = Mathf.Max(Max.z, size.Max.z);
			Min.x = Mathf.Min(Min.x, size.Min.x);
			Min.y = Mathf.Min(Min.y, size.Min.y);
			Min.z = Mathf.Min(Min.z, size.Min.z);
		}
	}

	private Vector3 ConverVecToIntValue(Vector3 vec)
	{
		return new Vector3(Mathf.FloorToInt(vec.x), Mathf.FloorToInt(vec.y), Mathf.FloorToInt(vec.z));
	}

	public void CaculateSize()
	{
		Min = ConverVecToIntValue(Min);
		Max = ConverVecToIntValue(Max);
		Size = GetMaxSize(Min, Max);
		foreach (RenderSize size in Sizes)
		{
			size.Min = ConverVecToIntValue(size.Min);
			size.Max = ConverVecToIntValue(size.Max);
			size.Size = GetMaxSize(size.Min, size.Max);
		}
	}

	private float GetMaxSize(Vector3 min, Vector3 max)
	{
		float num = Mathf.Abs(max.x - min.x);
		float num2 = Mathf.Abs(max.y - min.y);
		float num3 = Mathf.Abs(max.z - max.z);
		return Mathf.Max((int)Mathf.Max(Mathf.Max(Mathf.Max(0f, num * num2), num * num3), num3 * num2), (int)_minSize);
	}
}
