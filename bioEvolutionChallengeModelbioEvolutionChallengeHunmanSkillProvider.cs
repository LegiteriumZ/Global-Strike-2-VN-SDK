using Assets.Sources.Components.Time;

public class bioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider : IbioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool isShow()
	{
		return false;
	}

	public string getSkillTypeFUrl()
	{
		return "";
	}

	public bool isBackShow()
	{
		return false;
	}

	public string getSkillTypeFBackUrl()
	{
		return "";
	}

	public string getSkillTypeNoKeyUrl()
	{
		return "";
	}

	public float getWaitProgress()
	{
		return 0f;
	}
}
