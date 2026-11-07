using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Res.Assets.Scripts.UiSynchro;

[ExecuteInEditMode]
[DisallowMultipleComponent]
public class UiSynchroHelper : MonoBehaviour
{
	public string SynchroTag;

	[NonSerialized]
	public List<GameObject> TempObjects = new List<GameObject>();
}
