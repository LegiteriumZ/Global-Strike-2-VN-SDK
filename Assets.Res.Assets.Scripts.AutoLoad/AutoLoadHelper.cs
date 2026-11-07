using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Res.Assets.Scripts.AutoLoad;

[ExecuteInEditMode]
[DisallowMultipleComponent]
public class AutoLoadHelper : MonoBehaviour
{
	[Serializable]
	public class AutoLoadData
	{
		public string AssetName;

		public string Parent;

		public string Name;

		public int Sibling;

		public Vector3 Position;

		public Vector3 Scale;

		public Vector3 Rotation;
	}

	public List<AutoLoadData> Chips = new List<AutoLoadData>();

	[NonSerialized]
	public bool IsPreviewed;

	[NonSerialized]
	public List<Transform> TempParents = new List<Transform>();

	[NonSerialized]
	public List<UnityEngine.Object> TempPrefabs = new List<UnityEngine.Object>();

	private void Start()
	{
	}

	private void Update()
	{
	}
}
