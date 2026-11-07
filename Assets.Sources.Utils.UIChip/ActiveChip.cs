using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class ActiveChip : AbstractChip<bool, bool>
{
	public bool Changed { get; private set; }

	protected override bool JumpTo(float percent)
	{
		bool flag = DetermineIsOver(percent);
		Changed = base.IsOver != flag;
		base.IsOver = flag;
		percent = Mathf.Clamp01(percent);
		base.Value = !base.IsOver;
		return base.Value;
	}
}
