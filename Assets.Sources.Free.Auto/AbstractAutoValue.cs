using share;

namespace Assets.Sources.Free.Auto;

public abstract class AbstractAutoValue : IAutoValue
{
	public bool Started;

	public AutoValueData AutoValueData;

	protected AbstractAutoValue()
	{
		AutoValueData = new AutoValueData(0f, "", new Matrix3D(), new Vector3D());
	}

	protected void ConvertFtoSAutoValueData()
	{
		AutoValueData.String = string.Concat(AutoValueData.Float);
	}

	protected void ConvertStoFAutoValueData()
	{
		double.TryParse(AutoValueData.String, out AutoValueData.Float);
	}

	public virtual void Start()
	{
		Started = true;
	}

	public virtual void Stop()
	{
		Started = false;
	}

	public virtual string ValueToString()
	{
		return string.Concat(GetType());
	}

	public abstract IAutoValue Parse(string config);

	public virtual void SetValue(params string[] value)
	{
	}

	public virtual AutoValueData Frame(int frameTime)
	{
		return AutoValueData;
	}
}
