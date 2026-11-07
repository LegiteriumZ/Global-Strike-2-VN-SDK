namespace Assets.Sources.Info.Res;

internal class RailResConfig : BaseResConfig
{
	private readonly int _resId;

	public int ResId => _resId;

	public RailResConfig(string bundleName, string assetName, int resId)
		: base(bundleName, assetName)
	{
		_resId = resId;
	}

	public RailResConfig(WeaponRailTable.Row row)
		: this(row.BundleName, row.AssetName, row.ResId)
	{
	}
}
