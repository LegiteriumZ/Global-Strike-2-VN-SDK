using Assets.Sources.Components.Time;

public class rpgLootModelPlayerGetFlagProvider : IrpgLootModelPlayerGetFlagProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgLootModelPlayerGetFlagProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float getCurrent()
	{
		return _gameRuleContext.rpgCommon.Current;
	}

	public float getMax()
	{
		return _gameRuleContext.rpgCommon.Max;
	}
}
