using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class UpdateHumanExpAndLvHandler : ApcPacketHandler<TideHumanLvUpData>
{
	private GameRuleContext _gameRuleContext;

	public UpdateHumanExpAndLvHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 90;
	}

	public override void Handle(TideHumanLvUpData data)
	{
		_gameRuleContext.humanityGrowUp.CurrentExp = data.Exp;
		_gameRuleContext.humanityGrowUp.MaxExp = data.MaxExp;
		_gameRuleContext.humanityGrowUp.AddAttack = data.DamageBonus;
		_gameRuleContext.humanityGrowUp.GrowUpLevel = data.Lv;
	}
}
