using Assets.Sources.Components.Time;
using UnityEngine;

namespace Assets.Sources.Utils.Chip;

public class RotationChip : AbstractChip<Quaternion>
{
	public Vector3 Rotation = Vector3.zero;

	public Vector3 TargetRotation = Vector3.zero;

	public Vector3 Speed = Vector3.zero;

	public bool Loop;

	public Quaternion Update(TimeComponent time)
	{
		base.IsOver = false;
		Vector3 vector = Rotation + Speed * time.FrameInterval / 1000f;
		if (Loop)
		{
			Rotation = vector;
		}
		else if (Vector3.Distance(Rotation, TargetRotation) < Vector3.Distance(Rotation, vector))
		{
			base.IsOver = true;
			Rotation = TargetRotation;
		}
		return Cvalue = Quaternion.Euler(Rotation);
	}
}
