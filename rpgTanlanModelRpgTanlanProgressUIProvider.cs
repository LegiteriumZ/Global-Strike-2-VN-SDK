using Assets.Sources.Components.Time;

public class rpgTanlanModelRpgTanlanProgressUIProvider : IrpgTanlanModelRpgTanlanProgressUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgTanlanModelRpgTanlanProgressUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool checkShow()
	{
		return _gameRuleContext.rpgTanlan.deathUIShow;
	}

	public float updateProgress()
	{
		return (float)_gameRuleContext.rpgTanlan.deathUITime1 / (float)_gameRuleContext.rpgTanlan.deathUITime2;
	}

	public string updateIcon()
	{
		if (_gameRuleContext.rpgTanlan.deathUITime1 < 4)
		{
			return "/ui/GameGUIRes/rpgTanlanModel/Texture/icon0";
		}
		if (_gameRuleContext.rpgTanlan.deathUITime1 >= 5 && _gameRuleContext.rpgTanlan.deathUITime1 <= 9)
		{
			return "/ui/GameGUIRes/rpgTanlanModel/Texture/icon1";
		}
		if (_gameRuleContext.rpgTanlan.deathUITime1 >= 10 && _gameRuleContext.rpgTanlan.deathUITime1 <= 14)
		{
			return "/ui/GameGUIRes/rpgTanlanModel/Texture/icon2";
		}
		return "/ui/GameGUIRes/rpgTanlanModel/Texture/icon3";
	}
}
