namespace Assets.Sources.Info.Res;

internal class BloodResConfig : BaseResConfig
{
	private readonly int _resId;

	private readonly int _ruleModel;

	public int RuleModel => _ruleModel;

	public int ResId => _resId;

	public BloodResConfig(string bundleName, string assetName, int resId, int ruleModel)
		: base(bundleName, assetName)
	{
		_resId = resId;
		_ruleModel = ruleModel;
	}
}
