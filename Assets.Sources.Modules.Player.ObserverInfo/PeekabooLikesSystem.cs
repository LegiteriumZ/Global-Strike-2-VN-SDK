using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.Player.ObserverInfo;

public class PeekabooLikesSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private SnapshotContext _snapshotContext;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private bool _isPlayback;

	public PeekabooLikesSystem(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_snapshotContext = contexts.snapshot;
		_battleRoomContext = contexts.battleRoom;
		_isPlayback = NeedStart(contexts);
	}

	public void OnPlayback()
	{
		if (!_isPlayback || !_playerContext.isMyPlayer)
		{
			return;
		}
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (latestSnapshot != null)
		{
			PlayerInfoData playerInfo = _playerContext.myPlayerEntity.GetPlayerInfo();
			if (latestSnapshot.Observer > 0)
			{
				playerInfo.HasLikesFlag = true;
			}
			else
			{
				playerInfo.HasLikesFlag = false;
			}
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		if (_gameRuleContext.currentRule.Rule.IsExplode())
		{
			return !_battleRoomContext.roomData.IsObserver;
		}
		return false;
	}
}
