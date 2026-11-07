using Assets.Sources.Components.Time;

public class bioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider : IbioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float getAddLevel(int index)
	{
		return 0f;
	}

	public bool isShow()
	{
		return false;
	}
}
