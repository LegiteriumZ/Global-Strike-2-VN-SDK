namespace Assets.Sources.Info.Res;

internal class CommonParticleResConfig : BaseResConfig
{
	private readonly string _key;

	private readonly string _type;

	private readonly int _yawTrim;

	private readonly int _pitchTrim;

	public string Type => _type;

	public string Key => _key;

	public int YawTrim => _yawTrim;

	public int PitchTrim => _pitchTrim;

	public CommonParticleResConfig(string key, string assetBundle, string assetPath, string type, int yawTrim, int pitchTrim)
		: base(assetBundle, assetPath)
	{
		_key = key;
		_type = type;
		_yawTrim = yawTrim;
		_pitchTrim = pitchTrim;
	}
}
