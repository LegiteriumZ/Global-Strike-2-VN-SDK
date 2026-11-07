using System.Collections.Generic;
using Assets.Sources.Components.Time;
using NetData;

public class rpgLootMineModelRpgLootMineMessageProvider : IrpgLootMineModelRpgLootMineMessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgLootMineModelRpgLootMineMessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool isShowMessage(int index)
	{
		int tipID = GetTipID(index);
		Dictionary<int, RpgTipsEventData> eventDataDic = _gameRuleContext.rpgCommon.EventDataDic;
		RpgTipsEventData value = null;
		if (eventDataDic != null)
		{
			eventDataDic.TryGetValue(tipID, out value);
			if (value != null)
			{
				return value.Show;
			}
		}
		return false;
	}

	private int GetTipID(int index)
	{
		return index switch
		{
			0 => -2544, 
			1 => -2545, 
			2 => -2546, 
			_ => -2546, 
		};
	}
}
