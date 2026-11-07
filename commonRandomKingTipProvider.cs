using Assets.Sources.Components.Time;

public class commonRandomKingTipProvider : IcommonRandomKingTipProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public commonRandomKingTipProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		UpTime(time);
	}

	public void UpTime(TimeComponent time)
	{
		for (int i = 0; i < _gameRuleContext.randomKing.TipTimeID.Count; i++)
		{
			if (i >= _gameRuleContext.randomKing.TipTimeID.Count)
			{
				continue;
			}
			int item = _gameRuleContext.randomKing.TipTimeID[i];
			int num = _gameRuleContext.randomKing.TipId.IndexOf(item);
			if (_gameRuleContext.randomKing.TipTimeVaule[i] > 0)
			{
				_gameRuleContext.randomKing.TipTimeVaule[i] -= time.FrameInterval;
			}
			if (_gameRuleContext.randomKing.TipTimeVaule[i] > 0)
			{
				if (num == -1)
				{
					_gameRuleContext.randomKing.TipId.Add(item);
				}
			}
			else if (num != -1)
			{
				_gameRuleContext.randomKing.TipId.RemoveAt(num);
			}
		}
	}

	public string showString(int index)
	{
		if (index < _gameRuleContext.randomKing.TipId.Count)
		{
			return "/ui/GameGUIRes/halfLoadedRes/randomKing/tip" + _gameRuleContext.randomKing.TipId[index];
		}
		return "";
	}

	public bool getVisible(int index)
	{
		if (index < _gameRuleContext.randomKing.TipId.Count)
		{
			return true;
		}
		return false;
	}
}
