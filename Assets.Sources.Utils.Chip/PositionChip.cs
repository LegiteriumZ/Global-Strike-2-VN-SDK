using Assets.Sources.Components.Time;
using UnityEngine;

namespace Assets.Sources.Utils.Chip;

public class PositionChip : AbstractChip<Vector3>
{
	public Vector3 Position = Vector3.zero;

	public Vector3 Speed = Vector3.zero;

	public Vector3 TargetPosition = Vector3.zero;

	public Vector3 Update(TimeComponent time)
	{
		base.IsOver = false;
		Vector3 vector = Position + Speed * time.FrameInterval / 1000f;
		if (Vector3.Distance(Position, TargetPosition) < Vector3.Distance(Position, vector))
		{
			base.IsOver = true;
			Position = TargetPosition;
		}
		else
		{
			Position = vector;
		}
		return Cvalue = Position;
	}
}
