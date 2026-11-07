using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;
using share.constant;

public class bioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider : IbioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider, IModuleProvider
{
	protected PlayerContext _playerContext;

	protected GameRuleContext _gameRuleContext;

	public bioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float getAddLevel(int index)
	{
		List<int> levelList = _gameRuleContext.bioEvolutionChallenge.LevelList;
		if (levelList != null && levelList.Count > index)
		{
			return levelList[index];
		}
		return 0f;
	}

	public bool isShow()
	{
		return PlayerCareerUtil.IsNormalZombie(UiIEventCondition.Get_cameraOwnerData_Career());
	}
}
