using Assets.Sources.Components.Time;
using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public abstract class AbstractChip<T, R>
{
	protected float totalTime;

	protected float runningTime;

	public float DelayStep = 1f;

	public float Step = 1f;

	public float Time
	{
		get
		{
			return runningTime;
		}
		set
		{
			IsOver = false;
			CurrentPercent = 0f;
			runningTime = 0f;
			totalTime = value;
		}
	}

	public virtual float Delay { get; set; }

	public T Value { get; protected set; }

	public bool IsOver { get; set; }

	public float CurrentPercent { get; private set; }

	protected abstract R JumpTo(float percent);

	public R JumpToPercent(float percent)
	{
		runningTime = Mathf.Lerp(0f, totalTime, percent) + getDelyTime();
		CurrentPercent = percent;
		return JumpTo(percent);
	}

	private float getDelyTime()
	{
		if (DelayStep == 0f)
		{
			return float.MaxValue;
		}
		return Delay / DelayStep;
	}

	protected bool DetermineIsOver(float percent)
	{
		if (!(percent > 1f))
		{
			return Mathf.Abs(percent - 1f) < float.Epsilon;
		}
		return true;
	}

	public R Update(int FrameInterval)
	{
		if (runningTime < float.MaxValue && totalTime > 0f)
		{
			runningTime += (float)FrameInterval / Step;
			float delyTime = getDelyTime();
			if (runningTime > delyTime)
			{
				CurrentPercent = (runningTime - delyTime) / totalTime;
				return JumpTo(CurrentPercent);
			}
			CurrentPercent = 0f;
			return JumpTo(0f);
		}
		CurrentPercent = 1f;
		return JumpTo(1f);
	}

	public R Update(TimeComponent time)
	{
		return Update(time.FrameInterval);
	}
}
