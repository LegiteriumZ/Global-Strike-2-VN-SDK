using Assets.Sources.Components.Time;
using UnityEngine;

namespace Assets.Sources.Utils.Chip;

public class PingPongChip : AbstractChip<float>
{
	public float From;

	public float To;

	public int Time;

	public int RunTime;

	public float Update(TimeComponent time)
	{
		base.IsOver = false;
		if (Time <= 0)
		{
			return From;
		}
		RunTime += time.FrameInterval;
		return Cvalue = Mathf.PingPong((float)RunTime / (float)Time, 1f) * (To - From) + From;
	}
}
