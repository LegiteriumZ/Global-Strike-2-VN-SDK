using System.Collections.Generic;
using SSJJBase.Extensions;

namespace Assets.Sources.Free.Auto;

public class AutoTimeStringOnceValue : AbstractAutoValue
{
	private List<string> values;

	public int totalTime;

	private bool usingEndValue = true;

	private int currentTime;

	private string currentValue;

	public AutoTimeStringOnceValue()
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
		if (index < values.Count)
		{
			return values[index];
		}
		return "";
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
				Started = false;
				if (usingEndValue)
				{
					currentTime = totalTime;
					return AutoValueData.S((values.Count > 0) ? values[values.Count - 1] : "");
				}
				currentTime = 0;
				return AutoValueData.S((values.Count > 0) ? values[0] : "");
			}
			int num = currentTime * values.Count / totalTime;
			currentTime += frameTime;
			return AutoValueData.S((values.Count > num) ? values[num] : "");
		}
		return AutoValueData.S(currentValue);
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split("_$$$_");
		if (array.Length > 3 && array[0] == "stringOnce")
		{
			AutoTimeStringOnceValue autoTimeStringOnceValue = new AutoTimeStringOnceValue();
			int.TryParse(array[1], out autoTimeStringOnceValue.totalTime);
			bool.TryParse(array[2], out autoTimeStringOnceValue.usingEndValue);
			for (int i = 3; i < array.Length; i++)
			{
				autoTimeStringOnceValue.values.Add(array[i]);
			}
			return autoTimeStringOnceValue;
		}
		return null;
	}

	public override void Start()
	{
		base.Start();
		currentTime = 0;
	}

	public override void SetValue(params string[] value)
	{
		if (value.Length >= 1)
		{
			currentValue = value[0];
		}
	}
}
