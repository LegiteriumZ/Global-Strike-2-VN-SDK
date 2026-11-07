using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class TimeRangeInt : AbstractChip<int, bool>
{
	public int Start;

	public int Mid;

	public int Target;

	protected override bool JumpTo(float percent)
	{
		base.IsOver = DetermineIsOver(percent);
		percent = Mathf.Clamp01(percent);
		if (Mathf.Lerp(Start, Target, percent) < (float)Mid)
		{
			base.Value = Start;
			return false;
		}
		base.Value = Target;
		if (base.IsOver)
		{
			base.Value = Start;
			return false;
		}
		return true;
	}
}
