using System.Collections.Generic;
using Assets.Sources.Utils.Timer;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Singleton;
using Sources.Utils.Ui;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class GameTipsShowHandler : ApcPacketHandler<RpgTipsEventData>
{
	private readonly MessageContext _messageContext;

	private readonly GameRuleContext _gameRuleContext;

	private readonly TimeContext _timeContext;

	public GameTipsShowHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
	}

	public override int MethodId()
	{
		return 117;
	}

	public override void Handle(RpgTipsEventData data)
	{
		if (SingletonInstance<UiMessageParser>.Instance.GetMessageConfig(data.TypeId) != null)
		{
			UiTipMessageShow(data);
			return;
		}
		if (data.TypeId == 13214)
		{
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BIGHEAD2_RELIVETIPS"), data.Time1Specified ? data.Time1 : 3000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.TypeId == -1000001)
		{
			string text = ScriptLocalization.Get("DARKFIRE_RIFLE_SKILL_STATE");
			_messageContext.messageRemindData.SetMessage(text, 2000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.TypeId == -2000003)
		{
			string text2 = ScriptLocalization.Get("HuiGuangFanZhao");
			_messageContext.messageRemindData.SetMessage(text2, data.Time1);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.TypeId == -2000004)
		{
			string text3 = ScriptLocalization.Get("AlreadyDongCha");
			_messageContext.messageRemindData.SetMessage(text3, data.Time1);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.TypeId == -1000002)
		{
			string text4 = ScriptLocalization.Get("EV_LIGHT_SNIPER_OVERLOAD");
			_messageContext.messageRemindData.SetMessage(text4, data.Time1);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.TypeId == -1000003)
		{
			string text5 = ScriptLocalization.Get("EV_BLOCK_UMBRELLA_CANT_BE_CHANGE");
			_messageContext.messageRemindData.SetMessage(text5, data.Time1);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.TypeId == -1000004)
		{
			string text6 = ScriptLocalization.Get("EV_BLOCK_UMBRELLA_REBACK");
			_messageContext.messageRemindData.SetMessage(text6, data.Time1);
			NotifyManager.ForceInvoke(38);
		}
		if ((data.TypeId >= 13000 && data.TypeId < 15000000) || data.TypeId == -3085 || data.TypeId == -2000002)
		{
			_messageContext.commonMessageShow.TipsEvent.Add(data);
		}
		else if (data.TypeId == 15000001)
		{
			_messageContext.gameTipsShow.RpgGroupWaitPlayer = data;
		}
		else if (data.TypeId == 10000)
		{
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "BIGHEADKNIFE2BUFF", new SSJJTimer(data.Time1));
		}
		else if (data.TypeId == -3013)
		{
			NotifyManager.ForceInvoke(78);
		}
		else if (data.TypeId == -3014)
		{
			NotifyManager.ForceInvoke(77);
		}
		else if (data.TypeId == -2537 || data.TypeId == -2535 || data.TypeId == -2536)
		{
			_gameRuleContext.teamRaceUi.TeamRaceMessage = data.TypeId;
			NotifyManager.ForceInvoke(84);
		}
		else if (data.TypeId >= -2625 && data.TypeId <= -2622)
		{
			if (_gameRuleContext.explodewdData.TipsData == null)
			{
				_gameRuleContext.explodewdData.TipsData = new Dictionary<int, RpgTipsEventData>();
			}
			if (!_gameRuleContext.explodewdData.TipsData.ContainsKey(data.TypeId))
			{
				_gameRuleContext.explodewdData.TipsData.Add(data.TypeId, data);
			}
			else
			{
				_gameRuleContext.explodewdData.TipsData[data.TypeId] = data;
			}
		}
		else if (data.TypeId == -2626)
		{
			_gameRuleContext.explodewdData.SurplusData = data;
		}
		else if (data.TypeId == -2542 || data.TypeId == -2543 || data.TypeId == -2541 || data.TypeId == -2544 || data.TypeId == -2545 || data.TypeId == -2546 || data.TypeId == -2547 || data.TypeId == -2548 || data.TypeId == -2549 || data.TypeId == -13351 || data.TypeId == -13352 || data.TypeId == -13353 || data.TypeId == -13355 || data.TypeId == -13350 || data.TypeId == -13354)
		{
			Dictionary<int, RpgTipsEventData> dictionary = _gameRuleContext.rpgCommon.EventDataDic ?? new Dictionary<int, RpgTipsEventData>();
			RpgTipsEventData value = null;
			if (!dictionary.TryGetValue(data.TypeId, out value))
			{
				dictionary.Add(data.TypeId, data);
			}
			else
			{
				dictionary[data.TypeId] = data;
			}
			_gameRuleContext.rpgCommon.EventDataDic = dictionary;
		}
		else if (data.TypeId == -3060)
		{
			_gameRuleContext.danrenMine.DamageCount = data.Time1;
		}
		else if (data.TypeId == -13217 || data.TypeId == -13218 || data.TypeId == -13219 || data.TypeId == -13220)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(112);
		}
		else if (data.TypeId == -13214 || data.TypeId == -13215)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(113);
		}
		else if (data.TypeId == -13216 || data.TypeId == -13221 || data.TypeId == -13225 || data.TypeId == -13222)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(114);
		}
		else if (data.TypeId == -13223 || data.TypeId == -13224)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(115);
		}
		else if (data.TypeId == -13500)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(120);
		}
		else if (data.TypeId == -13505 || data.TypeId == -13503 || data.TypeId == -13504)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(121);
		}
		else if (data.TypeId == -13502)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(123);
		}
		else if (data.TypeId == -15000)
		{
			_messageContext.peekabooMessageData.peekabooSkillUseStars = data.Time1;
		}
		else if (data.TypeId == -13510 || data.TypeId == -13511 || data.TypeId == -13512 || data.TypeId == -13513 || data.TypeId == -13514 || data.TypeId == -13515 || data.TypeId == -13516 || data.TypeId == -13517)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(123);
		}
		else if (data.TypeId == -13357 || data.TypeId == -13358)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(151);
		}
		else if (data.TypeId == -2000001)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(153);
		}
		else if (data.TypeId == -14001 || data.TypeId == -14002)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(150);
		}
		else if (data.TypeId == -13520 || data.TypeId == -13521 || data.TypeId == -13522 || data.TypeId == -13523 || data.TypeId == -13524 || data.TypeId == -13525 || data.TypeId == -13526 || data.TypeId == -13527 || data.TypeId == -13528 || data.TypeId == -13531 || data.TypeId == -13532 || data.TypeId == -13533 || data.TypeId == -13534 || data.TypeId == -13529 || data.TypeId == -13530)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(125);
		}
		else if (data.TypeId == -141002)
		{
			_gameRuleContext.rpgTreasureBossData.isDay = data.Time1 == 0;
			_gameRuleContext.rpgTreasureBossData.totalTime = data.Time3;
			_gameRuleContext.rpgTreasureBossData.ramainTime = data.Time2;
		}
		else if (data.TypeId == -141000)
		{
			_gameRuleContext.rpgTreasureBossData.keyCount = data.Time1;
		}
		else if (data.TypeId == -141009)
		{
			_gameRuleContext.rpgTreasureBossData.bottomTipsId = data.TypeId;
			_gameRuleContext.rpgTreasureBossData.bottomTipsTime = (data.Show ? data.Time4 : 0);
		}
		else if (data.TypeId == -141003 || data.TypeId == -141004 || data.TypeId == -141005 || data.TypeId == -141006 || data.TypeId == -141007 || data.TypeId == -141008)
		{
			if (_gameRuleContext.rpgTreasureBossData.topTipsId == data.TypeId || (data.Show && data.Time4 > 0))
			{
				_gameRuleContext.rpgTreasureBossData.topTipsId = data.TypeId;
				_gameRuleContext.rpgTreasureBossData.topTipsTime = (data.Show ? data.Time4 : 0);
			}
			if (data.TypeId == -141005)
			{
				_gameRuleContext.rpgTreasureBossData.cbtPlayerName = data.Str1;
				_gameRuleContext.rpgTreasureBossData.cbtLvl = data.Str2;
			}
		}
		else if (data.TypeId == -141010 || data.TypeId == -141011 || data.TypeId == -141012 || data.TypeId == -141013 || data.TypeId == -141014 || data.TypeId == -141015 || data.TypeId == -141016 || data.TypeId == -141017 || data.TypeId == -141018 || data.TypeId == -141019 || data.TypeId == -141020 || data.TypeId == -141021 || data.TypeId == -141022 || data.TypeId == -141025)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(156);
		}
		else if (data.TypeId == -141023)
		{
			_messageContext.bioMessageData.WaitingPlayerNum = data.Time1;
		}
		else if (data.TypeId == -141024)
		{
			_gameRuleContext.bioUnionBaseData.balancePlayerShow = true;
			_gameRuleContext.bioUnionBaseData.balancePlayerCount = data.Time1;
			_gameRuleContext.bioUnionBaseData.balancePlayerTimeCountDown = data.Time4;
		}
		else if (data.TypeId == -141035)
		{
			_gameRuleContext.bioMaolingUI.show = data.Show;
			_gameRuleContext.bioMaolingUI.time1 = data.Time1;
			_gameRuleContext.bioMaolingUI.time2 = data.Time2;
		}
		else if (data.TypeId == -141042)
		{
			_gameRuleContext.rpgTanlan.deathUIShow = data.Show;
			_gameRuleContext.rpgTanlan.deathUITime1 = data.Time1;
			_gameRuleContext.rpgTanlan.deathUITime2 = data.Time2;
		}
		else if (data.TypeId == -141043 || data.TypeId == -141044 || data.TypeId == -141045 || data.TypeId == -141046)
		{
			_gameRuleContext.rpgTanlan.targetShow = data.Show;
			_gameRuleContext.rpgTanlan.targetCurNum = data.Time1;
			_gameRuleContext.rpgTanlan.targetTotalNum = data.Time2;
			_gameRuleContext.rpgTanlan.targetTipId = data.TypeId;
		}
		else if (data.TypeId == -141047)
		{
			_gameRuleContext.rpgTanlanJinWu.JinwuTime = data;
			_gameRuleContext.rpgTanlanJinWu.JinwuTimeChange = true;
		}
		else if (data.TypeId == -141048)
		{
			_gameRuleContext.rpgTanlanJinWu.XuliTip = data;
			_gameRuleContext.rpgTanlanJinWu.XuliTipChange = true;
		}
		else if (data.TypeId == -141049)
		{
			_gameRuleContext.rpgTanlanJinWu.BuffTips = data;
			_gameRuleContext.rpgTanlanJinWu.BuffTipsChange = true;
		}
		else if (data.TypeId == -141050)
		{
			_gameRuleContext.rpgTanlanJinWu.JinwuKeyTipShow = data.Show;
		}
		else if (data.TypeId == -141100 || data.TypeId == -141106 || data.TypeId == -141105 || data.TypeId == -141104 || data.TypeId == -141110 || data.TypeId == -141108 || data.TypeId == -141109 || data.TypeId == -141102 || data.TypeId == -141103 || data.TypeId == -141107 || data.TypeId == -141101 || data.TypeId == -141111 || data.TypeId == -141112)
		{
			if (_gameRuleContext.rpgStarWalker.topTipsId == data.TypeId || (data.Show && data.Time4 > 0))
			{
				_gameRuleContext.rpgStarWalker.topTipsId = data.TypeId;
				_gameRuleContext.rpgStarWalker.topTipsTime = (data.Show ? data.Time4 : 0);
			}
			if (data.TypeId == -141100)
			{
				_gameRuleContext.rpgStarWalker.numInfectCurrent = data.Time1;
				_gameRuleContext.rpgStarWalker.numInfectTotal = data.Time2;
				_gameRuleContext.rpgStarWalker.numInfectBoss = data.Time3;
				_gameRuleContext.rpgStarWalker.numInfectExit = data.Time4;
			}
			else if (data.TypeId == -141111)
			{
				_gameRuleContext.rpgStarWalker.pubBoxRemainCnt = data.Time1;
				_gameRuleContext.rpgStarWalker.pubBoxProb = data.Time2;
			}
			else if (data.TypeId == -141108)
			{
				_gameRuleContext.rpgStarWalker.boxOwnerNameCurrent = data.Str1;
			}
			else if (data.TypeId == -141112)
			{
				_gameRuleContext.rpgStarWalker.numTargetCurrent = data.Time1;
				_gameRuleContext.rpgStarWalker.numTargetTotal = data.Time2;
			}
		}
		else
		{
			_messageContext.gameTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(14);
		}
	}

	public void UiTipMessageShow(RpgTipsEventData data)
	{
		UiMessageConfig messageConfig = SingletonInstance<UiMessageParser>.Instance.GetMessageConfig(data.TypeId);
		string text = messageConfig.describe;
		int num = messageConfig.showTime;
		switch (num)
		{
		case -1:
			num = data.Time1;
			break;
		case -2:
			num = data.Time2;
			break;
		case -3:
			num = data.Time3;
			break;
		case -4:
			num = data.Time4;
			break;
		}
		if (messageConfig.arguments != null)
		{
			string[] array = new string[messageConfig.arguments.Length];
			for (int i = 0; i < messageConfig.arguments.Length; i++)
			{
				float result = 1f;
				if (messageConfig.timeScale != null && messageConfig.timeScale.Length >= i)
				{
					float.TryParse(messageConfig.timeScale[i], out result);
				}
				switch (messageConfig.arguments[i])
				{
				case "Time1":
					array[i] = Mathf.Ceil((float)data.Time1 * result).ToString();
					break;
				case "Time2":
					array[i] = Mathf.Ceil((float)data.Time2 * result).ToString();
					break;
				case "Time3":
					array[i] = Mathf.Ceil((float)data.Time3 * result).ToString();
					break;
				case "Time4":
					array[i] = Mathf.Ceil((float)data.Time4 * result).ToString();
					break;
				case "Str1":
					array[i] = data.Str1;
					break;
				case "Str2":
					array[i] = data.Str2;
					break;
				}
			}
			string format = text;
			object[] args = array;
			text = string.Format(format, args);
		}
		_messageContext.messageRemindData.SetMessage(text, num);
		NotifyManager.ForceInvoke(38);
	}
}
