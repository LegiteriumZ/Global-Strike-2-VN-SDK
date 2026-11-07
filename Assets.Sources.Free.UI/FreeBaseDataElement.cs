using System;
using System.Collections.Generic;
using Assets.Sources.Free.Auto;
using UnityEngine;

namespace Assets.Sources.Free.UI;

[Serializable]
public struct FreeBaseDataElement
{
	public string Key;

	public int Relative;

	public int Parent;

	public bool NoMouse;

	public float X;

	public float Y;

	public int Width;

	public int Height;

	public string ComponentName;

	public string EventKey;

	public float StartX;

	public float StartY;

	public bool IsInWorld;

	public Transform OriginParent;

	public Transform NewParent;

	public Vector2 NewAnchor;

	public bool CanDrag;

	public int Event;

	public List<AutoField> Autos;

	public void ResetData()
	{
		Key = null;
		EventKey = null;
		ComponentName = "";
		Autos = null;
	}

	public void Update(FreeBaseComponent free)
	{
		Autos = free.Autos;
		Event = free.FreeUIEvent.Event;
		for (int i = 0; i < Autos.Count; i++)
		{
			Autos[i].autoToString = free.Autos[i].auto.ValueToString();
		}
	}

	public void Init()
	{
		ComponentName = "";
	}
}
