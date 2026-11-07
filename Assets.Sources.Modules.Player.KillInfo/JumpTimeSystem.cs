using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.Player.KillInfo;

public class JumpTimeSystem : IPlaybackSystem
{
	private GameRuleContext _gameRuleContext;

	private BattleRoomContext _battleRoomContext;

	private TimeComponent _time;

	public JumpTimeSystem(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		if (!_gameRuleContext.currentRule.Rule.IsJump())
		{
			return;
		}
		foreach (OneKillInfoData item in _battleRoomContext.playerInfo.All)
		{
			if (!item.JumpDone)
			{
				item.JumpTime += _time.FrameInterval;
			}
		}
	}
}
