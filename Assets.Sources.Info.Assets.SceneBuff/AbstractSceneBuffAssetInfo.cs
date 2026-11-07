namespace Assets.Sources.Info.Assets.SceneBuff;

public abstract class AbstractSceneBuffAssetInfo
{
	private string _name;

	public string Name => _name;

	protected AbstractSceneBuffAssetInfo(string name)
	{
		_name = name;
	}
}
