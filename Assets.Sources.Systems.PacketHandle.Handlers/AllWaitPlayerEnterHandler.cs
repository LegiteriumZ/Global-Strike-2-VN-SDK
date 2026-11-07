namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AllWaitPlayerEnterHandler : ApcPacketHandler<int>
{
	private GameRuleContext _gameRuleContext;

	public AllWaitPlayerEnterHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override void Handle(int data)
	{
		_gameRuleContext.allRoundSinglesData.IsShowWaitTip = data == 0;
	}

	public override int MethodId()
	{
		return 503;
	}
}
