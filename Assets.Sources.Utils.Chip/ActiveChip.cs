using Assets.Sources.Components.Time;

namespace Assets.Sources.Utils.Chip;

public class ActiveChip : AbstractChip<bool>
{
	public int Time;

	public int maxTime;

	public string BundleName;

	public string AssetName;

	public bool Changed;

	public bool Update(TimeComponent time)
	{
		base.IsOver = false;
		Time -= time.FrameInterval;
		if (Time > 0)
		{
			Changed = !Cvalue;
			return Cvalue = true;
		}
		base.IsOver = true;
		Changed = Cvalue;
		return Cvalue = false;
	}

	public bool UpdateAdd(TimeComponent time)
	{
		base.IsOver = false;
		Time += time.FrameInterval;
		if (Time < maxTime)
		{
			Changed = !Cvalue;
			return Cvalue = true;
		}
		base.IsOver = true;
		Changed = Cvalue;
		return Cvalue = false;
	}
}
