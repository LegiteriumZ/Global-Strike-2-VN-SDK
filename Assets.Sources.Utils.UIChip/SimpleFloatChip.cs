using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class SimpleFloatChip : AbstractChip<float, float>
{
	public float Start;

	public float Target;

	protected override float JumpTo(float percent)
	{
		base.IsOver = DetermineIsOver(percent);
		percent = Mathf.Clamp01(percent);
		base.Value = Mathf.Lerp(Start, Target, percent);
		return base.Value;
	}
}
