namespace Assets.Sources.Info.Res;

internal class MoveEntityTailConfig : BaseResConfig
{
	public string Name { get; private set; }

	public int Width { get; private set; }

	public int RemainTime { get; private set; }

	public int ResIndex { get; private set; }

	public int DestinationFactor { get; private set; }

	public float FadeStart { get; private set; }

	public float TrailTime { get; private set; }

	public MoveEntityTailConfig(MoveEntityTailTable.Row row)
		: base(row.AssetBundle, row.AssetPath)
	{
		Width = row.Width;
		RemainTime = row.RemainTime;
		Name = row.Name;
		ResIndex = row.ResIndex;
		DestinationFactor = row.DestinationFactor;
		FadeStart = row.FadeStart;
		TrailTime = row.TrailTime;
	}
}
