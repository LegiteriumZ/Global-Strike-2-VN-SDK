using Assets.Sources.Components.Time;

public class freeRpg_107000ModelCanSelectModeProvider : IfreeRpg_107000ModelCanSelectModeProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public freeRpg_107000ModelCanSelectModeProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool IsShowCanSeletMode()
	{
		return _gameRuleContext.mystery.IsShowCanSelectModeTips;
	}
}
