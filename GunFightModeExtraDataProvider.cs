public class GunFightModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/gunfightmodel";
		Providers.Add(new gunFightModelScoreBoardProvider(contexts));
		Providers.Add(new gunFightModelRoundScoreBoardProvider(contexts));
		Providers.Add(new gunFightModelPlayerNumNotProvider(contexts));
		Providers.Add(new gunFightModelStartTimerProvider(contexts));
		Providers.Add(new gunFightModelEndTimerProvider(contexts));
		Providers.Add(new gunFightModelBagPreviewProvider(contexts));
		Providers.Add(new gunFightModelRoundReviewProvider(contexts));
		Providers.Add(new gunFightModelRandomEffectProvider(contexts));
	}
}
