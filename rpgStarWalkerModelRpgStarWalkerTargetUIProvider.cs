using Assets.Sources.Components.Time;

public class rpgStarWalkerModelRpgStarWalkerTargetUIProvider : IrpgStarWalkerModelRpgStarWalkerTargetUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgStarWalkerModelRpgStarWalkerTargetUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float getCurProtectNum()
	{
		return _gameRuleContext.rpgStarWalker.numTargetCurrent;
	}

	public bool checkShow()
	{
		return _gameRuleContext.rpgStarWalker.numTargetTotal != 0;
	}

	public float getTotalProtectNum()
	{
		return _gameRuleContext.rpgStarWalker.numTargetTotal;
	}
}
