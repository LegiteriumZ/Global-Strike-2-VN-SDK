using Assets.Sources.Components.Interface.Info.GameRule;
using Entitas;

namespace Assets.Sources.Systems.GameRule;

public abstract class RuleControlSystem : IExecuteSystem, ISystem
{
	protected BattleRoomContext BattleRoomContext;

	protected PlayerContext PlayerContext;

	protected GameRuleContext GameRuleContext;

	protected TimeContext TimeContext;

	protected RuleControlSystem(Contexts contexts)
	{
		BattleRoomContext = contexts.battleRoom;
		PlayerContext = contexts.player;
		GameRuleContext = contexts.gameRule;
		TimeContext = contexts.time;
	}

	public void Execute()
	{
		if (GameRuleContext.hasCurrentRule)
		{
			IGameRule rule = GameRuleContext.currentRule.Rule;
			ExecuteRule(rule);
		}
	}

	protected abstract void ExecuteRule(IGameRule rule);
}
