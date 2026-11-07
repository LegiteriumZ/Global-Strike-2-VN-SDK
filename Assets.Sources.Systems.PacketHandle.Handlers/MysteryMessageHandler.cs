using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class MysteryMessageHandler : ApcPacketHandler<MysteryMessageData>
{
	private readonly GameRuleContext _gameRuleContext;

	public MysteryMessageHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 334;
	}

	public override void Handle(MysteryMessageData data)
	{
		if (data == null)
		{
			return;
		}
		if (data.Type == MysteryMessageType.PLAYERNUM)
		{
			_gameRuleContext.mystery.PlayerNumber = data.IntData[0];
		}
		else if (data.Type == MysteryMessageType.TIMESTART)
		{
			_gameRuleContext.mystery.LeftTime = data.IntData[0];
		}
		else if (data.Type == MysteryMessageType.CANSELECTMODE)
		{
			_gameRuleContext.mystery.IsShowCanSelectModeTips = data.BoolData[0];
		}
		else if (data.Type == MysteryMessageType.SELECTMODE)
		{
			_gameRuleContext.mystery.IsShowSelectMode = data.BoolData[0];
			if (data.BoolData[0])
			{
				_gameRuleContext.mystery.IsShowCanSelectModeTips = false;
			}
		}
		else if (data.Type == MysteryMessageType.TASKINFO)
		{
			_gameRuleContext.mystery.IsShowTaskInfo = false;
			if (data.IntData != null)
			{
				if (data.IntData.Count == 2)
				{
					_gameRuleContext.mystery.IsShowTaskInfo = true;
					_gameRuleContext.mystery.TaskTypeOne = data.IntData[0];
					_gameRuleContext.mystery.TaskOne = data.IntData[1];
					_gameRuleContext.mystery.TaskTypeTwo = 0;
				}
				else if (data.IntData.Count == 4)
				{
					_gameRuleContext.mystery.IsShowTaskInfo = true;
					_gameRuleContext.mystery.TaskTypeOne = data.IntData[0];
					_gameRuleContext.mystery.TaskOne = data.IntData[1];
					_gameRuleContext.mystery.TaskTypeTwo = data.IntData[2];
					_gameRuleContext.mystery.TaskTwo = data.IntData[3];
				}
			}
		}
		else if (data.Type == MysteryMessageType.ACTORNAME)
		{
			_gameRuleContext.mystery.StartFireName = data.StringData[0];
		}
		else if (data.Type == MysteryMessageType.NOTLEAVEROOM)
		{
			_gameRuleContext.mystery.IsNotLeaveRoom = true;
			_gameRuleContext.mystery.NotLeaveRoomTime = data.IntData[0];
		}
		else if (data.Type == MysteryMessageType.CANLIGHTFIRE)
		{
			_gameRuleContext.mystery.IsCanLightFireTips = data.BoolData[0];
			if (data.BoolData[0])
			{
				_gameRuleContext.mystery.Exp1 = data.IntData[0];
				_gameRuleContext.mystery.Exp2 = data.IntData[2];
				_gameRuleContext.mystery.Exp3 = data.IntData[4];
			}
		}
		else if (data.Type == MysteryMessageType.EXPPROGRESS)
		{
			_gameRuleContext.mystery.IsExpProgress = data.BoolData[0];
			if (data.BoolData[0])
			{
				_gameRuleContext.mystery.IsFire = data.BoolData[1];
				_gameRuleContext.mystery.FireType = data.IntData[0];
				_gameRuleContext.mystery.FirePercent = data.IntData[1];
				_gameRuleContext.mystery.IsCanLightFireTips = false;
			}
			else
			{
				_gameRuleContext.mystery.FireExpStartTime = 0;
			}
		}
		else if (data.Type == MysteryMessageType.LIGHTFIRESTATUS)
		{
			_gameRuleContext.mystery.IsLightFireStatusTips = data.BoolData[0];
			if (data.BoolData[0])
			{
				_gameRuleContext.mystery.LightFireStatusTime = data.IntData[0];
			}
		}
		else if (data.Type == MysteryMessageType.FIRESTART)
		{
			_gameRuleContext.mystery.FireStartTime = 3000;
			_gameRuleContext.mystery.IsFireStart = true;
			_gameRuleContext.mystery.FireStartPlayerName = data.StringData[0];
		}
		else if (data.Type == MysteryMessageType.SPECIALEXPSET)
		{
			_gameRuleContext.mystery.IsSpecailExpSet = true;
			_gameRuleContext.mystery.SpecialExpTime = data.IntData[0];
		}
		else if (data.Type == MysteryMessageType.CANSELECTSPECIALPLAYER)
		{
			_gameRuleContext.mystery.IsCanSelectPlayer = data.BoolData[0];
		}
		else if (data.Type == MysteryMessageType.SELECTSPECIALPLAYER)
		{
			_gameRuleContext.mystery.SelectPlayerShow = data.BoolData[0];
			if (data.BoolData[0])
			{
				_gameRuleContext.mystery.IsCanSelectPlayer = false;
				_gameRuleContext.mystery.SelectPlayers = data.LongData;
			}
		}
		else if (data.Type == MysteryMessageType.DAMAGEPERSONAL)
		{
			_gameRuleContext.mystery.IsShowRank = true;
			_gameRuleContext.mystery.RankSelfAllDamage = data.LongData[1];
			_gameRuleContext.mystery.RankSelfSecDamage = data.LongData[2];
		}
		else if (data.Type == MysteryMessageType.DAMAGERANK)
		{
			_gameRuleContext.mystery.IsShowRank = true;
			_gameRuleContext.mystery.RankLeftTime = data.IntData[0];
			if (_gameRuleContext.mystery.OtherRankCids == null)
			{
				_gameRuleContext.mystery.OtherRankCids = new List<long>();
			}
			if (_gameRuleContext.mystery.OtherRankDamages == null)
			{
				_gameRuleContext.mystery.OtherRankDamages = new List<long>();
			}
			_gameRuleContext.mystery.OtherRankDamages.Clear();
			_gameRuleContext.mystery.OtherRankCids.Clear();
			int num;
			for (num = 0; num < data.LongData.Count; num++)
			{
				_gameRuleContext.mystery.OtherRankCids.Add(data.LongData[num]);
				num++;
				_gameRuleContext.mystery.OtherRankDamages.Add(data.LongData[num]);
			}
		}
	}
}
