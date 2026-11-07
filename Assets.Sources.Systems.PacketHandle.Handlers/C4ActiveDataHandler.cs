using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class C4ActiveDataHandler : ApcPacketHandler<C4ActiveData>
{
	private GameRuleContext _gameRuleContext;

	public C4ActiveDataHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 14;
	}

	public override void Handle(C4ActiveData data)
	{
		_gameRuleContext.c4State.Active = data.Active;
		_gameRuleContext.c4State.Time = data.Time;
	}
}
