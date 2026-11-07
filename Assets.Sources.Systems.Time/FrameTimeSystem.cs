using System.Collections.Generic;
using Assets.Scripts.Input;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Entitas;

namespace Assets.Sources.Systems.Time;

public class FrameTimeSystem : IExecuteSystem, ISystem
{
	private readonly TimeContext _timeContext;

	private readonly BattleRoomContext _battleGameContext;

	private readonly PlayerContext _playerContext;

	private ISSJJTimer _timer;

	public FrameTimeSystem(Contexts contexts)
	{
		_timeContext = contexts.time;
		_battleGameContext = contexts.battleRoom;
		_playerContext = contexts.player;
		_timeContext.commonTimer.CommonTimer = new Dictionary<string, ISSJJTimer>();
		_timeContext.commonTimer.RemoveCache = new List<string>();
	}

	public void Execute()
	{
		UpdateFrameTime();
	}

	private void UpdateFrameTime()
	{
		if (_battleGameContext.gameState.State != BattleGameState.Gaming || _playerContext.myPlayerEntity == null || !_timeContext.hasTime)
		{
			return;
		}
		TimeComponent time = _timeContext.time;
		float num = InputCollector.Instance.GetDeltaTime() * 1000f;
		time.FrameInterval = (int)num;
		if (time.FrameInterval > 120)
		{
			time.FrameInterval = 120;
		}
		time.ClientRealTime += time.FrameInterval;
		if (!_timeContext.hasCommonTimer || _timeContext.commonTimer.CommonTimer.Count == 0)
		{
			return;
		}
		foreach (KeyValuePair<string, ISSJJTimer> item in _timeContext.commonTimer.CommonTimer)
		{
			_timer = item.Value;
			if (!_timer.TimeEnded)
			{
				_timer.AddTime(time.FrameInterval);
				if (_timer.TimeEnded)
				{
					_timeContext.commonTimer.RemoveCache.Add(item.Key);
				}
			}
		}
		if (_timeContext.commonTimer.RemoveCache.Count == 0)
		{
			return;
		}
		foreach (string item2 in _timeContext.commonTimer.RemoveCache)
		{
			_timeContext.commonTimer.CommonTimer.Remove(item2);
		}
		_timeContext.commonTimer.RemoveCache.Clear();
	}
}
