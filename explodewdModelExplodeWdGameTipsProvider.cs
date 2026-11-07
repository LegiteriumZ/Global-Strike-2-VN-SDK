using System.Collections.Generic;
using Assets.Sources.Components.Time;
using NetData;

public class explodewdModelExplodeWdGameTipsProvider : IexplodewdModelExplodeWdGameTipsProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private int _showTipsId;

	private string _branchUrl;

	private int _showTime;

	public explodewdModelExplodeWdGameTipsProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.hasExplodewdData && _gameRuleContext.explodewdData.TipsData != null && _gameRuleContext.explodewdData.TipsData.Count > 0)
		{
			foreach (KeyValuePair<int, RpgTipsEventData> tipsDatum in _gameRuleContext.explodewdData.TipsData)
			{
				if (tipsDatum.Key >= -2625 && tipsDatum.Key <= -2622)
				{
					if (tipsDatum.Value.Show)
					{
						_showTipsId = tipsDatum.Value.TypeId;
						_showTime = 3000;
					}
					else if (_showTipsId == tipsDatum.Value.TypeId)
					{
						_showTipsId = -1;
						_showTime = 0;
					}
					if (tipsDatum.Key == -2625)
					{
						_branchUrl = tipsDatum.Value.Time1.ToString();
					}
				}
			}
			_gameRuleContext.explodewdData.TipsData.Clear();
		}
		_showTime -= time.FrameInterval;
	}

	public bool showGetC4()
	{
		if (_showTime > 0)
		{
			return _showTipsId == -2622;
		}
		return false;
	}

	public bool showUseC4()
	{
		if (_showTime > 0)
		{
			return _showTipsId == -2623;
		}
		return false;
	}

	public bool showLevelGame()
	{
		if (_showTime > 0)
		{
			return _showTipsId == -2624;
		}
		return false;
	}

	public bool showFindBranch()
	{
		if (_showTime > 0)
		{
			return _showTipsId == -2625;
		}
		return false;
	}

	public string getBranchUrl()
	{
		return $"/ui/GameGUIRes/explodewdModel/message/{_branchUrl}";
	}
}
