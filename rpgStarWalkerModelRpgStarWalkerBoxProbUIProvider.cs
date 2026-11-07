using Assets.Sources.Components.Time;

public class rpgStarWalkerModelRpgStarWalkerBoxProbUIProvider : IrpgStarWalkerModelRpgStarWalkerBoxProbUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private const int MAX_CNT_PUBBOX = 3;

	public rpgStarWalkerModelRpgStarWalkerBoxProbUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool checkShow()
	{
		return true;
	}

	public string getProb()
	{
		return _gameRuleContext.rpgStarWalker.pubBoxProb + "%";
	}

	public bool barShowByIndex(int index)
	{
		return index <= _gameRuleContext.rpgStarWalker.pubBoxRemainCnt - 1;
	}
}
