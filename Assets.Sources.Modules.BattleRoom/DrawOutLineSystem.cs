using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using share.constant;

namespace Assets.Sources.Modules.BattleRoom;

public class DrawOutLineSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	private bool _battleRoomOutline;

	public DrawOutLineSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnPlayback()
	{
		_battleRoomOutline = false;
		int num = 0;
		bool hasRoomData = _battleRoomContext.hasRoomData;
		if (hasRoomData)
		{
			num = _battleRoomContext.roomData.Data.RaceType;
		}
		foreach (PlayerEntity item in _playerContext)
		{
			bool flag = false;
			if (_battleRoomContext.gameStateEntity.hasEntityStatus && _battleRoomContext.gameStateEntity.entityStatus.StatusDictionary.ContainsKey(item.entityId.Value))
			{
				Dictionary<int, string> dictionary = _battleRoomContext.gameStateEntity.entityStatus.StatusDictionary[item.entityId.Value];
				if (dictionary.ContainsKey(1))
				{
					flag = dictionary[1] == "true";
				}
			}
			if (item.HasStatus(PlayerInfoStatusConstant.FAKE_DEAD.ID))
			{
				if (RuleUtilty.IsAvatarUltimateWipeOut())
				{
					flag = true;
				}
			}
			else if (item.HasStatus(PlayerInfoStatusConstant.XRayShowOutline.ID) && _playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.InXRaySee.ID))
			{
				flag = true;
			}
			if (_playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.HERO_GUANZITOU_SHOW_ALL_PLAYER.ID))
			{
				flag = true;
			}
			if (hasRoomData && (num == 125 || num == 130 || num == 131 || num == 128 || num == 132 || num == 133))
			{
				int num2 = ((_playerContext.cameraOwnerEntity != null) ? _playerContext.cameraOwnerEntity.basicInfo.Current.Team : 0);
				flag = ((item.HasStatus(PlayerInfoStatusConstant.TEAM_VISIBLE.ID) && item.basicInfo.Current.Team == num2) || item.HasStatus(PlayerInfoStatusConstant.ALL_VISIBLE.ID)) && !item.basicInfo.Current.IsDead;
			}
			if (!flag && _playerContext.cameraOwnerEntity != null)
			{
				int num3 = ((_playerContext.cameraOwnerEntity != null) ? _playerContext.cameraOwnerEntity.basicInfo.Current.Team : 0);
				flag = _playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.BIOZ_ZHENGCHASHOU.ID) && item.basicInfo.Current.Team != num3;
			}
			if (RuleUtilty.IsBattleRoyaleMode(num) && _playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.NEW_ESCAPE_SHOW_DISTANCE.ID) && PlayerCareerConstantUtility.IsNoHuMan(item.basicInfo.Current.Career))
			{
				flag = true;
			}
			item.isOutline = _battleRoomContext.gameStateEntity.isSeeAllPlayer || flag;
			_battleRoomOutline = _battleRoomOutline || item.isOutline;
		}
		if (_battleRoomOutline)
		{
			_battleRoomContext.gameStateEntity.isOutline = true;
		}
	}
}
