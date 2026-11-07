using Assets.Sources.Components.Time;

public class rpgStarWalkerModelRpgStarWalkerTipsUIProvider : IrpgStarWalkerModelRpgStarWalkerTipsUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private int[] tipsIndexArray;

	public rpgStarWalkerModelRpgStarWalkerTipsUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		tipsIndexArray = new int[10] { -141106, -141105, -141104, -141110, -141108, -141109, -141102, -141103, -141107, -141101 };
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.rpgStarWalker.topTipsTime > 0)
		{
			_gameRuleContext.rpgStarWalker.topTipsTime -= time.FrameInterval;
			if (_gameRuleContext.rpgStarWalker.topTipsTime < 0)
			{
				_gameRuleContext.rpgStarWalker.topTipsTime = 0;
			}
		}
	}

	public bool infectionIsShow()
	{
		if (_gameRuleContext.rpgStarWalker.topTipsId == -141101)
		{
			return _gameRuleContext.rpgStarWalker.topTipsTime > 0;
		}
		return false;
	}

	public bool playerNameIsShow()
	{
		if (_gameRuleContext.rpgStarWalker.topTipsId == -141108)
		{
			return _gameRuleContext.rpgStarWalker.topTipsTime > 0;
		}
		return false;
	}

	public float getNumInfection()
	{
		return _gameRuleContext.rpgStarWalker.numInfectCurrent;
	}

	public string getPlayerName()
	{
		return _gameRuleContext.rpgStarWalker.boxOwnerNameCurrent;
	}

	public bool checkShow()
	{
		return true;
	}

	public bool tipShowByIndex(int index)
	{
		int num = tipsIndexArray[index];
		if (_gameRuleContext.rpgStarWalker.topTipsId == num)
		{
			return _gameRuleContext.rpgStarWalker.topTipsTime > 0;
		}
		return false;
	}
}
