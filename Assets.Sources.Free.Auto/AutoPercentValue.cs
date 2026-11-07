using SSJJBase.Extensions;
using UnityEngine;

namespace Assets.Sources.Free.Auto;

public class AutoPercentValue : AbstractAutoValue
{
	private IAutoValue max;

	private IAutoValue current;

	private double currentValue;

	public override string ValueToString()
	{
		return GetType().Name + " max : " + current.ValueToString() + " |current : " + current.ValueToString();
	}

	public override AutoValueData Frame(int frameTime)
	{
		if (Started)
		{
			double @float = current.Frame(frameTime).Float;
			double float2 = max.Frame(frameTime).Float;
			double num = float2;
			if (Mathf.Abs((float)num) > 0.001f)
			{
				num = @float / float2;
			}
			currentValue = num;
		}
		if (double.IsNaN(currentValue))
		{
			currentValue = 1.0;
		}
		return AutoValueData.F(currentValue);
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split("|");
		if (array.Length > 2 && array[0] == "percent")
		{
			AutoPercentValue autoPercentValue = new AutoPercentValue();
			string[] array2 = config.Substring(config.IndexOf("|") + 1).Split("->");
			autoPercentValue.current = AutoValue.Parse(array2[0]);
			autoPercentValue.max = AutoValue.Parse(array2[1]);
			return autoPercentValue;
		}
		return null;
	}

	public override void Start()
	{
		base.Start();
		current.Start();
		max.Start();
	}

	public override void Stop()
	{
		base.Stop();
		current.Stop();
		max.Stop();
	}

	public override void SetValue(params string[] value)
	{
		if (value.Length >= 1)
		{
			current.SetValue(value[0]);
		}
		if (value.Length >= 2)
		{
			max.SetValue(value[1]);
		}
		currentValue = current.Frame(0).Float / max.Frame(0).Float;
	}
}
