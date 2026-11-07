using Assets.Sources.Components.Interface;
using SSJJBase.Logger;
using UnityEngine;

public class LODSwitcher : MonoBehaviour, ILODSwitcher
{
	public MeshFilter MeshFilter;

	public SkinnedMeshRenderer SkinnedMeshRenderer;

	public int[] LodScreenSizes;

	public int LodLevel;

	public int FrameOffset;

	public int ObjectSize;

	public int CamermDis;

	private int _oringLodLevel;

	private bool NoUse;

	private Camera _camera;

	private int _allowMinLodDistance = 1300;

	public Mesh[] lodMeshes { get; set; }

	private void Awake()
	{
		FrameOffset = Random.Range(0, 20);
		if (lodMeshes == null || lodMeshes.Length == 0)
		{
			this.LogWarn(base.gameObject.name + ".LODSwitcher: No lodMeshes/lodGameObjects set. LODSwitcher is now disabled.");
			NoUse = true;
		}
		if (NoUse)
		{
			return;
		}
		for (int i = 0; i < lodMeshes.Length; i++)
		{
			if (lodMeshes[i] == null)
			{
				NoUse = true;
			}
		}
		if (NoUse)
		{
			this.LogError("lod mesh lost " + base.gameObject.name);
			return;
		}
		MeshFilter = GetComponent<MeshFilter>();
		SkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
		LodLevel = 0;
		SetLod(LodLevel);
	}

	public int getLodLevel()
	{
		return LodLevel;
	}

	public Mesh GetRenderMesh()
	{
		return lodMeshes[LodLevel];
	}

	public void UpdateLod(int frameCount, bool isFov)
	{
		if (NoUse)
		{
			return;
		}
		if (_camera == null)
		{
			_camera = Camera.main;
			LodScreenSizes = new int[2];
			LodScreenSizes[0] = 8;
			LodScreenSizes[1] = 13;
			if (ObjectSize == 0)
			{
				ObjectSize = 100;
			}
		}
		float num = Vector3.Magnitude(_camera.transform.position - base.transform.position);
		bool isAllowLod = num > (float)_allowMinLodDistance;
		CamermDis = (int)num;
		LodLevel = GetLodLevel(ObjectSize, (int)num, LodScreenSizes[0], LodScreenSizes[1], isFov, isAllowLod);
		SetLod(LodLevel);
	}

	private int GetLodLevel(int size, int distance, int scale1, int scale2, bool isHasFov, bool isAllowLod)
	{
		if (isHasFov)
		{
			return 0;
		}
		if (!isAllowLod)
		{
			return 0;
		}
		if (distance > scale2 * size)
		{
			return 2;
		}
		if (distance > scale1 * size)
		{
			return 1;
		}
		return 0;
	}

	public void SetLod(int lodLevel)
	{
		if (_oringLodLevel != lodLevel)
		{
			if (MeshFilter != null)
			{
				MeshFilter.sharedMesh = lodMeshes[lodLevel];
			}
			if (SkinnedMeshRenderer != null)
			{
				SkinnedMeshRenderer.sharedMesh = lodMeshes[lodLevel];
			}
		}
		_oringLodLevel = lodLevel;
	}

	public void ResetLod()
	{
		SetLod(0);
	}
}
