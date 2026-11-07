namespace Assets.Sources.Info.Res;

internal class MoveEntityConfig : BaseResConfig
{
	public string Name { get; private set; }

	public string Class { get; private set; }

	public MoveEntityConfig(MoveEntityTable.Row row)
		: base(row.AssetBundle, row.AssetPath)
	{
		Name = row.Name;
		Class = row.Class;
	}
}
