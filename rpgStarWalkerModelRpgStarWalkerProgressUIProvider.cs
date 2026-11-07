using Assets.Sources.Components.Time;

public class rpgStarWalkerModelRpgStarWalkerProgressUIProvider : IrpgStarWalkerModelRpgStarWalkerProgressUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private const int offsetUIheightExit = 36;

	private const int offsetUIheightBoss = 33;

	private const int barUIheight = 400;

	public rpgStarWalkerModelRpgStarWalkerProgressUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float getIconBossY()
	{
		float num = (float)_gameRuleContext.rpgStarWalker.numInfectBoss / (float)_gameRuleContext.rpgStarWalker.numInfectTotal;
		return 33f + 400f * (1f - num);
	}

	public float getIconExitY()
	{
		float num = (float)_gameRuleContext.rpgStarWalker.numInfectExit / (float)_gameRuleContext.rpgStarWalker.numInfectTotal;
		return 36f + 400f * (1f - num);
	}

	public string getNumInfection()
	{
		return _gameRuleContext.rpgStarWalker.numInfectCurrent.ToString();
	}

	public float getInfectionRate()
	{
		if (_gameRuleContext.rpgStarWalker.numInfectTotal == 0)
		{
			return 1f;
		}
		return (float)_gameRuleContext.rpgStarWalker.numInfectCurrent / (float)_gameRuleContext.rpgStarWalker.numInfectTotal;
	}

	public bool checkShow()
	{
		return true;
	}
}
