using Assets.Generated.Table;

namespace Assets.Sources.Info.Res;

internal class HoleResConfig : BaseResConfig
{
	private readonly int _resId;

	public int ResId => _resId;

	public HoleResConfig(WeaponHoleTable.Row row)
		: base(row.BundleName, row.AssetName)
	{
		_resId = row.ResId;
	}

	public HoleResConfig(string bundleName, string assetName, int resid)
		: base(bundleName, assetName)
	{
		_resId = resid;
	}
}
