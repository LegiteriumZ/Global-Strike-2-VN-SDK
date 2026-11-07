using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class SimpleFreeUiViewer : MonoBehaviour
{
	[Serializable]
	public class SimpleFreeUiViewData
	{
		public Transform Tran;
	}

	public List<SimpleFreeUiViewData> ViewDatas = new List<SimpleFreeUiViewData>();

	public void AddTran(Transform tran)
	{
		ViewDatas.Add(new SimpleFreeUiViewData());
		ViewDatas[ViewDatas.Count - 1].Tran = tran;
	}
}
