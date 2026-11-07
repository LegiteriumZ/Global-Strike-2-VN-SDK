using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Beinghit;

public class BeAttackSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private TimeComponent _time;

	private IGroup<PlayerEntity> _group;

	public BeAttackSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_time = contexts.time.time;
		_group = _playerContext.GetGroup(PlayerMatcher.BeAttack);
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _group)
		{
			if (item.beAttack.ShowTime > 0)
			{
				item.beAttack.ShowTime -= _time.FrameInterval;
			}
		}
	}
}
