using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GuoQinUIMessageHandler : ApcPacketHandler<GuoQinRaceInfoUIData>
{
	private GameRuleContext _gameRuleContext;

	public GuoQinUIMessageHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 236;
	}

	public override void Handle(GuoQinRaceInfoUIData data)
	{
		_gameRuleContext.guoQinRaceUI.Data = data;
	}
}
