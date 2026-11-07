using System.Collections.Generic;
using Assets.Scripts.Utility.Sound;
using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils;
using NetData;
using NotifyEvent;
using SSJJBase.Singleton;
using share.constant;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class KillPlayerInfoDataHandler : ApcPacketHandler<KillPlayerInfoData>
{
	private SnapshotContext _snapshotContext;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	private MessageContext _msgContext;

	private int _lastKillNum;

	private long _lastTime;

	public KillPlayerInfoDataHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
		_playerContext = context.player;
		_snapshotContext = context.snapshot;
		_battleRoomContext = context.battleRoom;
		_msgContext = context.message;
	}

	public override int MethodId()
	{
		return 6;
	}

	public void pushKillInfoData(ReportVisibleComponent.KillInfoData data)
	{
		List<ReportVisibleComponent.KillInfoData> killLists = _gameRuleContext.reportVisible.killLists;
		if (killLists.Count >= 10)
		{
			killLists.RemoveAt(0);
		}
		killLists.Add(data);
	}

	public override void Handle(KillPlayerInfoData data)
	{
		_gameRuleContext.killPlayerInfo.InfoList.Clear();
		_gameRuleContext.killPlayerInfo.InfoList.Enqueue(data);
		dispatchPeekabooKillEvent(data);
		if (RuleUtilty.hasReportHandle())
		{
			ReportVisibleComponent.KillInfoData killInfoData = new ReportVisibleComponent.KillInfoData();
			killInfoData.BeKillPlayerId = data.BeKillPlayerId;
			killInfoData.KillPlayerId = data.KillPlayerId;
			killInfoData.KillPlayerName = data.KillPlayerName;
			pushKillInfoData(killInfoData);
		}
		if (_gameRuleContext.currentRule.Rule.IsShowKiller() && _playerContext.isMyPlayer && _playerContext.myPlayerEntity.GetId() == data.BeKillPlayerId)
		{
			_playerContext.myPlayerEntity.ReplaceKiller(data.KillPlayerName, 5000);
		}
		if (data.CurInfectionNum > 0)
		{
			_battleRoomContext.playerInfo.CurrKillNums[data.KillPlayerId] = data.CurInfectionNum;
		}
		else
		{
			_battleRoomContext.playerInfo.CurrKillNums[data.KillPlayerId] = data.CurKillNum;
		}
		_battleRoomContext.playerInfo.CurrKillNums[data.BeKillPlayerId] = 0;
		if (data.KillPlayerId == UiIEventCondition.Get_cameraOwnerData_PlayerId())
		{
			for (int i = 0; i < data.GunGloryList.Count; i++)
			{
				int j;
				for (j = 0; j < _gameRuleContext.gunGlory.GunGloryList.Count && data.GunGloryList[i] != _gameRuleContext.gunGlory.GunGloryList[j]; j++)
				{
					if (data.GunGloryList[i] < _gameRuleContext.gunGlory.GunGloryList[j])
					{
						_gameRuleContext.gunGlory.GunGloryList.Insert(j, data.GunGloryList[i]);
						break;
					}
				}
				if (j == _gameRuleContext.gunGlory.GunGloryList.Count)
				{
					_gameRuleContext.gunGlory.GunGloryList.Add(data.GunGloryList[i]);
				}
			}
			_gameRuleContext.gunGlory.GunGloryDelayShow = 1500;
		}
		NotifyManager.ForceInvoke(22);
		_gameRuleContext.killPlayerInfo.Changed = true;
		if (!_snapshotContext.hasSnapshots)
		{
			return;
		}
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (latestSnapshot == null)
		{
			return;
		}
		bool flag = false;
		bool dispatchSelfKillData = false;
		bool dispatchSelfBekillData = false;
		if (latestSnapshot.Observer > 0)
		{
			if (latestSnapshot.Observer == data.KillPlayerId && data.KillTeam != data.BekillTeam)
			{
				flag = true;
				dispatchSelfKillData = true;
			}
			else if (latestSnapshot.Observer == data.KillPlayerId)
			{
				dispatchSelfBekillData = true;
			}
		}
		else if (latestSnapshot.Self == data.KillPlayerId && data.KillTeam != data.BekillTeam)
		{
			flag = true;
			dispatchSelfKillData = true;
		}
		else if (latestSnapshot.Self == data.BeKillPlayerId)
		{
			dispatchSelfBekillData = true;
		}
		else if (latestSnapshot.Self == data.KillPlayerId && RuleUtilty.IsBioMode(_battleRoomContext.roomData.Data.RaceType))
		{
			flag = true;
		}
		if (flag)
		{
			int num = data.CurKillNum;
			if (RuleUtilty.IsPve(_battleRoomContext.roomData.Data.RaceType))
			{
				num = data.PveCurKillNum;
			}
			if (RuleUtilty.IsBioMode(_battleRoomContext.roomData.Data.RaceType) && num == 1)
			{
				data.FirstBlood = true;
			}
			PlayKillSound(data.FirstBlood, num, data.Headshot, data.IsWoman);
		}
		PlayAutoSoundEvent(data, dispatchSelfKillData, dispatchSelfBekillData, latestSnapshot);
	}

	private void dispatchPeekabooKillEvent(KillPlayerInfoData data)
	{
		if (_battleRoomContext.roomData.Data.RaceType != 25)
		{
			return;
		}
		int self = _snapshotContext.snapshots.NowSnapshot.Self;
		if (data.KillPlayerId > 0 && data.BeKillPlayerId == self && data.KillPlayerId != self)
		{
			PeekAbooMessageData peekAbooMessageData = _msgContext.peekabooMessageData.data;
			if (peekAbooMessageData == null)
			{
				peekAbooMessageData = new PeekAbooMessageData();
				_msgContext.peekabooMessageData.data = peekAbooMessageData;
			}
			_msgContext.peekabooMessageData.changed = true;
			peekAbooMessageData.Type = PeekAbooMessageType.ITEMBEKILL;
			peekAbooMessageData.Time = 3000;
		}
	}

	private void PlayAutoSoundEvent(KillPlayerInfoData data, bool dispatchSelfKillData, bool dispatchSelfBekillData, ISnapshot latestSnapshot)
	{
		PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(data.KillPlayerId);
		PlayerEntity entityWithEntityId2 = Contexts.sharedInstance.player.GetEntityWithEntityId(data.BeKillPlayerId);
		if (entityWithEntityId == null || entityWithEntityId2 == null)
		{
			return;
		}
		if (dispatchSelfBekillData)
		{
			if (PlayerCareerConstantUtility.IsHero(entityWithEntityId2.GetCareer()) || PlayerCareerConstantUtility.IsEmpress(entityWithEntityId2.GetCareer()))
			{
				MonoBehaviourSingleton<AutoSoundManager>.Instance.OnAutoSound(AutoSoundEventType.KillHero, 0, null, entityWithEntityId.GetCareer());
			}
			else if (!string.IsNullOrEmpty(entityWithEntityId2.GetCareer()) && PlayerCareerUtil.IsHumanity(entityWithEntityId2.GetCareer()))
			{
				MonoBehaviourSingleton<AutoSoundManager>.Instance.OnAutoSound(AutoSoundEventType.BeKilled, entityWithEntityId.entityId.Value);
			}
		}
		if (dispatchSelfKillData || data.KillPlayerId == latestSnapshot.Self)
		{
			if (PlayerCareerConstantUtility.IsHero(entityWithEntityId2.GetCareer()) || PlayerCareerConstantUtility.IsEmpress(entityWithEntityId2.GetCareer()))
			{
				MonoBehaviourSingleton<AutoSoundManager>.Instance.OnAutoSound(AutoSoundEventType.KillHero, 0, null, entityWithEntityId.GetCareer());
			}
			if (PlayerCareerConstantUtility.IsDoun(entityWithEntityId.GetCareer()) || PlayerCareerConstantUtility.IsEmpress(entityWithEntityId.GetCareer()))
			{
				MonoBehaviourSingleton<AutoSoundManager>.Instance.OnAutoSound(AutoSoundEventType.Infection, 0, null, entityWithEntityId.GetCareer());
			}
		}
	}

	private void PlayKillSound(bool firstBlood, int killNum, bool headShot, bool isWoman)
	{
		int num = 11;
		int num2 = 1;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 2; i < 12; i++)
		{
			dictionary[i] = i;
		}
		if (killNum > num)
		{
			killNum = ((killNum % num2 == 0) ? num : killNum);
		}
		if (_lastKillNum == killNum && TimeUtility.UnixTimeNow() - _lastTime < 1000)
		{
			return;
		}
		if (firstBlood)
		{
			if (!RuleUtilty.IsGeneralPve(_battleRoomContext.roomData.Data.RaceType))
			{
				MonoBehaviourSingleton<AutoSoundManager>.Instance.OnAutoSound(AutoSoundEventType.FirstBlood);
			}
		}
		else if (killNum > 1)
		{
			if (dictionary.ContainsKey(killNum) && !RuleUtilty.IsGeneralPve(_battleRoomContext.roomData.Data.RaceType))
			{
				MonoBehaviourSingleton<AutoSoundManager>.Instance.OnAutoSound(AutoSoundEventType.Kills, 0, dictionary[killNum]);
			}
		}
		else if (headShot)
		{
			MonoBehaviourSingleton<AutoSoundManager>.Instance.OnAutoSound(AutoSoundEventType.HeadShot);
		}
		else
		{
			MonoBehaviourSingleton<AutoSoundManager>.Instance.OnAutoSound(AutoSoundEventType.Kills, 0, killNum);
		}
		_lastKillNum = killNum;
		_lastTime = TimeUtility.UnixTimeNow();
	}
}
