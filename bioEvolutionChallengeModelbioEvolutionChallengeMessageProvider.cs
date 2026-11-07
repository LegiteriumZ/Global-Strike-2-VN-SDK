using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NetData;

public class bioEvolutionChallengeModelbioEvolutionChallengeMessageProvider : IbioEvolutionChallengeModelbioEvolutionChallengeMessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private readonly Dictionary<int, int> _leftTimes = new Dictionary<int, int>();

	public bioEvolutionChallengeModelbioEvolutionChallengeMessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_leftTimes.Add(12201, -1);
		_leftTimes.Add(12202, -1);
		_leftTimes.Add(12203, -1);
		_leftTimes.Add(12204, -1);
	}

	public void OnFrame(TimeComponent time)
	{
		RefreshTime(12201, time);
		RefreshTime(12202, time);
		RefreshTime(12203, time);
		RefreshTime(12204, time);
	}

	private void RefreshTime(int key, TimeComponent time)
	{
		_leftTimes[key] -= time.FrameInterval;
		if (_leftTimes[key] < 0)
		{
			_leftTimes[key] = 0;
		}
	}

	private RpgTipsEventData GetEventData(int type)
	{
		List<RpgTipsEventData> gameTipsShow_TipsEvent = UiIEventCondition.Get_gameTipsShow_TipsEvent();
		RpgTipsEventData rpgTipsEventData = null;
		foreach (RpgTipsEventData item in gameTipsShow_TipsEvent)
		{
			if (item.TypeId == type)
			{
				rpgTipsEventData = item;
			}
		}
		if (rpgTipsEventData != null)
		{
			gameTipsShow_TipsEvent.Remove(rpgTipsEventData);
		}
		return rpgTipsEventData;
	}

	public bool isShowMessage(int index)
	{
		int gameUiTipsConst = getGameUiTipsConst(index);
		RpgTipsEventData eventData = GetEventData(gameUiTipsConst);
		if (eventData != null)
		{
			if (gameUiTipsConst == 12202 || gameUiTipsConst == 12201)
			{
				if (eventData.Show)
				{
					_leftTimes[gameUiTipsConst] = 1000;
				}
				else
				{
					_leftTimes[gameUiTipsConst] = -1;
				}
			}
			else
			{
				_leftTimes[gameUiTipsConst] = 3000;
			}
		}
		return _leftTimes[gameUiTipsConst] > 0;
	}

	private int getGameUiTipsConst(int index)
	{
		return index switch
		{
			0 => 12204, 
			1 => 12203, 
			2 => 12202, 
			3 => 12201, 
			_ => 12204, 
		};
	}
}
