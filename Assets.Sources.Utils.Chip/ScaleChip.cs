using Assets.Sources.Components.Time;
using UnityEngine;

namespace Assets.Sources.Utils.Chip;

public class ScaleChip : AbstractChip<Vector3>
{
	public Vector3 Scale = Vector3.zero;

	public Vector3 TargetScale = Vector3.zero;

	public Vector3 Speed = Vector3.zero;

	public Vector3 Update(TimeComponent time)
	{
		base.IsOver = false;
		Vector3 vector = Scale + Speed * time.FrameInterval / 1000f;
		if (Vector3.Distance(Scale, TargetScale) < Vector3.Distance(Scale, vector))
		{
			base.IsOver = true;
			Scale = TargetScale;
		}
		else
		{
			Scale = vector;
		}
		return Cvalue = Scale;
	}
}
