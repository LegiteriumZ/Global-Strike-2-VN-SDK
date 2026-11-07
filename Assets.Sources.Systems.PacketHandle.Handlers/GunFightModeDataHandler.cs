using System.Collections.Generic;
using Assets.Sources.Utils.Timer;
using NetData;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GunFightModeDataHandler : ApcPacketHandler<GunFightMessageData>
{
	private GameRuleContext _gameRuleContext;

	private TimeContext _timeContext;

	public GunFightModeDataHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
	}

	public override int MethodId()
	{
		return 339;
	}

	public override void Handle(GunFightMessageData data)
	{
		if (!_gameRuleContext.hasGunFightData)
		{
			return;
		}
		switch (data.Type)
		{
		case GunFightMessageType.WeaponList:
			_gameRuleContext.gunFightData.WeaponList = data.StringData;
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "GUNFIGHTSHOWBAG", new SSJJTimer(2000));
			break;
		case GunFightMessageType.MaybeWinner:
			_gameRuleContext.gunFightData.PredictedWinner = ((data.IntData.Count >= 1) ? data.IntData[0] : 0);
			break;
		case GunFightMessageType.Score:
			_gameRuleContext.gunFightData.TeamScores = ((data.IntData.Count >= 2) ? data.IntData : new List<int>());
			break;
		case GunFightMessageType.Freeze:
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "GUNFIGHTSTART", new SSJJTimer(data.IntData[0]));
			if (data.BoolData.Count <= 0 || data.BoolData[0])
			{
				SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "GUNFIGHTSHOWBAG", new SSJJTimer(50000));
			}
			break;
		case GunFightMessageType.FinalTime:
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "GUNFIGHTEND", new SSJJTimer(15000));
			break;
		case GunFightMessageType.RoundEnd:
			_gameRuleContext.gunFightData.RoundWinner = ((data.IntData.Count >= 1) ? data.IntData[0] : 0);
			_gameRuleContext.gunFightData.TeamScores = GetScores(data.IntData);
			_gameRuleContext.gunFightData.TeamRank = GetRank(GunFightMessageType.RoundEnd);
			_gameRuleContext.gunFightData.ReviewType = GunFightMessageType.RoundEnd;
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "GUNFIGHTSHOWREVIEW", new SSJJTimer(2500));
			SSJJTimerUtils.RemoveTimer(_timeContext.commonTimer.CommonTimer, "GUNFIGHTEND");
			break;
		case GunFightMessageType.GameEnd:
			_gameRuleContext.gunFightData.GameWinner = ((data.IntData.Count >= 1) ? data.IntData[0] : 0);
			_gameRuleContext.gunFightData.TeamScores = GetScores(data.IntData);
			_gameRuleContext.gunFightData.TeamRank = GetRank(GunFightMessageType.GameEnd);
			_gameRuleContext.gunFightData.ReviewType = GunFightMessageType.GameEnd;
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "GUNFIGHTSHOWREVIEW", new SSJJTimer(2500));
			SSJJTimerUtils.RemoveTimer(_timeContext.commonTimer.CommonTimer, "GUNFIGHTEND");
			break;
		case GunFightMessageType.HotScore:
			_gameRuleContext.gunFightData.RoundWinner = ((data.IntData.Count >= 1) ? data.IntData[0] : 0);
			_gameRuleContext.gunFightData.TeamScores = GetScores(data.IntData);
			_gameRuleContext.gunFightData.TeamRank = GetRank(GunFightMessageType.HotScore);
			_gameRuleContext.gunFightData.ReviewType = GunFightMessageType.HotScore;
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "GUNFIGHTSHOWREVIEW", new SSJJTimer(2500));
			SSJJTimerUtils.RemoveTimer(_timeContext.commonTimer.CommonTimer, "GUNFIGHTEND");
			break;
		case GunFightMessageType.LiveChange:
			_gameRuleContext.gunFightData.AlivePlayer = ((data.IntData.Count >= 2) ? data.IntData : new List<int>());
			break;
		case GunFightMessageType.LiveChangeOnPlaying:
			_gameRuleContext.gunFightData.NotAlivePlayer = ((data.IntData.Count >= 2) ? data.IntData : new List<int>());
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "GUNFIGHTPLAYERNUMNOT", new SSJJTimer(2500));
			break;
		case GunFightMessageType.WeaponPool:
			_gameRuleContext.gunFightData.WeaponPoolName = data.StringData[0];
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "GUNFIGHTTEXTMESSAGE", new SSJJTimer(5000));
			break;
		}
	}

	private List<int> GetRank(GunFightMessageType type)
	{
		int count = _gameRuleContext.gunFightData.TeamScores.Count;
		List<int> list = new List<int>(count);
		List<int> list2 = new List<int>(_gameRuleContext.gunFightData.TeamScores);
		HashSet<int> hashSet = new HashSet<int>();
		int num = ((type == GunFightMessageType.GameEnd) ? (_gameRuleContext.gunFightData.GameWinner - 1) : (_gameRuleContext.gunFightData.RoundWinner - 1));
		if (num != -1)
		{
			hashSet.Add(num);
			list.Add(num);
		}
		while (hashSet.Count < count)
		{
			int num2 = -1;
			int item = 0;
			for (int i = 0; i < list2.Count; i++)
			{
				if (!hashSet.Contains(i) && list2[i] > num2)
				{
					num2 = list2[i];
					item = i;
				}
			}
			if (num2 == -1)
			{
				Debug.LogError("MAXXXXX!!!!");
			}
			hashSet.Add(item);
			list.Add(item);
		}
		return list;
	}

	private List<int> GetScores(List<int> input)
	{
		int count = input.Count;
		List<int> list = new List<int>(count - 1);
		for (int i = 1; i < count; i++)
		{
			list.Add(input[i]);
		}
		return list;
	}
}
