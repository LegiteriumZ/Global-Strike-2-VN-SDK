using Assets.Sources.Components.Time;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Dead;

public class SmoothDeadTimerSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private TimeComponent _time;

	public SmoothDeadTimerSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (item.hasBasicInfo)
			{
				int deadTimer = item.basicInfo.Current.DeadTimer;
				if (!item.hasSmoothDeadTimer)
				{
					item.AddSmoothDeadTimer(0);
				}
				item.smoothDeadTimer.DeadTimer += _time.FrameInterval;
				if (item.smoothDeadTimer.DeadTimer > deadTimer)
				{
					item.smoothDeadTimer.DeadTimer = deadTimer;
				}
			}
		}
	}
}
