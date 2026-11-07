namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AllOutTheZoneCountDownHandler : ApcPacketHandler<int>
{
	private GameRuleContext _gameRuleContext;

	public AllOutTheZoneCountDownHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override void Handle(int data)
	{
		_gameRuleContext.allRoundSinglesData.SurplusTime = (int)((double)data * 0.001);
		_gameRuleContext.allRoundSinglesData.IsShowCountDown = _gameRuleContext.allRoundSinglesData.SurplusTime > 0;
	}

	public override int MethodId()
	{
		return 504;
	}
}
