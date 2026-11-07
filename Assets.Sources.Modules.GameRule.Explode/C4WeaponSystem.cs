using Assets.Sources.Components.Time;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.GameRule.Explode;

public class C4WeaponSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private GameRuleContext _gameRuleContext;

	private TimeComponent _timeComponet;

	public C4WeaponSystem(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeComponet = contexts.time.time;
	}

	public void OnPlayback()
	{
		if (_gameRuleContext.c4State.Active)
		{
			_gameRuleContext.c4State.Time += _timeComponet.FrameInterval;
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		return _gameRuleContext.currentRule.Rule.IsHasC4();
	}
}
