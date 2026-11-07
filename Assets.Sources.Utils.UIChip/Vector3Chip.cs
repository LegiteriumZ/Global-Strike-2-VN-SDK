using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class Vector3Chip : TimeSetChip<Vector3>
{
	private Vector3 _speed = Vector3.zero;

	private Vector3 _Project;

	public Vector3 Speed
	{
		get
		{
			return _speed;
		}
		set
		{
			_speed = value;
			base.Time = CalculateTotalTime();
		}
	}

	protected override float CalculateTotalTime()
	{
		Vector3 onNormal = base.Target - base.Start;
		_Project = Vector3.Project(Speed, onNormal);
		float num = ((Mathf.Abs(_Project.x - 1E-05f) < float.Epsilon) ? 0f : (onNormal.x / _Project.x));
		float num2 = ((Mathf.Abs(_Project.y - 1E-05f) < float.Epsilon) ? 0f : (onNormal.y / _Project.y));
		float num3 = ((Mathf.Abs(_Project.z - 1E-05f) < float.Epsilon) ? 0f : (onNormal.z / _Project.z));
		return Mathf.Max(num, num2, num3);
	}

	protected override Vector3 JumpTo(float percent)
	{
		base.IsOver = DetermineIsOver(percent);
		percent = Mathf.Clamp01(percent);
		base.Value = base.Start + Speed * percent;
		if (base.IsOver)
		{
			base.Value = base.Target;
		}
		return base.Value;
	}
}
