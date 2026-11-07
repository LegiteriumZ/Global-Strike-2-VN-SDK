using System;

namespace Assets.Sources.Free.Auto;

[Serializable]
public class AutoField
{
	public string field;

	public IAutoValue auto;

	public string autoName;

	public string autoToString;

	public AutoField(string field, IAutoValue auto)
	{
		this.field = field;
		this.auto = auto;
		if (this.auto != null)
		{
			autoName = auto.GetType().Name;
		}
	}
}
