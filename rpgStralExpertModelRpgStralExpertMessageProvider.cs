using System.Collections.Generic;
using Assets.Sources.Components.Time;
using NetData;

public class rpgStralExpertModelRpgStralExpertMessageProvider : IrpgStralExpertModelRpgStralExpertMessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgStralExpertModelRpgStralExpertMessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool isShowMessage(int index)
	{
		int tipId = GetTipId(index);
		Dictionary<int, RpgTipsEventData> eventDataDic = _gameRuleContext.rpgCommon.EventDataDic;
		RpgTipsEventData value = null;
		if (eventDataDic != null)
		{
			eventDataDic.TryGetValue(tipId, out value);
			if (value != null)
			{
				return value.Show;
			}
		}
		return false;
	}

	private int GetTipId(int index)
	{
		return index switch
		{
			0 => -2547, 
			1 => -2548, 
			2 => -2549, 
			_ => -2547, 
		};
	}
}
