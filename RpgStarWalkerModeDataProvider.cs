public class RpgStarWalkerModeDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/rpgstarwalkermodel";
		Providers.Add(new rpgStarWalkerModelRpgStarWalkerBoxProbUIProvider(contexts));
		Providers.Add(new rpgStarWalkerModelRpgStarWalkerProgressUIProvider(contexts));
		Providers.Add(new rpgStarWalkerModelRpgStarWalkerTargetUIProvider(contexts));
		Providers.Add(new rpgStarWalkerModelRpgStarWalkerTipsUIProvider(contexts));
	}
}
