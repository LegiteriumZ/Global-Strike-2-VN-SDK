using System;
using SSJJBase.Extensions;

namespace Assets.Sources.Free.Auto;

public class AutoOneTimeValue : AbstractAutoValue
{
	public int from;

	public int to;

	public float step;

	private int currentValue;

	private int ms;

	public override string ValueToString()
	{
		return GetType().Name + " currentValue : " + currentValue + " ms : " + ms + "  from: " + from + "  to " + to;
	}

	public override AutoValueData Frame(int frameTime)
	{
		if (Started)
		{
			if (from > to)
			{
				ms -= frameTime;
				if ((float)ms < (float)to * step)
				{
					ms = (int)((float)to * step);
					currentValue = to;
				}
				else
				{
					currentValue = (int)((float)ms / step);
				}
			}
			else if (from < to)
			{
				ms += frameTime;
				if ((float)ms > (float)(to + 1) * step)
				{
					ms = (int)((float)(to + 1) * step);
					currentValue = to;
				}
				else
				{
					currentValue = (int)((float)ms / step);
				}
			}
			else
			{
				currentValue = from;
			}
		}
		return AutoValueData.F(currentValue);
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split("|");
		if (array.Length >= 4 && array[0] == "timeonce")
		{
			AutoOneTimeValue autoOneTimeValue = new AutoOneTimeValue();
			autoOneTimeValue.from = (int)Convert.ToSingle(array[2]);
			autoOneTimeValue.to = (int)Convert.ToSingle(array[3]);
			autoOneTimeValue.step = Convert.ToSingle(array[1]) / Convert.ToSingle(Math.Abs(autoOneTimeValue.from - autoOneTimeValue.to));
			autoOneTimeValue.currentValue = autoOneTimeValue.from;
			autoOneTimeValue.ms = (int)(autoOneTimeValue.step * (float)autoOneTimeValue.from);
			return autoOneTimeValue;
		}
		return null;
	}

	public override void SetValue(params string[] value)
	{
		if (value.Length >= 1)
		{
			string[] array = value[0].Split(",");
			if (array.Length == 4)
			{
				currentValue = (int)Convert.ToSingle(array[3]);
				from = (int)Convert.ToSingle(array[1]);
				to = (int)Convert.ToSingle(array[2]);
				step = Convert.ToSingle(array[0]) / Convert.ToSingle(Math.Abs(from - to));
				ms = (int)((float)currentValue * step);
			}
			else if (array.Length == 1)
			{
				currentValue = (int)Convert.ToSingle(array[0]);
				ms = (int)((float)currentValue * step);
			}
		}
	}
}
