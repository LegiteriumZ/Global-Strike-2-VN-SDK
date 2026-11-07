using Assets.Sources.Components.Time;

public class commonWeaponPromptProvider : IcommonWeaponPromptProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public commonWeaponPromptProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}
}
