using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Utils.Sound;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class AllKillInfoDataHandler : ApcPacketHandler<AllKillInfoData>
{
	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	public AllKillInfoDataHandler(Contexts context)
	{
		_playerContext = context.player;
		_battleRoomContext = context.battleRoom;
	}

	public override int MethodId()
	{
		return 8;
	}

	private int SortFunc(OneKillInfoData a, OneKillInfoData b)
	{
		if (a.Score > b.Score)
		{
			return -1;
		}
		if (a.Score < b.Score)
		{
			return 1;
		}
		if (a.KillNum > b.KillNum)
		{
			return -1;
		}
		if (a.KillNum < b.KillNum)
		{
			return 1;
		}
		if (a.AssistsNum > b.AssistsNum)
		{
			return -1;
		}
		if (a.AssistsNum < b.AssistsNum)
		{
			return 1;
		}
		if (a.BeKillNum < b.BeKillNum)
		{
			return -1;
		}
		if (a.BeKillNum > b.BeKillNum)
		{
			return 1;
		}
		return a.Id - b.Id;
	}

	private int SortBigHead2Func(OneKillInfoData a, OneKillInfoData b)
	{
		if (a.Lv > b.Lv)
		{
			return -1;
		}
		if (a.Lv < b.Lv)
		{
			return 1;
		}
		if (a.Score > b.Score)
		{
			return -1;
		}
		if (a.Score < b.Score)
		{
			return 1;
		}
		if (a.KillNum > b.KillNum)
		{
			return -1;
		}
		if (a.KillNum < b.KillNum)
		{
			return 1;
		}
		if (a.AssistsNum > b.AssistsNum)
		{
			return -1;
		}
		if (a.AssistsNum < b.AssistsNum)
		{
			return 1;
		}
		if (a.BeKillNum < b.BeKillNum)
		{
			return -1;
		}
		if (a.BeKillNum > b.BeKillNum)
		{
			return 1;
		}
		return 0;
	}

	private void mergeAllKillInfoData(AllKillInfoData tmp)
	{
		if (_battleRoomContext.playerInfo.All == null || _battleRoomContext.playerInfo.All.Count == 0)
		{
			_battleRoomContext.playerInfo.All = tmp.List;
			return;
		}
		int count = tmp.List.Count;
		int count2 = _battleRoomContext.playerInfo.All.Count;
		for (int i = 0; i < count; i++)
		{
			OneKillInfoData oneKillInfoData = tmp.List[i];
			OneKillInfoData oneKillInfoData2 = null;
			bool flag = false;
			int index = 0;
			for (int j = 0; j < count2; j++)
			{
				oneKillInfoData2 = _battleRoomContext.playerInfo.All[j];
				if (oneKillInfoData2.Id == oneKillInfoData.Id)
				{
					index = j;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				_battleRoomContext.playerInfo.All.Add(oneKillInfoData);
				continue;
			}
			if (!oneKillInfoData.TeamSpecified)
			{
				oneKillInfoData.Team = oneKillInfoData2.Team;
			}
			if (!oneKillInfoData.PlayerNameSpecified)
			{
				oneKillInfoData.PlayerName = oneKillInfoData2.PlayerName;
			}
			if (!oneKillInfoData.KillNumSpecified)
			{
				oneKillInfoData.KillNum = oneKillInfoData2.KillNum;
			}
			if (!oneKillInfoData.BeKillNumSpecified)
			{
				oneKillInfoData.BeKillNum = oneKillInfoData2.BeKillNum;
			}
			if (!oneKillInfoData.CareerSpecified)
			{
				oneKillInfoData.Career = oneKillInfoData2.Career;
			}
			if (!oneKillInfoData.AssistsNumSpecified)
			{
				oneKillInfoData.AssistsNum = oneKillInfoData2.AssistsNum;
			}
			if (!oneKillInfoData.TeamNameSpecified)
			{
				oneKillInfoData.TeamName = oneKillInfoData2.TeamName;
			}
			if (!oneKillInfoData.ReliveNumSpecified)
			{
				oneKillInfoData.ReliveNum = oneKillInfoData2.ReliveNum;
			}
			if (!oneKillInfoData.ScoreSpecified)
			{
				oneKillInfoData.Score = oneKillInfoData2.Score;
			}
			if (!oneKillInfoData.TreatmentScoreSpecified)
			{
				oneKillInfoData.TreatmentScore = oneKillInfoData2.TreatmentScore;
			}
			if (!oneKillInfoData.LvSpecified)
			{
				oneKillInfoData.Lv = oneKillInfoData2.Lv;
			}
			if (!oneKillInfoData.KnifeKillSpecified)
			{
				oneKillInfoData.KnifeKill = oneKillInfoData2.KnifeKill;
			}
			if (!oneKillInfoData.HidePackNumSpecified)
			{
				oneKillInfoData.HidePackNum = oneKillInfoData2.HidePackNum;
			}
			if (!oneKillInfoData.OpenPackNumSpecified)
			{
				oneKillInfoData.OpenPackNum = oneKillInfoData2.OpenPackNum;
			}
			if (!oneKillInfoData.AllMoneySpecified)
			{
				oneKillInfoData.AllMoney = oneKillInfoData2.AllMoney;
			}
			if (!oneKillInfoData.ReadPointSpecified)
			{
				oneKillInfoData.ReadPoint = oneKillInfoData2.ReadPoint;
			}
			if (!oneKillInfoData.SavePointSpecified)
			{
				oneKillInfoData.SavePoint = oneKillInfoData2.SavePoint;
			}
			if (!oneKillInfoData.FastWeaponSpecified)
			{
				oneKillInfoData.FastWeapon = oneKillInfoData2.FastWeapon;
			}
			if (!oneKillInfoData.JumpTimeSpecified)
			{
				oneKillInfoData.JumpTime = oneKillInfoData2.JumpTime;
			}
			if (!oneKillInfoData.AdditionalTimeSpecified)
			{
				oneKillInfoData.AdditionalTime = oneKillInfoData2.AdditionalTime;
			}
			if (!oneKillInfoData.StrikeScoreSpecified)
			{
				oneKillInfoData.StrikeScore = oneKillInfoData2.StrikeScore;
			}
			if (!oneKillInfoData.AccessoryScoreSpecified)
			{
				oneKillInfoData.AccessoryScore = oneKillInfoData2.AccessoryScore;
			}
			if (!oneKillInfoData.GroupSpecified)
			{
				oneKillInfoData.Group = oneKillInfoData2.Group;
			}
			if (!oneKillInfoData.IsDeadSpecified)
			{
				oneKillInfoData.IsDead = oneKillInfoData2.IsDead;
			}
			if (!oneKillInfoData.HasC4Specified)
			{
				oneKillInfoData.HasC4 = oneKillInfoData2.HasC4;
			}
			if (!oneKillInfoData.MvpSpecified)
			{
				oneKillInfoData.Mvp = oneKillInfoData2.Mvp;
			}
			if (!oneKillInfoData.AceSpecified)
			{
				oneKillInfoData.Ace = oneKillInfoData2.Ace;
			}
			if (!oneKillInfoData.Ace2Specified)
			{
				oneKillInfoData.Ace2 = oneKillInfoData2.Ace2;
			}
			if (!oneKillInfoData.Ace3Specified)
			{
				oneKillInfoData.Ace3 = oneKillInfoData2.Ace3;
			}
			if (!oneKillInfoData.JumpDoneSpecified)
			{
				oneKillInfoData.JumpDone = oneKillInfoData2.JumpDone;
			}
			if (!oneKillInfoData.NurseSpecified)
			{
				oneKillInfoData.Nurse = oneKillInfoData2.Nurse;
			}
			if (!oneKillInfoData.LoginUnitySpecified)
			{
				oneKillInfoData.LoginUnity = oneKillInfoData2.LoginUnity;
			}
			if (!oneKillInfoData.TerminatorSpecified)
			{
				oneKillInfoData.Terminator = oneKillInfoData2.Terminator;
			}
			if (!oneKillInfoData.OverloadSpecified)
			{
				oneKillInfoData.Overload = oneKillInfoData2.Overload;
			}
			if (!oneKillInfoData.GoldHunterSpecified)
			{
				oneKillInfoData.GoldHunter = oneKillInfoData2.GoldHunter;
			}
			if (!oneKillInfoData.HasHeroWeaponSpecified)
			{
				oneKillInfoData.HasHeroWeapon = oneKillInfoData2.HasHeroWeapon;
			}
			if (!oneKillInfoData.LeaderSpecified)
			{
				oneKillInfoData.Leader = oneKillInfoData2.Leader;
			}
			if (!oneKillInfoData.MaxHidePackSpecified)
			{
				oneKillInfoData.MaxHidePack = oneKillInfoData2.MaxHidePack;
			}
			if (!oneKillInfoData.MaxOpenPackSpecified)
			{
				oneKillInfoData.MaxOpenPack = oneKillInfoData2.MaxOpenPack;
			}
			if (!oneKillInfoData.KdKingSpecified)
			{
				oneKillInfoData.KdKing = oneKillInfoData2.KdKing;
			}
			if (!oneKillInfoData.PingSpecified)
			{
				oneKillInfoData.Ping = oneKillInfoData2.Ping;
			}
			_battleRoomContext.playerInfo.All[index] = oneKillInfoData;
		}
		List<int> list = new List<int>();
		for (int k = 0; k < count2; k++)
		{
			OneKillInfoData oneKillInfoData3 = _battleRoomContext.playerInfo.All[k];
			bool flag2 = false;
			for (int l = 0; l < count; l++)
			{
				if (tmp.List[l].Id == oneKillInfoData3.Id)
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				list.Add(oneKillInfoData3.Id);
			}
		}
		for (int m = 0; m < list.Count; m++)
		{
			int num = list[m];
			int num2 = -1;
			for (int n = 0; n < _battleRoomContext.playerInfo.All.Count; n++)
			{
				if (_battleRoomContext.playerInfo.All[n].Id == num)
				{
					num2 = n;
					break;
				}
			}
			if (num2 != -1)
			{
				_battleRoomContext.playerInfo.All.RemoveAt(num2);
			}
		}
	}

	public override void Handle(AllKillInfoData data)
	{
		mergeAllKillInfoData(data);
		if (_battleRoomContext.roomData.Data.RaceType != 73 && _battleRoomContext.roomData.Data.RaceType != 15010)
		{
			_battleRoomContext.playerInfo.All.Sort(SortFunc);
		}
		if (_battleRoomContext.roomData.Data.RaceType == 126)
		{
			_battleRoomContext.playerInfo.All.Sort(SortBigHead2Func);
		}
		_battleRoomContext.playerInfo.Team1.Clear();
		_battleRoomContext.playerInfo.Team2.Clear();
		List<OneKillInfoData> all = _battleRoomContext.playerInfo.All;
		NotifyManager.ForceInvoke(19);
		foreach (OneKillInfoData item in all)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item.Id);
			if (entityWithEntityId != null && _battleRoomContext.roomData.Data.RaceType != 73 && _battleRoomContext.roomData.Data.RaceType != 123 && _battleRoomContext.roomData.Data.RaceType != 126)
			{
				item.Lv = entityWithEntityId.GetPlayerInfo().Lv;
			}
			if (item.Team == 2)
			{
				_battleRoomContext.playerInfo.Team1.Add(item);
			}
			else
			{
				_battleRoomContext.playerInfo.Team2.Add(item);
			}
			PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
			if (myPlayerEntity != null && myPlayerEntity.hasBasicInfo && item.Id == myPlayerEntity.basicInfo.Current.Id)
			{
				if (item.Ace && !myPlayerEntity.isLastHaveAce)
				{
					MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/common", "Assets/Res/Assets/sound/common/getace.mp3"), GameSoundManager.Config.AsideVolume);
					myPlayerEntity.isLastHaveAce = true;
				}
				else if (!item.Ace && myPlayerEntity.isLastHaveAce)
				{
					MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/common", "Assets/Res/Assets/sound/common/lostace.mp3"), GameSoundManager.Config.AsideVolume);
					myPlayerEntity.isLastHaveAce = false;
				}
			}
		}
		if (_battleRoomContext.roomData.Data.RaceType != 61 && _battleRoomContext.roomData.Data.RaceType != 27)
		{
			return;
		}
		_battleRoomContext.playerInfo.All.Sort(SortMoney);
		List<OneKillInfoData> all2 = _battleRoomContext.playerInfo.All;
		_battleRoomContext.playerInfo.TeamMoney1.Clear();
		_battleRoomContext.playerInfo.TeamMoney2.Clear();
		for (int i = 0; i < all2.Count; i++)
		{
			if (all[i].Team == 2)
			{
				_battleRoomContext.playerInfo.TeamMoney1.Add(all2[i]);
			}
			else if (all[i].Team == 1)
			{
				_battleRoomContext.playerInfo.TeamMoney2.Add(all2[i]);
			}
		}
		NotifyManager.ForceInvoke(26);
		NotifyManager.ForceInvoke(27);
	}

	private static int SortMoney(OneKillInfoData left, OneKillInfoData right)
	{
		return right.AllMoney - left.AllMoney;
	}
}
