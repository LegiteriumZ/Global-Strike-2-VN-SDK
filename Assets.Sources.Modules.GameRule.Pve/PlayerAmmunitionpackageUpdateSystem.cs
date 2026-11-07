using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.GameRule.Pve;

public class PlayerAmmunitionpackageUpdateSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	private TimeComponent _timeComponent;

	public PlayerAmmunitionpackageUpdateSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_timeComponent = contexts.time.time;
	}

	public void OnPlayback()
	{
		if (!_playerContext.isCameraOwner)
		{
			return;
		}
		PlayerInfoData playerInfo = _playerContext.cameraOwnerEntity.GetPlayerInfo();
		if (playerInfo == null)
		{
			return;
		}
		if (!_gameRuleContext.pveState.Ammunitionpackage && _playerContext.cameraOwnerEntity.GetPlayerInfo().Ammunitionpackage)
		{
			if (_playerContext.cameraOwnerEntity.GetPlayerInfo().AmmunitionTime > 0)
			{
				_gameRuleContext.pveState.AmmunitionpackageTime = _playerContext.cameraOwnerEntity.GetPlayerInfo().AmmunitionTime;
			}
			else
			{
				_gameRuleContext.pveState.AmmunitionpackageTime = 2000;
			}
		}
		if (_gameRuleContext.pveState.AmmunitionpackageTime <= 0)
		{
			playerInfo.Ammunitionpackage = false;
		}
		_gameRuleContext.pveState.AmmunitionpackageTime -= _timeComponent.FrameInterval;
		_gameRuleContext.pveState.Ammunitionpackage = playerInfo.Ammunitionpackage;
	}

	public bool NeedStart(Contexts contexts)
	{
		int raceType = _battleRoomContext.roomData.Data.RaceType;
		if (!_gameRuleContext.currentRule.Rule.IsPve() && raceType != 28)
		{
			return RuleUtilty.IsMultipleRpg(raceType);
		}
		return true;
	}
}
