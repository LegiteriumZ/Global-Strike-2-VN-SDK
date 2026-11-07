using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerEffectStatusPlayBackSystem : IPlaybackSystem
{
	private readonly PlayerContext _playerContext;

	private TimeComponent _time;

	private readonly IGroup<PlayerEntity> _group;

	public PlayerEffectStatusPlayBackSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_time = contexts.time.time;
		_group = _playerContext.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.HpShow));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _group)
		{
			if (item.hpShow.ShowMechHpTime > 0)
			{
				item.hpShow.ShowMechHpTime -= _time.FrameInterval;
			}
			if (item.hpShow.ShowPlayerHpTime > 0)
			{
				item.hpShow.ShowPlayerHpTime -= _time.FrameInterval;
			}
			if (item.hpShow.MechRepelTime > 0f)
			{
				item.hpShow.MechRepelTime -= _time.FrameInterval;
			}
		}
	}
}
