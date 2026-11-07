using Assets.Sources.Components.Time;

public class rpgTreasureBossModelTreasureBossTipsUIProvider : IrpgTreasureBossModelTreasureBossTipsUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private int[] tipsIndexArray;

	public rpgTreasureBossModelTreasureBossTipsUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		tipsIndexArray = new int[5] { -141006, -141004, -141007, -141008, -141003 };
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.rpgTreasureBossData.topTipsTime > 0)
		{
			_gameRuleContext.rpgTreasureBossData.topTipsTime -= time.FrameInterval;
			if (_gameRuleContext.rpgTreasureBossData.topTipsTime < 0)
			{
				_gameRuleContext.rpgTreasureBossData.topTipsTime = 0;
			}
		}
		if (_gameRuleContext.rpgTreasureBossData.bottomTipsTime > 0)
		{
			_gameRuleContext.rpgTreasureBossData.bottomTipsTime -= time.FrameInterval;
			if (_gameRuleContext.rpgTreasureBossData.bottomTipsTime < 0)
			{
				_gameRuleContext.rpgTreasureBossData.bottomTipsTime = 0;
			}
		}
	}

	public bool tipBtnBIsShow()
	{
		return _gameRuleContext.rpgTreasureBossData.bottomTipsTime > 0;
	}

	public bool tipEnterRoomIsShow()
	{
		if (_gameRuleContext.rpgTreasureBossData.topTipsId == -141005)
		{
			return _gameRuleContext.rpgTreasureBossData.topTipsTime > 0;
		}
		return false;
	}

	public string updatePlayerName()
	{
		return _gameRuleContext.rpgTreasureBossData.cbtPlayerName;
	}

	public float updateCbtLvl()
	{
		if (string.IsNullOrEmpty(_gameRuleContext.rpgTreasureBossData.cbtLvl))
		{
			return 0f;
		}
		return float.Parse(_gameRuleContext.rpgTreasureBossData.cbtLvl);
	}

	public bool tipShowByIndex(int index)
	{
		int num = tipsIndexArray[index];
		if (_gameRuleContext.rpgTreasureBossData.topTipsId == num)
		{
			return _gameRuleContext.rpgTreasureBossData.topTipsTime > 0;
		}
		return false;
	}
}
