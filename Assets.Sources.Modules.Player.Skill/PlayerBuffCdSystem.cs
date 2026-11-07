using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.PlayerBuff;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Skill;

public class PlayerBuffCdSystem : IPlaybackSystem
{
	private TimeComponent _time;

	private IGroup<PlayerEntity> _buffGroup;

	public PlayerBuffCdSystem(Contexts contexts)
	{
		_buffGroup = contexts.player.GetGroup(PlayerMatcher.Buff);
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _buffGroup)
		{
			foreach (KeyValuePair<string, IPlayerBuff> buff in item.buff.Buffs)
			{
				buff.Value.Update(_time.FrameInterval);
			}
		}
	}
}
