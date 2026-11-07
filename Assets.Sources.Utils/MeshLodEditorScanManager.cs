using System;
using System.Collections.Generic;
using Assets.Sources.Utils.Ui;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Utils;

public class MeshLodEditorScanManager : MonoBehaviourSingleton<MeshLodEditorScanManager>
{
	[Serializable]
	public class MeshScanMsg
	{
		public LODSwitcher Switcher;

		public int NowLevel;

		public int GlusVertexCount;

		public int NowFrameCount;
	}

	public bool IsResetOrigin;

	public List<MeshScanMsg> Scans = new List<MeshScanMsg>();

	public int AllLodCount;

	public int AllGlusVertexCount;

	public int AllSeeVertexCount;

	public List<LODSwitcher> NowSeeLevel1Switchers = new List<LODSwitcher>();

	public List<LODSwitcher> NowSeeLevel2Switchers = new List<LODSwitcher>();

	public List<LODSwitcher> NowSeeLevel3Switchers = new List<LODSwitcher>();

	private void Update()
	{
		if (IsResetOrigin)
		{
			IsResetOrigin = false;
			for (int i = 0; i < Scans.Count; i++)
			{
				Scans[i].Switcher.ResetLod();
			}
		}
	}

	private MeshScanMsg Add(LODSwitcher lodSwitcher)
	{
		MeshScanMsg meshScanMsg = new MeshScanMsg();
		meshScanMsg.Switcher = lodSwitcher;
		Scans.Add(meshScanMsg);
		return meshScanMsg;
	}

	public void Refresh(LODSwitcher lodSwitcher, int nowFrameCount)
	{
		MeshScanMsg meshScanMsg = null;
		for (int i = 0; i < Scans.Count; i++)
		{
			if (Scans[i].Switcher == lodSwitcher)
			{
				meshScanMsg = Scans[i];
				break;
			}
		}
		if (meshScanMsg == null)
		{
			meshScanMsg = Add(lodSwitcher);
		}
		if (meshScanMsg != null)
		{
			meshScanMsg.NowFrameCount = nowFrameCount;
			meshScanMsg.NowLevel = lodSwitcher.LodLevel;
			meshScanMsg.GlusVertexCount = -lodSwitcher.lodMeshes[lodSwitcher.LodLevel].vertexCount + lodSwitcher.lodMeshes[0].vertexCount;
		}
	}

	public void Sum(int nowFrame)
	{
		for (int i = 0; i < Scans.Count; i++)
		{
			if (Scans[i].NowFrameCount < nowFrame)
			{
				Scans.RemoveAt(i--);
			}
		}
		NowSeeLevel1Switchers.Clear();
		NowSeeLevel2Switchers.Clear();
		NowSeeLevel3Switchers.Clear();
		AllSeeVertexCount = (AllGlusVertexCount = 0);
		for (int j = 0; j < Scans.Count; j++)
		{
			if (InScreenUtils.CheckInScreenAccury(Scans[j].Switcher.gameObject.transform.position, Camera.main) > 0f && Scans[j].Switcher.gameObject.activeInHierarchy)
			{
				AllGlusVertexCount += Scans[j].GlusVertexCount;
				AllSeeVertexCount += Scans[j].Switcher.GetRenderMesh().vertexCount;
				if (Scans[j].Switcher.LodLevel == 0)
				{
					NowSeeLevel1Switchers.Add(Scans[j].Switcher);
				}
				else if (Scans[j].Switcher.LodLevel == 1)
				{
					NowSeeLevel2Switchers.Add(Scans[j].Switcher);
				}
				else if (Scans[j].Switcher.LodLevel == 2)
				{
					NowSeeLevel3Switchers.Add(Scans[j].Switcher);
				}
			}
		}
		AllLodCount = Scans.Count;
	}
}
