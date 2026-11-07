using Assets.Sources.Components.Interface.Info.EventParticle;

namespace Assets.Sources.Info.Effect.EventParticle;

public class EventParticle : IEventParticle
{
	private int _totalTime;

	private int _eventType;

	private int _level;

	private int _remainTime;

	public bool hasRestarted { get; set; }

	public EventParticle(int totalTime, int eventType, int level)
	{
		_totalTime = totalTime;
		_eventType = eventType;
		_level = level;
		_remainTime = totalTime;
	}

	public void ResetEvent()
	{
		_remainTime = _totalTime;
		hasRestarted = true;
	}

	public void UpdateEvent(int frameInterval)
	{
		_remainTime -= frameInterval;
	}

	public bool IsEnd()
	{
		return _remainTime <= 0;
	}

	public int GetId()
	{
		return _eventType;
	}

	public int GetLevel()
	{
		return _level;
	}

	public void ZeroEvent()
	{
		_remainTime = 0;
	}
}
