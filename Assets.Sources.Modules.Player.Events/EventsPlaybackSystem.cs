using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.EventParticle;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Events;

public class EventsPlaybackSystem : IPlaybackSystem
{
	private TimeComponent _timeComponent;

	private readonly IGroup<PlayerEntity> _players;

	private List<int> _cache;

	public EventsPlaybackSystem(Contexts contexts)
	{
		_timeComponent = contexts.time.time;
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.EventParticle));
		_cache = new List<int>();
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity player in _players)
		{
			if (!player.hasEventParticle || player.eventParticle.EventParticles == null)
			{
				continue;
			}
			if (player.IsDead())
			{
				player.eventParticle.EventParticles.Clear();
				continue;
			}
			foreach (KeyValuePair<int, IEventParticle> eventParticle in player.eventParticle.EventParticles)
			{
				IEventParticle value = eventParticle.Value;
				value.UpdateEvent(_timeComponent.FrameInterval);
				if (value.IsEnd())
				{
					_cache.Add(value.GetId());
				}
			}
			if (_cache.Count == 0)
			{
				continue;
			}
			foreach (int item in _cache)
			{
				player.eventParticle.EventParticles.Remove(item);
			}
			_cache.Clear();
		}
	}
}
