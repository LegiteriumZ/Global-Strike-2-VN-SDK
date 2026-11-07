using Assets.Sources.Components.Time;

public class rpgTreasureBossModelTreasureBossDayLightProgressUIProvider : IrpgTreasureBossModelTreasureBossDayLightProgressUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgTreasureBossModelTreasureBossDayLightProgressUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.rpgTreasureBossData.ramainTime > 0)
		{
			_gameRuleContext.rpgTreasureBossData.ramainTime -= time.FrameInterval;
			if (_gameRuleContext.rpgTreasureBossData.ramainTime < 0)
			{
				_gameRuleContext.rpgTreasureBossData.ramainTime = 0;
			}
		}
	}

	public bool checkIsDay()
	{
		return _gameRuleContext.rpgTreasureBossData.isDay;
	}

	public float updateProgress()
	{
		float num = (float)_gameRuleContext.rpgTreasureBossData.ramainTime / (float)_gameRuleContext.rpgTreasureBossData.totalTime;
		return 0.1f + num * 0.8f;
	}

	public float getKeyCount()
	{
		return _gameRuleContext.rpgTreasureBossData.keyCount;
	}
}
