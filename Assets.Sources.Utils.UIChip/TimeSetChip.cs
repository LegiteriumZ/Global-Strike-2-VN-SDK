using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class TimeSetChip<T> : AbstractChip<T, T>
{
	protected T _start;

	protected T _target;

	public T Start
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

	public T Target
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

	protected virtual float CalculateTotalTime()
	{
		return totalTime;
	}

	protected override T JumpTo(float percent)
	{
		base.IsOver = DetermineIsOver(percent);
		percent = Mathf.Clamp01(percent);
		base.Value = (base.IsOver ? Target : Start);
		return base.Value;
	}
}
