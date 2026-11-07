namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class DerangementDataHandler : ApcPacketHandler<int>
{
	private GameRuleContext _gameRuleContext;

	public DerangementDataHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override void Handle(int data)
	{
		_gameRuleContext.dimentionData.Derangement = data;
	}

	public override int MethodId()
	{
		return 507;
	}
}
