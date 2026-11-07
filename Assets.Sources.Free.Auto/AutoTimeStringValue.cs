using System.Collections.Generic;
using SSJJBase.Extensions;

namespace Assets.Sources.Free.Auto;

public class AutoTimeStringValue : AbstractAutoValue
{
	private List<string> values;

	public int totalTime;

	private int currentTime;

	private string currentValue;

	public AutoTimeStringValue()
	{
		values = new List<string>();
	}

	public override string ValueToString()
	{
		string text = "";
		for (int i = 0; i < values.Count; i++)
		{
			text = text + values[i] + "_";
		}
		return GetType().Name + " totalTime : " + totalTime + " currentTime " + currentTime + "  values : " + text;
	}

	public string GetUrl(int index)
	{
		return values[index];
	}

	public int Size()
	{
		return values.Count;
	}

	public override AutoValueData Frame(int frameTime)
	{
		if (Started)
		{
			if (currentTime >= totalTime)
			{
				currentTime -= totalTime;
			}
			int num = currentTime * values.Count / totalTime;
			currentTime += frameTime;
			if (values.Count <= num)
			{
				return AutoValueData.S(currentValue);
			}
			return AutoValueData.S(values[num]);
		}
		return AutoValueData.S(currentValue);
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split("_$$$_");
		if (array.Length > 2 && array[0] == "string")
		{
			AutoTimeStringValue autoTimeStringValue = new AutoTimeStringValue();
			autoTimeStringValue.totalTime = int.Parse(array[1]);
			for (int i = 2; i < array.Length; i++)
			{
				autoTimeStringValue.values.Add(array[i]);
			}
			return autoTimeStringValue;
		}
		return null;
	}

	public override void SetValue(params string[] value)
	{
		if (value.Length >= 1)
		{
			currentValue = value[0];
		}
	}
}
