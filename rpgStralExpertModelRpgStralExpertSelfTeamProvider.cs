using System.Collections.Generic;
using Assets.Sources.Components.Time;
using NetData;

public class rpgStralExpertModelRpgStralExpertSelfTeamProvider : IrpgStralExpertModelRpgStralExpertSelfTeamProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected BattleRoomContext _battleRoomContext;

	protected PlayerContext _playerContext;

	public rpgStralExpertModelRpgStralExpertSelfTeamProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float getTeamId()
	{
		if (_battleRoomContext == null || !_battleRoomContext.hasPlayerInfo || _battleRoomContext.playerInfo.All == null || _playerContext == null || _playerContext.cameraOwnerEntity == null || !_playerContext.cameraOwnerEntity.hasBasicInfo || _playerContext.cameraOwnerEntity.basicInfo.Current == null)
		{
			return 0f;
		}
		List<OneKillInfoData> all = _battleRoomContext.playerInfo.All;
		int id = _playerContext.cameraOwnerEntity.basicInfo.Current.Id;
		foreach (OneKillInfoData item in all)
		{
			if (item.Id == id)
			{
				return item.Team;
			}
		}
		return 0f;
	}
}
