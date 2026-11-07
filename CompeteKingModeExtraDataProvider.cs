public class CompeteKingModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/competekingmodel";
		Providers.Add(new CompeteKingModelTopScoreBoardProvider(contexts));
		Providers.Add(new CompeteKingModelBottomScoreBoardProvider(contexts));
		Providers.Add(new CompeteKingModelRoundReviewProvider(contexts));
		Providers.Add(new CompeteKingModelBagPreviewProvider(contexts));
		Providers.Add(new CompeteKingModelEndTimerProvider(contexts));
		Providers.Add(new CompeteKingModelRandomEffectProvider(contexts));
		Providers.Add(new CompeteKingModelStartTimerProvider(contexts));
	}
}
