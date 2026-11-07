using Assets.Sources.Components.Time;

public class commonChallengeAffixProvider : IcommonChallengeAffixProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public commonChallengeAffixProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		_gameRuleContext.battleRoomEvent.time -= time.FrameInterval;
	}

	public bool isShow()
	{
		return _gameRuleContext.battleRoomEvent.time > 0;
	}

	public string changeImage()
	{
		if (_gameRuleContext.battleRoomEvent.time > 0)
		{
			return "/ui/GameGUIRes/halfLoadedRes/challengeAffix/" + _gameRuleContext.battleRoomEvent.index;
		}
		return "";
	}
}
