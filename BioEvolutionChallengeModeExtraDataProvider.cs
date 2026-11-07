public class BioEvolutionChallengeModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "ui/bioevolutionchallengemodel";
		Providers.Add(new bioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider(contexts));
		Providers.Add(new bioEvolutionChallengeModelbioEvolutionChallengeMessageProvider(contexts));
		Providers.Add(new bioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider(contexts));
		Providers.Add(new bioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider(contexts));
		Providers.Add(new bioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider(contexts));
	}
}
