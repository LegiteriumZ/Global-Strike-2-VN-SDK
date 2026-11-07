using Assets.Sources.Components.Time;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.GameRule.Common;

public class GameProgressSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private GameRuleContext _gameRuleContext;

	private TimeComponent _timeComponent;

	public GameProgressSystem(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeComponent = contexts.time.time;
	}

	public void OnPlayback()
	{
		float num = ((_gameRuleContext.gameProgressData.Speed == 0f) ? 1f : _gameRuleContext.gameProgressData.Speed);
		_gameRuleContext.gameProgressData.CurrentProgressTime += (int)((float)_timeComponent.FrameInterval * num);
	}

	public bool NeedStart(Contexts contexts)
	{
		return true;
	}
}
