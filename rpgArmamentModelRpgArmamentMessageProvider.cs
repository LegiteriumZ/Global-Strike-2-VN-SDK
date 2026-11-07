using System;
using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Utils.Ui;
using I2.Loc;
using NetData;

public class rpgArmamentModelRpgArmamentMessageProvider : IrpgArmamentModelRpgArmamentMessageProvider, IModuleProvider
{
	private int[] tipsIds = new int[5] { -13351, -13352, -13353, -13355, -13350 };

	private int[] topTipsIds = new int[2] { -13355, -13353 };

	private int topShowTipId = -1;

	private int centerShowTipId = -1;

	protected GameRuleContext _gameRuleContext;

	public rpgArmamentModelRpgArmamentMessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		subTimeForTips(time.FrameInterval);
	}

	public string pickInfoText()
	{
		RpgTipsEventData tipsData = getTipsData(-13350);
		if (tipsData != null)
		{
			string weaponCnName = LanguageUtils.GetWeaponCnName(tipsData.Str1);
			return ScriptLocalization.Get("RPGARMAMENT_PICKWEAPON").Replace("s", weaponCnName);
		}
		return "";
	}

	public bool pickInfoShow()
	{
		return false;
	}

	public bool isShowMessage(int index)
	{
		int tipId = getTipId(index);
		RpgTipsEventData tipsData = getTipsData(tipId);
		if (tipsData != null)
		{
			bool flag = canShow(tipsData);
			if (flag)
			{
				if (tipId == -13350)
				{
					flag = false;
				}
				recordLastShowId(tipId);
			}
			return flag;
		}
		return false;
	}

	private bool canShow(RpgTipsEventData rpgTipsEventData)
	{
		if (rpgTipsEventData.Time4Specified)
		{
			return rpgTipsEventData.Time4 > 0;
		}
		return rpgTipsEventData.Show;
	}

	private int getTipId(int index)
	{
		if (index < tipsIds.Length)
		{
			return tipsIds[index];
		}
		return -13351;
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

	private void recordLastShowId(int tipId)
	{
		bool flag = false;
		if (Array.IndexOf(topTipsIds, tipId) != -1)
		{
			flag = true;
		}
		if (flag)
		{
			if (topShowTipId != tipId)
			{
				hideTip(topShowTipId);
				topShowTipId = tipId;
			}
		}
		else if (centerShowTipId != tipId)
		{
			hideTip(centerShowTipId);
			centerShowTipId = tipId;
		}
	}

	private void hideTip(int tipId)
	{
		RpgTipsEventData tipsData = getTipsData(tipId);
		if (tipsData != null)
		{
			tipsData.Show = false;
			if (tipsData.Time4Specified)
			{
				tipsData.Time4 = 0;
			}
		}
	}

	private void subTimeForTips(int frameTime)
	{
		int num = tipsIds.Length;
		for (int i = 0; i < num; i++)
		{
			RpgTipsEventData tipsData = getTipsData(tipsIds[i]);
			if (tipsData != null && tipsData.Time4Specified && tipsData.Time4 > 0)
			{
				tipsData.Time4 -= frameTime;
			}
		}
	}
}
