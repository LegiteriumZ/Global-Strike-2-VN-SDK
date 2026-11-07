using Assets.Sources.Components.Time;

public class mechKingModelmechKingOtherMessageProvider : ImechKingModelmechKingOtherMessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public mechKingModelmechKingOtherMessageProvider(Contexts contexts)
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
}
