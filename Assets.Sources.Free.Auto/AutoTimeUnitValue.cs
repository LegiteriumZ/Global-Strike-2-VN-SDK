using System;

namespace Assets.Sources.Free.Auto;

public class AutoTimeUnitValue : AbstractAutoValue
{
	public int unit;

	public float scale;

	public bool desc;

	private int currentValue;

	private int MINUTE = 60000;

	private int HOUR = 3600000;

	private int DAY = 86400000;

	public override string ValueToString()
	{
		return GetType().Name + " unit : " + unit + " scale " + scale;
	}

	public override AutoValueData Frame(int frameTime)
	{
		int num = 0;
		if (Started)
		{
			if (desc)
			{
				currentValue -= (int)((float)frameTime * scale);
			}
			else
			{
				currentValue += (int)((float)frameTime * scale);
			}
			num = unit switch
			{
				1 => currentValue % 1000, 
				2 => currentValue / 1000 % 60, 
				3 => currentValue / MINUTE % 60, 
				4 => currentValue / HOUR % 24, 
				5 => currentValue / DAY, 
				_ => 0, 
			};
		}
		if (num < 0)
		{
			num = 0;
		}
		return AutoValueData.F(num);
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split('|');
		if (array.Length == 4 && array[0] == "time-auto")
		{
			return new AutoTimeUnitValue
			{
				unit = int.Parse(array[1]),
				scale = float.Parse(array[2]),
				desc = ("true" == array[3])
			};
		}
		return null;
	}

	public override void SetValue(params string[] value)
	{
		if (value.Length >= 1)
		{
			currentValue = (int)Convert.ToSingle(value[0]);
		}
	}
}
