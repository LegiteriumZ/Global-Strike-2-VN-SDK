using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Utils.Chip;

public class PercentMaskChip : AbstractChip<Vector3>
{
	public Vector3 FromPosition = Vector3.zero;

	public Vector3 TargetPosition = Vector3.zero;

	public Vector3 Distance = Vector3.zero;

	public Vector3 MaskPosition = Vector3.zero;

	public Vector3 ProgressPosition = Vector3.zero;

	public Vector3 LightPosition = Vector3.zero;

	public Vector3 Update(float percent)
	{
		if (float.IsNaN(percent))
		{
			this.Info("Percent Is NaN !");
			return Vector3.zero;
		}
		Distance = TargetPosition - FromPosition;
		Vector3 vector = Distance * percent;
		MaskPosition = FromPosition + vector;
		ProgressPosition = Distance - vector;
		LightPosition = FromPosition + vector + Distance * 0.5f;
		return Cvalue = vector;
	}
}
