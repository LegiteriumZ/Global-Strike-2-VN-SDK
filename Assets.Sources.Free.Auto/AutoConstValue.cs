using SSJJBase.Extensions;

namespace Assets.Sources.Free.Auto;

public class AutoConstValue : AbstractAutoValue
{
	private string _currentValue;

	private float _curentValueF;

	public override string ValueToString()
	{
		return GetType().Name + " _currentValue : " + _currentValue;
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split("|");
		if (array.Length == 2 && array[0] == "const")
		{
			AutoConstValue autoConstValue = new AutoConstValue();
			autoConstValue._currentValue = array[1];
			autoConstValue.StrValueParseToF();
			return autoConstValue;
		}
		return null;
	}

	public override void SetValue(params string[] value)
	{
		if (value.Length >= 1)
		{
			_currentValue = value[0];
			StrValueParseToF();
		}
	}

	public void StrValueParseToF()
	{
		AutoValueData.S(_currentValue);
		ConvertStoFAutoValueData();
	}
}
