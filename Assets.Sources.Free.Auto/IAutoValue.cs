namespace Assets.Sources.Free.Auto;

public interface IAutoValue
{
	void Start();

	void Stop();

	IAutoValue Parse(string config);

	void SetValue(params string[] value);

	AutoValueData Frame(int frameTime);

	string ValueToString();
}
