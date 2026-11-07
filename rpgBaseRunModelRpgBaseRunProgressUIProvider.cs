using Assets.Sources.Components.Time;

public class rpgBaseRunModelRpgBaseRunProgressUIProvider : IrpgBaseRunModelRpgBaseRunProgressUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgBaseRunModelRpgBaseRunProgressUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.rpgBaseRunData.TimeEnable && _gameRuleContext.rpgBaseRunData.CurTime > 0)
		{
			_gameRuleContext.rpgBaseRunData.CurTime -= time.FrameInterval;
			if (_gameRuleContext.rpgBaseRunData.CurTime < 0)
			{
				_gameRuleContext.rpgBaseRunData.CurTime = 0;
			}
		}
	}

	public bool checkRpgBaseRunUIShow()
	{
		return _gameRuleContext.rpgBaseRunData.Visible;
	}

	public float getBoxNum()
	{
		return _gameRuleContext.rpgBaseRunData.IconNum;
	}

	public string changeBoxImg()
	{
		return ("/ui/GameGUIRes/rpgBaseRunModel/Texture/boxIcon" + _gameRuleContext.rpgBaseRunData.IconId) ?? "";
	}

	public float getProgress()
	{
		return (float)_gameRuleContext.rpgBaseRunData.CurTime / (float)_gameRuleContext.rpgBaseRunData.TotalTime;
	}
}
