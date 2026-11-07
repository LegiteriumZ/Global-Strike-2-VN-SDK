using System;
using SSJJBase.Extensions;

namespace Assets.Sources.Free.Auto;

public class AutoTimeValue : AbstractAutoValue
{
	public int from;

	public int to;

	public float step;

	private bool reverse;

	private int currentValue;

	private int ms;

	public override string ValueToString()
	{
		return GetType().Name + " ms : " + ms + " from " + from + "  to " + to;
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
					if (reverse)
					{
						int num = from;
						from = to;
						to = num;
					}
					else
					{
						ms = (int)((float)ms + (float)(from - to + 1) * step);
					}
				}
				currentValue = (int)((float)ms / step);
			}
			else if (from < to)
			{
				ms += frameTime;
				if ((float)ms > (float)(to + 1) * step)
				{
					if (reverse)
					{
						int num2 = from;
						from = to;
						to = num2;
					}
					else
					{
						ms = (int)((float)ms - (float)(to - from + 1) * step);
					}
				}
				currentValue = (int)((float)ms / step);
			}
			else
			{
				currentValue = from;
			}
		}
		AutoValueData.S(currentValue.ToString());
		return AutoValueData.F(currentValue);
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split("|");
		if (array.Length >= 4 && array[0] == "time")
		{
			AutoTimeValue autoTimeValue = new AutoTimeValue();
			autoTimeValue.from = (int)Convert.ToSingle(array[2]);
			autoTimeValue.to = (int)Convert.ToSingle(array[3]);
			autoTimeValue.step = Convert.ToSingle(array[1]) / Convert.ToSingle(Math.Abs(autoTimeValue.from - autoTimeValue.to));
			autoTimeValue.reverse = "true" == array[4];
			return autoTimeValue;
		}
		return null;
	}

	public override void SetValue(params string[] value)
	{
		if (value.Length >= 1)
		{
			currentValue = (int)Convert.ToSingle(value[0]);
			ms = (int)((float)currentValue * step);
		}
	}
}
