using System;
using SSJJBase.Logger;
using UnityEngine;

public class LODSwitcherSelf : MonoBehaviour
{
	private Mesh[] lodMeshes;

	public GameObject[] lodGameObjects;

	public float[] lodScreenSizes;

	public float deactivateAtDistance;

	public Camera customCamera;

	private MeshFilter meshFilter;

	private SkinnedMeshRenderer skinnedMeshRenderer;

	public Vector3 centerOffset;

	public float pixelsPerMeter;

	public float objectSize;

	public int fixedLODLevel = -1;

	public int lodLevel;

	public int frameOffset;

	public int frameInterval = 10;

	private bool _noUse;

	public float screenPortion;

	private void Start()
	{
	}

	public void ComputeDimensions()
	{
		if (skinnedMeshRenderer == null && meshFilter == null)
		{
			GetMeshFilter();
		}
		if (skinnedMeshRenderer != null)
		{
			frameInterval = 1;
		}
		Camera main = customCamera;
		if (main == null)
		{
			main = Camera.main;
		}
		if (main == null)
		{
			this.LogWarn("No scene camera found yet, you need to call LODSwitcher.ComputeDimensions() again when you have your Camera set up");
			return;
		}
		Vector3 a = main.ScreenToWorldPoint(new Vector3(((float)Screen.width - 100f) / 2f, 0f, 1f));
		Vector3 b = main.ScreenToWorldPoint(new Vector3(((float)Screen.width + 100f) / 2f, 0f, 1f));
		pixelsPerMeter = 1f / (Vector3.Distance(a, b) / 100f);
	}

	public void SetCustomCamera(Camera aCamera)
	{
		customCamera = aCamera;
		ComputeDimensions();
	}

	public void SetFixedLODLevel(int aLevel)
	{
		fixedLODLevel = Mathf.Max(0, Mathf.Min(MaxLODLevel(), aLevel));
	}

	public void ReleaseFixedLODLevel()
	{
		fixedLODLevel = -1;
	}

	public int GetLODLevel()
	{
		return lodLevel;
	}

	public int MaxLODLevel()
	{
		if (lodScreenSizes == null)
		{
			return 0;
		}
		return lodScreenSizes.Length;
	}

	public Mesh GetMesh(int aLevel)
	{
		if (lodMeshes != null && lodMeshes.Length >= aLevel)
		{
			return lodMeshes[aLevel];
		}
		return null;
	}

	public void SetMesh(Mesh aMesh, int aLevel)
	{
		if (lodMeshes == null)
		{
			lodMeshes = new Mesh[aLevel + 1];
		}
		if (lodMeshes.Length <= aLevel)
		{
			Array.Resize(ref lodMeshes, aLevel + 1);
		}
		if (aLevel > 0)
		{
			if (lodScreenSizes == null)
			{
				lodScreenSizes = new float[aLevel];
			}
			if (lodScreenSizes.Length < aLevel)
			{
				Array.Resize(ref lodScreenSizes, aLevel);
			}
		}
		lodMeshes[aLevel] = aMesh;
		if (aLevel == lodLevel)
		{
			lodLevel = -1;
			SetLODLevel(aLevel);
		}
		ComputeDimensions();
	}

	public void SetRelativeScreenSize(float aValue, int aLevel)
	{
		if (lodScreenSizes == null)
		{
			lodScreenSizes = new float[aLevel];
		}
		if (lodScreenSizes.Length < aLevel)
		{
			Array.Resize(ref lodScreenSizes, aLevel);
		}
		for (int i = 0; i < lodScreenSizes.Length; i++)
		{
			if (i + 1 == aLevel)
			{
				lodScreenSizes[i] = aValue;
			}
			else if (lodScreenSizes[i] == 0f)
			{
				if (i == 0)
				{
					lodScreenSizes[i] = 0.6f;
				}
				else
				{
					lodScreenSizes[i] = lodScreenSizes[i - 1] * 0.5f;
				}
			}
		}
	}

	public Vector3 NearestCameraPositionForLOD(int aLevel)
	{
		ComputeDimensions();
		Camera main = customCamera;
		if (main == null)
		{
			main = Camera.main;
		}
		if (aLevel > 0 && aLevel <= lodScreenSizes.Length)
		{
			float num = objectSize * pixelsPerMeter / (float)Screen.width / lodScreenSizes[aLevel - 1];
			return base.transform.position + centerOffset + main.transform.rotation * (Vector3.back * num);
		}
		return main.transform.position;
	}

	public float ScreenPortion()
	{
		Camera main = customCamera;
		if (main == null)
		{
			main = Camera.main;
		}
		float num = Vector3.Distance(main.transform.position, base.transform.position);
		if (deactivateAtDistance > 0f && num > deactivateAtDistance)
		{
			return -1f;
		}
		return (float)Mathf.RoundToInt(objectSize * pixelsPerMeter / num / (float)Screen.width * 40f) * 0.025f;
	}

	private void ComputeLODLevel()
	{
		int num = 0;
		if (fixedLODLevel >= 0)
		{
			num = fixedLODLevel;
		}
		else
		{
			screenPortion = ScreenPortion();
			if (screenPortion >= 0f)
			{
				for (int i = 0; i < lodScreenSizes.Length; i++)
				{
					if (screenPortion < lodScreenSizes[i])
					{
						num++;
					}
				}
			}
			else
			{
				num = -1;
			}
		}
		if (num != lodLevel)
		{
			SetLODLevel(num);
		}
	}

	private void GetMeshFilter()
	{
		skinnedMeshRenderer = base.gameObject.GetComponent<SkinnedMeshRenderer>();
		if (skinnedMeshRenderer == null)
		{
			meshFilter = base.gameObject.GetComponent<MeshFilter>();
		}
	}

	public void SetLODLevel(int newLodLevel)
	{
		if (newLodLevel == lodLevel)
		{
			return;
		}
		newLodLevel = Mathf.Min(MaxLODLevel(), newLodLevel);
		if (newLodLevel >= 0)
		{
			if (lodMeshes != null && lodMeshes.Length > newLodLevel)
			{
				if (skinnedMeshRenderer == null && meshFilter == null)
				{
					GetMeshFilter();
				}
				if (skinnedMeshRenderer != null)
				{
					skinnedMeshRenderer.sharedMesh = lodMeshes[newLodLevel];
				}
				else if (meshFilter != null)
				{
					meshFilter.sharedMesh = lodMeshes[newLodLevel];
				}
			}
			int num = 0;
			while (lodGameObjects != null && num < lodGameObjects.Length)
			{
				lodGameObjects[num].SetActive(num == newLodLevel);
				num++;
			}
		}
		lodLevel = newLodLevel;
	}
}
