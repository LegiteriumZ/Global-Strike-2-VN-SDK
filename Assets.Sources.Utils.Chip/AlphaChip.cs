using Assets.Sources.Components.Time;

namespace Assets.Sources.Utils.Chip;

public class AlphaChip : AbstractChip<float>
{
	public float Alpha;

	public float Speed;

	public float Delay;

	public float Update(TimeComponent time)
	{
		base.IsOver = false;
		Delay -= time.FrameInterval;
		if (Delay > 0f)
		{
			return Cvalue = Alpha;
		}
		Alpha += Speed * (float)time.FrameInterval / 1000f;
		if (Alpha > 1f)
		{
			base.IsOver = true;
			Alpha = 1f;
		}
		if (Alpha < 0f)
		{
			base.IsOver = true;
			Alpha = 0f;
		}
		return Cvalue = Alpha;
	}
}
