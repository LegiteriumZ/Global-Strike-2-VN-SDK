namespace Assets.Sources.Info.Res;

internal class ExplosionConfig : BaseResConfig
{
	public int EffectTime { get; set; }

	public int ResTypeId { get; set; }

	public int EventId { get; set; }

	public ExplosionConfig(ExplosionTable.Row row)
		: base(row.AssetBundle, row.AssetPath)
	{
		EventId = row.EventId;
		ResTypeId = row.ResTypeId;
		EffectTime = row.EffectTime;
	}
}
