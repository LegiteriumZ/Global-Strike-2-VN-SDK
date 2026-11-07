using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class NumberChip : AbstractChip<int, int>
{
	public int Start;

	public int Target;

	protected override int JumpTo(float percent)
	{
		base.IsOver = DetermineIsOver(percent);
		percent = Mathf.Clamp01(percent);
		base.Value = (int)Mathf.Lerp(Start, Target, percent);
		return base.Value;
	}
}
