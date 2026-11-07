using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class Vector2Chip : TimeSetChip<Vector2>
{
	protected override Vector2 JumpTo(float percent)
	{
		base.IsOver = DetermineIsOver(percent);
		percent = Mathf.Clamp01(percent);
		base.Value = Vector2.Lerp(base.Start, base.Target, percent);
		return base.Value;
	}
}
