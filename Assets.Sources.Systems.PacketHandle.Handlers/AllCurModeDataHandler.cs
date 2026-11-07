namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AllCurModeDataHandler : ApcPacketHandler<int>
{
	private GameRuleContext _gameRuleContext;

	public AllCurModeDataHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override void Handle(int data)
	{
		_gameRuleContext.allRoundSinglesData.CurMode = data;
	}

	public override int MethodId()
	{
		return 506;
	}
}
