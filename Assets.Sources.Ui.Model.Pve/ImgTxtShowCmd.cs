using System;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Pve;

public struct ImgTxtShowCmd : IEquatable<ImgTxtShowCmd>, IChanged
{
	public string TextComponent;

	public string AlwaysText;

	public int OriginText;

	public int TargetText;

	public string ColComponent;

	public Color? OriginCol;

	public Color? TargetCol;

	public string ResComponent;

	public string ResKey;

	public string SizeComponent;

	public Vector2? OriginSize;

	public Vector2? TargetSize;

	public int? SizeTime;

	public string FontRes;

	public Action StartEvent;

	public Action EndEvent;

	public Action<int> UpdateEvent;

	public int Time { get; set; }

	public int Priority { get; set; }

	public bool Equals(ImgTxtShowCmd other)
	{
		if (Time != other.Time)
		{
			return false;
		}
		if (FontRes != other.FontRes)
		{
			return false;
		}
		if (TextComponent != other.TextComponent)
		{
			return false;
		}
		if (ColComponent != other.ColComponent)
		{
			return false;
		}
		if (ResComponent != other.ResComponent)
		{
			return false;
		}
		if (OriginSize != other.OriginSize)
		{
			return false;
		}
		if (TargetSize != other.TargetSize)
		{
			return false;
		}
		if (OriginCol != other.OriginCol)
		{
			return false;
		}
		if (TargetCol != other.TargetCol)
		{
			return false;
		}
		if (OriginText != other.OriginText)
		{
			return false;
		}
		if (TargetText != other.TargetText)
		{
			return false;
		}
		if (StartEvent != other.StartEvent)
		{
			return false;
		}
		if (EndEvent != other.EndEvent)
		{
			return false;
		}
		if (UpdateEvent != other.UpdateEvent)
		{
			return false;
		}
		if (ResKey != other.ResKey)
		{
			return false;
		}
		if (SizeTime != other.SizeTime)
		{
			return false;
		}
		if (AlwaysText != other.AlwaysText)
		{
			return false;
		}
		if (Priority != other.Priority)
		{
			return false;
		}
		return true;
	}
}
