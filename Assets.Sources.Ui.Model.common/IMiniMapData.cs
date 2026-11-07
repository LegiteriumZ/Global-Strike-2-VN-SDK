using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public interface IMiniMapData
{
	GameObject Container { get; }

	NotifyGroup NotifyGroup { get; }

	Vector3 WorldMin { get; }

	Vector3 WorldMax { get; }

	float ScaleX { get; }

	float ScaleY { get; }

	float RealWidth { get; }

	float RealHeight { get; }

	float Radius { get; }
}
