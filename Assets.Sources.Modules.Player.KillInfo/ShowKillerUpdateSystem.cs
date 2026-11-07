using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.KillInfo;

public class ShowKillerUpdateSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private TimeComponent _time;

	private IGroup<PlayerEntity> _group;

	public ShowKillerUpdateSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_time = contexts.time.time;
		_group = _playerContext.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.Killer));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _group)
		{
			item.killer.ShowKillerTime -= _time.FrameInterval;
			if (item.killer.ShowKillerTime < 0)
			{
				item.RemoveKiller();
			}
		}
	}
}
