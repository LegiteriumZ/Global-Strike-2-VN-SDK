public class KnifeFightModeExtraDataProvider : GunFightModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/knifefightmodel";
		Providers.Add(new knifeFightModelScoreBoardProvider(contexts));
		Providers.Add(new knifeFightModelRoundScoreBoardProvider(contexts));
		Providers.Add(new knifeFightModelPlayerNumNotProvider(contexts));
		Providers.Add(new knifeFightModelStartTimerProvider(contexts));
		Providers.Add(new knifeFightModelEndTimerProvider(contexts));
		Providers.Add(new knifeFightModelBagPreviewProvider(contexts));
		Providers.Add(new knifeFightModelRoundReviewProvider(contexts));
		Providers.Add(new knifeFightModelRandomEffectProvider(contexts));
	}
}
