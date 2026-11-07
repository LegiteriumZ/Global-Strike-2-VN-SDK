namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AllOutTheZoneLoseHpHandler : ApcPacketHandler<bool>
{
	private GameRuleContext _gameRuleContext;

	public AllOutTheZoneLoseHpHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override void Handle(bool data)
	{
		_gameRuleContext.allRoundSinglesData.IsShowLoseHp = data;
	}

	public override int MethodId()
	{
		return 505;
	}
}
