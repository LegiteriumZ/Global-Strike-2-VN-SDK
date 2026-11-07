using System.Collections.Generic;
using Assets.Sources.Components.Time;
using NetData;

public class rpgArmamentModelRpgArmamentMyPointProvider : IrpgArmamentModelRpgArmamentMyPointProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgArmamentModelRpgArmamentMyPointProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool isShowMessae()
	{
		return getTipsData(-13354)?.Show ?? false;
	}

	public float updateMaxPoint()
	{
		RpgTipsEventData tipsData = getTipsData(-13354);
		if (tipsData != null)
		{
			return tipsData.Time2;
		}
		return 0f;
	}

	public float updateMyPoint()
	{
		RpgTipsEventData tipsData = getTipsData(-13354);
		if (tipsData != null)
		{
			return tipsData.Time1;
		}
		return 0f;
	}

	private RpgTipsEventData getTipsData(int tipID)
	{
		Dictionary<int, RpgTipsEventData> eventDataDic = _gameRuleContext.rpgCommon.EventDataDic;
		RpgTipsEventData value = null;
		if (eventDataDic != null)
		{
			eventDataDic.TryGetValue(tipID, out value);
			if (value != null)
			{
				return value;
			}
		}
		return null;
	}
}
