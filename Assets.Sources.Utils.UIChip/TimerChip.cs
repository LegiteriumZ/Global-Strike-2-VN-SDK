using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class TimerChip : TimeSetChip<float>
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

	public TimerChip()
	{
		Step = 1000f;
	}

	protected override float CalculateTotalTime()
	{
		if (Mathf.Abs(Speed - 1E-05f) < float.Epsilon)
		{
			return 0f;
		}
		return (base.Target - base.Start) / Speed;
	}

	protected override float JumpTo(float percent)
	{
		percent = Mathf.Clamp01(percent);
		base.Value = Mathf.Lerp(base.Start, base.Target, percent);
		return base.Value;
	}
}
