using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class TimeRangefloat : AbstractChip<float, bool>
{
	public float Start;

	public float Mid;

	public float Target;

	protected override bool JumpTo(float percent)
	{
		base.IsOver = DetermineIsOver(percent);
		percent = Mathf.Clamp01(percent);
		if (Mathf.Lerp(Start, Target, percent) < Mid)
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
