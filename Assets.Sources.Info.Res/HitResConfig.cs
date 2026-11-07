namespace Assets.Sources.Info.Res;

internal class HitResConfig : BaseResConfig
{
	private readonly int _ramainTime;

	private readonly int _resId;

	private readonly int _ruleModel;

	public int RuleModel => _ruleModel;

	public int ResId => _resId;

	public int RamainTime => _ramainTime;

	public HitResConfig(string bundleName, string assetName, int resId, int ruleModel, int ramainTime)
		: base(bundleName, assetName)
	{
		_resId = resId;
		_ruleModel = ruleModel;
		_ramainTime = ramainTime;
	}
}
