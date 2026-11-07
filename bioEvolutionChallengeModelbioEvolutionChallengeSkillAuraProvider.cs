using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;
using share.constant;

public class bioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider : IbioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	public bioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool isShow()
	{
		return PlayerCareerUtil.IsZombieHero(UiIEventCondition.Get_cameraOwnerData_Career());
	}

	public bool isShowDeathArua()
	{
		return UiIEventCondition.Get_cameraOwnerData_Career() == "death";
	}

	public bool isShowPandoraArua()
	{
		return UiIEventCondition.Get_cameraOwnerData_Career() == "pandoraMonther";
	}

	public float getNumber()
	{
		return _gameRuleContext.bioEvolutionChallenge.AuraLevel;
	}
}
