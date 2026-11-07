public class GoldRankModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/goldrankmodel";
		Providers.Add(new goldRankModelScoreBoardProvider(contexts));
		Providers.Add(new goldRankModelRoundScoreBoardProvider(contexts));
		Providers.Add(new goldRankModelPlayerNumNotProvider(contexts));
		Providers.Add(new goldRankModelStartTimerProvider(contexts));
		Providers.Add(new goldRankModelEndTimerProvider(contexts));
		Providers.Add(new goldRankModelBagPreviewProvider(contexts));
		Providers.Add(new goldRankModelRoundReviewProvider(contexts));
		Providers.Add(new goldRankModelRandomEffectProvider(contexts));
	}
}
