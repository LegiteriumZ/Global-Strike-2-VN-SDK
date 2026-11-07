using System.Collections.Generic;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Info.PlayerBuff;
using Core.Utils.System46;
using NetData;

namespace Assets.Sources.Modules.Player.Skill;

public class PlayerSkillAndBuffInitSystem : IPlaybackInitSystem
{
	private BattleRoomContext _battleRoomContext;

	private PlayerContext _playerContext;

	public PlayerSkillAndBuffInitSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public void OnPlaybackInit()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.hasSkill)
			{
				continue;
			}
			int id = item.basicInfo.Current.Id;
			item.skill.Skills = _battleRoomContext.playerInfo.GetSkillMap(id);
			if (item.hasBasicInfo)
			{
				long cid = item.basicInfo.Cid;
				PlayerInfoData playerInfoData = _battleRoomContext.playerInfo.GetPlayerInfoData(cid);
				if (playerInfoData != null)
				{
					item.skill.Info = playerInfoData;
				}
				if (!_battleRoomContext.playerInfo.StatusDatas.ContainsKey(cid))
				{
					_battleRoomContext.playerInfo.StatusDatas.Add(cid, new MyDictionary<int, PlayerInfoComponent.StatusDes>());
				}
				IMyDictionary<int, PlayerInfoComponent.StatusDes> myDictionary = _battleRoomContext.playerInfo.StatusDatas[cid];
				if (myDictionary != null)
				{
					item.skill.Status = myDictionary;
				}
				List<KeyValuePair<string, int>> playerBuffs = _battleRoomContext.playerInfo.GetPlayerBuffs(cid);
				foreach (KeyValuePair<string, int> item2 in playerBuffs)
				{
					if (!item.buff.Buffs.ContainsKey(item2.Key))
					{
						item.buff.Buffs.Add(item2.Key, new DefaultPlayerBuff(item2.Key, item2.Value));
					}
					item.buff.SetBuff(item2.Key, item2.Value);
				}
				playerBuffs.Clear();
			}
			if (item.isMyPlayer)
			{
				item.skill.SkillAdditionalData = _battleRoomContext.playerInfo.MyPlayerSkillAdditionalData;
			}
		}
	}
}
