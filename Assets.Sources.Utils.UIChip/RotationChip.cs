using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class RotationChip : AbstractChip<Vector3, Quaternion>
{
	private Vector3 _start;

	private Vector3 _target;

	private Vector3 _speed = Vector3.zero;

	public bool Loop;

	private Vector3 _Project;

	public Vector3 Start
	{
		get
		{
			return _start;
		}
		set
		{
			_start = value;
			base.Time = CalculateTotalTime();
		}
	}

	public Vector3 Target
	{
		get
		{
			return _target;
		}
		set
		{
			_target = value;
			base.Time = CalculateTotalTime();
		}
	}

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

	protected float CalculateTotalTime()
	{
		Vector3 onNormal = Target - Start;
		_Project = Vector3.Project(Speed, onNormal);
		float num = ((Mathf.Abs(_Project.x - 1E-05f) < float.Epsilon) ? 0f : (onNormal.x / _Project.x));
		float num2 = ((Mathf.Abs(_Project.y - 1E-05f) < float.Epsilon) ? 0f : (onNormal.y / _Project.y));
		float num3 = ((Mathf.Abs(_Project.z - 1E-05f) < float.Epsilon) ? 0f : (onNormal.z / _Project.z));
		return Mathf.Max(num, num2, num3);
	}

	protected override Quaternion JumpTo(float percent)
	{
		if (!Loop)
		{
			base.IsOver = DetermineIsOver(percent);
			percent = Mathf.Clamp01(percent);
		}
		else
		{
			base.IsOver = false;
		}
		base.Value = Vector3.Lerp(Start, Target, percent);
		return Quaternion.Euler(base.Value);
	}
}
