using Assets.Sources.Constant;
using Assets.Sources.Utils;
using Entitas;

namespace Assets.Sources.Systems.GameRule;

public class SectionTimeSystem : IExecuteSystem, ISystem
{
	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private int _raceType;

	public SectionTimeSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_gameRuleContext = contexts.gameRule;
		_raceType = _battleRoomContext.roomData.Data.RaceType;
	}

	public void Execute()
	{
		int num = (int)(TimeUtility.UnixTimeNow() - _battleRoomContext.sectionTime.SectionStartTimeClient);
		_battleRoomContext.sectionTime.Passed = num;
		_battleRoomContext.sectionTime.SectionTime = _battleRoomContext.roomData.Data.SectionTime - num;
		_battleRoomContext.sectionTime.Minutes = TimeUtility.GetSectionTimeMinutes(_battleRoomContext.sectionTime);
		_battleRoomContext.sectionTime.Seconds = TimeUtility.GetSectionTimeSeconds(_battleRoomContext.sectionTime);
		if (RuleUtilty.IsNotMoveRule(_raceType))
		{
			_battleRoomContext.sectionTime.CannotMoveTime = _gameRuleContext.currentRule.Rule.GetNotMoveTime() - num;
			if (_battleRoomContext.sectionTime.CannotMoveTime < 0)
			{
				_battleRoomContext.sectionTime.CannotMoveTime = 0;
			}
		}
	}
}
