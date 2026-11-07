using Assets.Sources.Components.Time;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.GameRule.Mechwarrior;

public class MechwarriorHumanEnergyDataSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private GameRuleContext _gameRuleContext;

	private BattleRoomContext _battleRoomContext;

	private TimeComponent _timeComponent;

	public MechwarriorHumanEnergyDataSystem(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
		_timeComponent = contexts.time.time;
	}

	public void OnPlayback()
	{
		_gameRuleContext.mechwarriorHumanEnergyData.ChangeGiftTime -= _timeComponent.FrameInterval;
	}

	public bool NeedStart(Contexts contexts)
	{
		return _battleRoomContext.roomData.Data.RaceType == 29;
	}
}
