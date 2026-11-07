using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;

public class commonSelfUseExpressionProvider : IcommonSelfUseExpressionProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public commonSelfUseExpressionProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.personalized.ShowExpressions == null)
		{
			return;
		}
		foreach (ShowExpression showExpression in _gameRuleContext.personalized.ShowExpressions)
		{
			if (showExpression.RemainTime > 0)
			{
				showExpression.RemainTime -= time.FrameInterval;
			}
		}
	}

	public bool isShow()
	{
		int uiMyPlayer_PlayerId = UiIEventCondition.Get_uiMyPlayer_PlayerId();
		List<ShowExpression> showExpressions = _gameRuleContext.personalized.ShowExpressions;
		if (showExpressions != null)
		{
			for (int i = 0; i < showExpressions.Count; i++)
			{
				if (showExpressions[i].Id == uiMyPlayer_PlayerId && showExpressions[i].RemainTime > 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public string getExpressionUrl()
	{
		int uiMyPlayer_PlayerId = UiIEventCondition.Get_uiMyPlayer_PlayerId();
		List<ShowExpression> showExpressions = _gameRuleContext.personalized.ShowExpressions;
		if (showExpressions != null)
		{
			for (int i = 0; i < showExpressions.Count; i++)
			{
				if (showExpressions[i].Id == uiMyPlayer_PlayerId && showExpressions[i].RemainTime > 0)
				{
					return "/ui/GameGUIRes/halfLoadedRes/expression/" + showExpressions[i].CodeName;
				}
			}
		}
		return "";
	}
}
