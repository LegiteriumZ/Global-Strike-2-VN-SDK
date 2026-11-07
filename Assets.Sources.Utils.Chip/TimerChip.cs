using Assets.Sources.Components.Time;

namespace Assets.Sources.Utils.Chip;

public class TimerChip : AbstractChip<float>
{
	public float Count;

	public float Speed;

	public float TargetCount;

	public float Update(TimeComponent time)
	{
		base.IsOver = false;
		Count += Speed * (float)time.FrameInterval / 1000f;
		if (Speed > 0f && Count > TargetCount)
		{
			base.IsOver = true;
			Count = TargetCount;
		}
		if (Speed < 0f && Count > TargetCount)
		{
			base.IsOver = true;
			Count = TargetCount;
		}
		return Cvalue = Count;
	}
}
