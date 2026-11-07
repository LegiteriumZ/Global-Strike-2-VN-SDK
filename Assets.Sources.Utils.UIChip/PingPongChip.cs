using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class PingPongChip : TimeSetChip<float>
{
	protected override float JumpTo(float percent)
	{
		base.IsOver = DetermineIsOver(percent);
		base.Value = Mathf.PingPong(percent, 1f) * (base.Target - base.Start) + base.Start;
		if (base.IsOver)
		{
			float target = base.Target;
			_target = base.Start;
			_start = target;
			runningTime = 0f;
		}
		return base.Value;
	}
}
