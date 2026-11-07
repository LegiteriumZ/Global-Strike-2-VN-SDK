using Assets.Sources.Components.Time;

public class freeRpg_107000ModelCanSelectSpecailPlayerProvider : IfreeRpg_107000ModelCanSelectSpecailPlayerProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public freeRpg_107000ModelCanSelectSpecailPlayerProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool IsShowSelectPlayer()
	{
		return _gameRuleContext.mystery.IsCanSelectPlayer;
	}
}
