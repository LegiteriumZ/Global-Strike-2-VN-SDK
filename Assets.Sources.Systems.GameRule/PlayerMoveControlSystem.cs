using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.GameRule;

namespace Assets.Sources.Systems.GameRule;

public class PlayerMoveControlSystem : RuleControlSystem
{
	private int _raceType;

	private List<int> _ignoreRuleList = new List<int> { 123 };

	public PlayerMoveControlSystem(Contexts contexts)
		: base(contexts)
	{
		_raceType = contexts.battleRoom.roomData.Data.RaceType;
	}

	protected override void ExecuteRule(IGameRule rule)
	{
		if (!_ignoreRuleList.Contains(_raceType))
		{
			int notMoveTime = rule.GetNotMoveTime();
			if (notMoveTime > 0 && PlayerContext.myPlayerEntity != null && BattleRoomContext.sectionTime.SectionStartTimeClient > 0)
			{
				bool notMove = BattleRoomContext.sectionTime.Passed < notMoveTime;
				PlayerContext.myPlayerEntity.move.NotMove = notMove;
			}
		}
	}
}
