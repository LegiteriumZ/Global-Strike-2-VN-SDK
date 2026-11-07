public class RpgTreasureBossModeDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/rpgtreasurebossmodel";
		Providers.Add(new rpgTreasureBossModelTreasureBossBtnCsUIProvider(contexts));
		Providers.Add(new rpgTreasureBossModelTreasureBossChuansongUIProvider(contexts));
		Providers.Add(new rpgTreasureBossModelTreasureBossDayLightProgressUIProvider(contexts));
		Providers.Add(new rpgTreasureBossModelTreasureBossTipsUIProvider(contexts));
	}
}
