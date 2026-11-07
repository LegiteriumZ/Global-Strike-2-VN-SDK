using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using NotifyEvent;

namespace Assets.Sources.Modules.GameRule.RpgMiner;

public class EliteTargetIdSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private PlayerContext _playerContext;

	private GameRuleContext _gameRuleContext;

	private BattleRoomContext _battleRoomContext;

	public EliteTargetIdSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (item.GetCareer() == PlayerCareerConstantUtility.Rpg10500002)
			{
				_gameRuleContext.hpProgressData.EliteTargetId = item.GetId();
				NotifyManager.ForceInvoke(3);
			}
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		return _battleRoomContext.roomData.Data.RaceType == 15002;
	}
}
