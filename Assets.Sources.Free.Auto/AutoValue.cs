using System.Collections.Generic;

namespace Assets.Sources.Free.Auto;

public class AutoValue
{
	private static List<IAutoValue> _values;

	public static IAutoValue Parse(string config)
	{
		if (_values == null)
		{
			_values = new List<IAutoValue>();
			_values.Add(new AutoConstValue());
			_values.Add(new AutoPercentValue());
			_values.Add(new AutoPlayerValue());
			_values.Add(new AutoTimeValue());
			_values.Add(new AutoRotateValue());
			_values.Add(new AutoTimeStringValue());
			_values.Add(new AutoPositionValue());
			_values.Add(new AutoTwoPositionValue());
			_values.Add(new AutoTimeUnitValue());
			_values.Add(new AutoClientValue());
			_values.Add(new AutoOneTimeValue());
			_values.Add(new AutoTimeStringOnceValue());
			_values.Add(new AutoBindValue());
		}
		for (int i = 0; i < _values.Count; i++)
		{
			IAutoValue autoValue = _values[i].Parse(config);
			if (autoValue != null)
			{
				return autoValue;
			}
		}
		return null;
	}
}
