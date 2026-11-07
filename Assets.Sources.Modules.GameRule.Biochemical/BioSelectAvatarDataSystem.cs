using Assets.Sources.Components.Time;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.GameRule.Biochemical;

public class BioSelectAvatarDataSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private GameRuleContext _gameRuleContext;

	private TimeComponent _timeComponent;

	public BioSelectAvatarDataSystem(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeComponent = contexts.time.time;
	}

	public void OnPlayback()
	{
		_gameRuleContext.bioSelectAvatarData.SelectTime -= _timeComponent.FrameInterval;
	}

	public bool NeedStart(Contexts contexts)
	{
		if (!_gameRuleContext.currentRule.Rule.IsBio())
		{
			return Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 29;
		}
		return true;
	}
}
