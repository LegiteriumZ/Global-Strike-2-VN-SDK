using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class LoopChip : TimeSetChip<float>
{
	public LoopChip()
	{
		Step = 1000f;
		DelayStep = 1000f;
		base.Start = 0f;
		base.Target = 1f;
	}

	protected override float JumpTo(float percent)
	{
		base.IsOver = DetermineIsOver(percent);
		percent = Mathf.Clamp01(percent);
		base.Value = Mathf.Lerp(base.Start, base.Target, percent);
		if (base.IsOver)
		{
			runningTime = 0f;
		}
		return base.Value;
	}
}
