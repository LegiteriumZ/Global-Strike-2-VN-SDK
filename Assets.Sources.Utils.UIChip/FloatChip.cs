using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class FloatChip : TimeSetChip<float>
{
	private float _speed;

	public float Speed
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

	public FloatChip()
	{
		Step = 1000f;
		DelayStep = 1000f;
		base.Start = 0f;
		base.Target = 1f;
	}

	protected override float CalculateTotalTime()
	{
		if (Mathf.Abs(Speed - 1E-05f) < float.Epsilon)
		{
			return 0f;
		}
		return Mathf.Abs((base.Target - base.Start) / Speed);
	}

	protected override float JumpTo(float percent)
	{
		base.IsOver = DetermineIsOver(percent);
		percent = Mathf.Clamp01(percent);
		base.Value = Mathf.Lerp(base.Start, base.Target, percent);
		return base.Value;
	}
}
