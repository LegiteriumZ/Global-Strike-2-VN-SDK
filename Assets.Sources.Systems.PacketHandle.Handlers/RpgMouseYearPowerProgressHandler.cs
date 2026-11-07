using Assets.Sources.Components.GameRule.Rpg;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgMouseYearPowerProgressHandler : ApcPacketHandler<PowerProgress>
{
	private readonly GameRuleContext _gameRuleContext;

	public RpgMouseYearPowerProgressHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 255;
	}

	public override void Handle(PowerProgress data)
	{
		MouseYearComponent mouseYear = _gameRuleContext.mouseYear;
		mouseYear.EnemyList = data.PhaseValue;
		mouseYear.NowEnemyData = data.CurrentValue;
	}
}
