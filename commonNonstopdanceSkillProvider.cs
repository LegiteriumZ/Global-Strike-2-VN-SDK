using Assets.Sources.Components.Time;

public class commonNonstopdanceSkillProvider : IcommonNonstopdanceSkillProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private int _showOver;

	public commonNonstopdanceSkillProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		updateTime(time);
	}

	private void updateTime(TimeComponent time)
	{
		if (_gameRuleContext.nonStopData._showOver && _showOver == 0)
		{
			_showOver = 300;
		}
		if (_showOver > 0 && _gameRuleContext.nonStopData._showOver)
		{
			_showOver -= time.FrameInterval;
			if (_showOver <= 0)
			{
				_gameRuleContext.nonStopData._show = false;
			}
		}
		else
		{
			_showOver = 0;
		}
	}

	public bool isShow()
	{
		return _gameRuleContext.nonStopData._show;
	}

	public string showImage(int index)
	{
		string text = "unactive";
		if (index < _gameRuleContext.nonStopData._positionList.Count && _gameRuleContext.nonStopData._positionList[index] != "")
		{
			string text2 = _gameRuleContext.nonStopData._positionList[index];
			if (_gameRuleContext.nonStopData._positionResultList[index])
			{
				text = "active";
			}
			return "/ui/GameGUIRes/halfLoadedRes/weapon/nonstopdance_" + text + "_" + text2;
		}
		return "";
	}
}
