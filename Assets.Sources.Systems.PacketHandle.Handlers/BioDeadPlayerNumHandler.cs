using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class BioDeadPlayerNumHandler : ApcPacketHandler<IntData>
{
	private GameRuleContext _gameRuleContext;

	public BioDeadPlayerNumHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 23;
	}

	public override void Handle(IntData data)
	{
		_gameRuleContext.humanityGrowUp.GrowUpLevel = data.Data;
	}
}
