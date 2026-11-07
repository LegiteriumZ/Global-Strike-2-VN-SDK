using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class Time3Rangefloat : AbstractChip<float, float>
{
	public float Start;

	public float MidStart;

	public float MidEnd;

	public float Target;

	protected override float JumpTo(float percent)
	{
		base.IsOver = DetermineIsOver(percent);
		percent = Mathf.Clamp01(percent);
		if (base.IsOver)
		{
			return 0f;
		}
		float num = Mathf.Abs(Start - MidStart);
		float num2 = Mathf.Abs(MidEnd - MidStart);
		float num3 = Mathf.Abs(MidEnd - Target);
		float num4 = num + num2 + num3;
		float num5 = num / num4;
		if (percent < num5)
		{
			base.Value = Mathf.Lerp(0f, 1f, percent / num5);
			return base.Value;
		}
		float num6 = num2 / num4;
		if (percent > num5 && percent < num5 + num6)
		{
			base.Value = 1f;
			return base.Value;
		}
		float num7 = 1f - num5 - num6;
		if (percent > num5 + num6 && percent < 1f)
		{
			base.Value = Mathf.Lerp(1f, 0f, (percent - num5 - num6) / num7);
			return base.Value;
		}
		base.Value = Target;
		return base.Value;
	}
}
