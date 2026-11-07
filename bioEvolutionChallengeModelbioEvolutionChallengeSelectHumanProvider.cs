using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NetData;
using share.constant;

public class bioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider : IbioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		_gameRuleContext.bioEvolutionChallenge.SelectHumanVisibleTime -= time.FrameInterval;
	}

	public bool isSelect(int index)
	{
		return index + 1 == _gameRuleContext.bioEvolutionChallenge.SelectHumanSelectId;
	}

	public bool isShow()
	{
		if (!PlayerCareerUtil.IsHumanity(UiIEventCondition.Get_cameraOwnerData_Career()))
		{
			return false;
		}
		return _gameRuleContext.bioEvolutionChallenge.SelectHumanVisibleTime > 0;
	}

	public float select1()
	{
		sendSelectHumanBattleCareer(1);
		return 0f;
	}

	public float select2()
	{
		sendSelectHumanBattleCareer(2);
		return 0f;
	}

	public float select3()
	{
		sendSelectHumanBattleCareer(3);
		return 0f;
	}

	private void sendSelectHumanBattleCareer(int selectId)
	{
		IntData message = new IntData
		{
			Data = selectId
		};
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(119, message);
		_gameRuleContext.bioEvolutionChallenge.SelectHumanVisibleTime = -1;
	}

	public float getTime()
	{
		return _gameRuleContext.bioEvolutionChallenge.SelectHumanVisibleTime / 1000 + 1;
	}
}
