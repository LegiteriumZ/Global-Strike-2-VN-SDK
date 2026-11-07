using System.Collections.Generic;
using Assets.Sources.Components.Time;
using NetData;

public class rpgLootModelMessageProvider : IrpgLootModelMessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgLootModelMessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	private RpgTipsEventData GetEventData(int typeId)
	{
		Dictionary<int, RpgTipsEventData> eventDataDic = _gameRuleContext.rpgCommon.EventDataDic;
		RpgTipsEventData value = null;
		eventDataDic?.TryGetValue(typeId, out value);
		return value;
	}

	public bool isShowNoOccupy()
	{
		return GetEventData(-2541)?.Show ?? false;
	}

	public bool isShowGetMoreFlag()
	{
		return GetEventData(-2543)?.Show ?? false;
	}

	public bool isShowGetFlagWin()
	{
		return GetEventData(-2542)?.Show ?? false;
	}

	public float getFlagWinCount()
	{
		RpgTipsEventData eventData = GetEventData(-2542);
		if (eventData == null)
		{
			return 0f;
		}
		return eventData.Time1;
	}
}
