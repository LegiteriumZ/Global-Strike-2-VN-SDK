using Assets.Sources.Components.Interface.Info.Map;

namespace Assets.Sources.Info.Map;

public class DefaultMapInfo : IMapInfo
{
	private int _id;

	private string _assetBundleName;

	private string _assetName;

	public int Id => _id;

	public string Name { get; set; }

	public int DataType { get; set; }

	public int Width { get; set; }

	public int Height { get; set; }

	public string AssetBundleName => _assetBundleName;

	public string AssetName => _assetName;

	public string MapPhysicsAssetName => "model.bsp.raw.bytes";

	public DefaultMapInfo(int id)
	{
		_id = id;
		_assetBundleName = $"maps/map{_id}";
		_assetName = $"{_id}";
	}
}
