using Assets.Sources.Components.Time;

public class commonVideoMessageProvider : IcommonVideoMessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public commonVideoMessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool isVideo()
	{
		return false;
	}

	public bool isCrimialSuspectDead()
	{
		return false;
	}

	public bool isCrimialSuspectOut()
	{
		return false;
	}
}
